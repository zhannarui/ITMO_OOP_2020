#include <iostream>
#include "IniParser.h"

using namespace std;


int main() {
    string path = "/Users/zannarui/Desktop/ИТМО/OOP/lab1/cmake-build-debug/input.ini";
    IniParser ini;
    Data data = ini.Parse(path);
    cout << data.TryGetInt("NCMD", "EnableChannelControl") << '\n';
    cout << data.TryGetDouble("ADC_DEV", "BufferLenSeconds") << '\n';
    cout << data.TryGetString("COMMON", "DiskCachePath") << '\n';

    path = path.erase(path.find('.'), path.length());
    path += ".txt";
    try {
        data = ini.Parse(path);
    } catch (IniFileException ex) {
        cerr << ex.what() << '\n';
    }


    string brokenPath = "/Users/zannarui/Desktop/ИТМО/OOP/lab1/broken.ini";
    try {
        IniParser ini;
        Data data = ini.Parse(brokenPath);
    } catch (IniFileException ex) {
        cerr << ex.what() << '\n';
    }


    try {
        cout << data.TryGetInt("COMMON", "DiskCachePath");
    } catch (IniParseException ex) {
        cerr << ex.what() << '\n';
    }
    try {
        cout << data.TryGetDouble("COMMON", "DiskCachePath");
    } catch (IniParseException ex) {
        cerr << ex.what() << '\n';
    }
    try {
        cout << data.TryGetString("COMMON", "StatisterTimeMs");
    } catch (IniParseException ex) {
        cerr << ex.what() << '\n';
    }


    try {
        cout << data.TryGetInt("DVD", "EnableChannelControl") << '\n';
    } catch (SectorErrorException ex){
        cerr<< ex.what()<<'\n';
    }
    try {
        cout << data.TryGetDouble("DVD", "EnableChannelControl") << '\n';
    } catch (SectorErrorException ex){
        cerr<< ex.what()<<'\n';
    }
    try {
        cout << data.TryGetString("DVD", "EnableChannelControl") << '\n';
    } catch (SectorErrorException ex){
        cerr<< ex.what()<<'\n';
    }


    try {
        cout << data.TryGetInt("COMMON", "BBC") << '\n';
    } catch (PropertyErrorException ex){
        cerr<< ex.what()<<'\n';
    }
    try {
        cout << data.TryGetDouble("COMMON", "BBC") << '\n';
    } catch (PropertyErrorException ex){
        cerr<< ex.what()<<'\n';
    }
    try {
        cout << data.TryGetString("COMMON", "BBC") << '\n';
    } catch (PropertyErrorException ex){
        cerr<< ex.what()<<'\n';
    }
}