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

    int TryGetInt(const string& sector, const string& property) {
        if (!_map.count(sector)){
            throw SectorErrorException("Sector is not presented in the collection");
        } else if (!_map[sector].count(property)) {
            throw PropertyErrorException("Property is not presented in the collection");
        }
        try {
            return stoi(_map[sector][property]);
        } catch (exception ex) {
            throw IniParseException("Failed to parse: int");
        }

    }

    double TryGetDouble(const string& sector, const string& property) {
        if (!_map.count(sector)){
            throw SectorErrorException("Sector is not presented in the collection");
        } else if (!_map[sector].count(property)) {
            throw PropertyErrorException("Property is not presented in the collection");
        }
        try {
            return stod(_map[sector][property]);
        } catch (exception ex) {
            throw IniParseException("Failed to parse: double");
        }
    }

    string TryGetString(const string& sector, const string& property) {
        if (!_map.count(sector)){
            throw SectorErrorException("Sector is not presented in the collection");
        } else if (!_map[sector].count(property)) {
            throw PropertyErrorException("Property is not presented in the collection");
        }
        try {
            stod(_map[sector][property]);
        } catch (exception ex) {
            return _map[sector][property];
        }
        throw IniParseException("Failed to parse: string");
    }
};