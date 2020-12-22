using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Lab5V2
{
    public class ClientBuilder
    {
        private string _name;
        private string _surname;
        private string _address;
        private int _passport;

        public ClientBuilder Name(string name) {
            this._name = name;
            return this;
        }

        public ClientBuilder Surname(string surname) {
            this._surname = surname;
            return this;
        }

        public ClientBuilder Address(string address) {
            this._address = address;
            return this;
        }

        public ClientBuilder Passport(int passport) {
            this._passport = passport;
            return this;
        }

        public string GetName() {
            return _name;
        }

        public string GetSurname() {
            return _surname;
        }

        public string GetAddress() {
            return _address;
        }

        public int GetPassport() {
            return _passport;
        }

        public Client Build() {
            return new Client(this);
        }
    }
}