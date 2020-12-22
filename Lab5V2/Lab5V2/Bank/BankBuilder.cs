using System;

namespace Lab5V2
{
    public class BankBuilder
    {
        private Guid _bankID;
        private double _percentage;
        private double _commission;
        private double _limitOnTransferForSuspiciousAccount;
        private double _limitOnWithdrawingForSuspiciousAccount;

        public BankBuilder bankID()
        {
            _bankID = Guid.NewGuid();
            return this;
        }

        public BankBuilder percentage(double percentage)
        {
            _percentage = percentage;
            return this;
        }

        public BankBuilder commission(double commission)
        {
            _commission = commission;
            return this;
        }

        public BankBuilder limitOnTransferForSuspiciousAccount(double limitOnTransferForSuspiciousAccount)
        {
            _limitOnTransferForSuspiciousAccount = limitOnTransferForSuspiciousAccount;
            return this;
        }

        public BankBuilder limitOnWithdrawingForSuspiciousAccount(double limitOnWithdrawingForSuspiciousAccount)
        {
            _limitOnWithdrawingForSuspiciousAccount = limitOnWithdrawingForSuspiciousAccount;
            return this;
        }

        public double getPercentage()
        {
            return _percentage;
        }

        public double getCommission()
        {
            return _commission;
        }

        public double getLimitOnTransferForSuspiciousAccount()
        {
            return _limitOnTransferForSuspiciousAccount;
        }

        public double getLimitOnWithdrawingForSuspiciousAccount()
        {
            return _limitOnWithdrawingForSuspiciousAccount;
        }

        public Guid getBankID()
        {
            return _bankID;
        }

        public Bank build()
        {
            return new Bank(this);
        }
    }
}