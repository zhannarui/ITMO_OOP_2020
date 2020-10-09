#pragma once
#include <regex>
#include <unordered_map>
#include <fstream>
#include "Data.h"
#include "IniException.h"

using namespace std;

class IniParser {
private:
    static bool isSector(const string& line) {
        regex sector("\\[[a-zA-Z0-9_]*\\]");
        return regex_match(line, sector);
    }
    static bool isProperty(const string& line) {
        regex property("[a-zA-Z_0-9/-]* *= *[a-zA-Z_0-9./-]* *");
        return regex_match(line, property);
    }
    static string removeComments(string& line) {
        if(line.find(';') != -1) {
            line.erase(line.find(';'), line.length());
        }
        return line;
    }

    static unordered_map<string, unordered_map<string, string>> iniToMap(const string& path) {
        ifstream in (path);
        if(path.substr(path.length() - 4, 4) != ".ini") {
            throw IniFileException("Wrong format of file");
        }
        string currentLine, currentKey;
        unordered_map<string, unordered_map<string, string>> tempMap;
        while(!in.eof()) {
            getline(in, currentLine);
            currentLine = removeComments(currentLine);
            if(currentLine.empty()) continue;
            if(isSector(currentLine)) {
                currentLine.erase(currentLine.find('['), 1);
                currentLine.erase(currentLine.find(']'), 1);
                currentKey = currentLine;
            } else if (isProperty(currentLine)) {
                string name = currentLine;
                string value = currentLine;
                name.erase(name.find('=') - 1, name.length());
                value.erase(0, value.find('=') + 2);
                if(value.find(' ') != -1) value.erase(value.find(' '), 1);
                tempMap[currentKey][name] = value;
            } else {
                throw IniFileException("Wrong format of ini file");
            }
        }
        return tempMap;
    }

public:
    Data Parse(const string& path) {
        return Data(iniToMap(path));
    }
};
