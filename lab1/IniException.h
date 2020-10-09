#pragma once
#include <exception>
#include <string>

using namespace std;

class IniParseException : public exception {
private:
    const char * error;
public:
    explicit IniParseException(const char * err) {
        this->error = err;
    }
    const char * what () const noexcept override {
        return error;
    }
};

class IniFileException : public exception {
private:
    const char * error;
public:
    explicit IniFileException(const char * err) {
        this->error = err;
    }
    const char * what () const noexcept override {
        return error;
    }
};

class SectorErrorException : public exception {
private:
    const char * error;
public:
    explicit SectorErrorException(const char * err) {
        this->error = err;
    }
    const char * what () const noexcept override {
        return error;
    }
};

class PropertyErrorException : public exception {
private:
    const char * error;
public:
    explicit PropertyErrorException(const char * err) {
        this->error = err;
    }
    const char * what () const noexcept override {
        return error;
    }
};
