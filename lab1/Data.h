#pragma once
#include "IniException.h"
#include <utility>

using namespace std;

class Data {
private:
    unordered_map<string, unordered_map<string, string>> _map;
public:
    Data(unordered_map<string, unordered_map<string, string>> map) {
        this->_map = move(map);
    }

    string IsExtinct(string section, string property) {
        unordered_map<string, string> temp;
        string value;
        if(_map.count(section)){
            temp = _map[section];
            if(temp.count(property)){
                return temp[property];
            } else {
                throw PropertyErrorException("Property is not presented in the collection");
            }
        } else {
            throw SectorErrorException("Sector is not presented in the collection");
        }
    }

    int TryGetInt(const string& sector, const string& property) {
        return stoi(IsExtinct(sector, property));
    }

    double TryGetDouble(const string& sector, const string& property) {
        return stod(IsExtinct(sector, property));
    }

    string TryGetString(const string& sector, const string& property) {
        try {
            stod(IsExtinct(sector,property));
        } catch (exception ex) {
            return _map[sector][property];
        }
        throw IniParseException("Failed to parse: string");
    }
};
