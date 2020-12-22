using System;
using System.Collections.Generic;

namespace Lab5V2
{
    public class CreditAccount : IAccount
    {
        public Guid AccountId { get; }
        public double ProfitRate { get; }
        public double CommissionRate { get; }
        public double AccountBalance { get; set; }
        public Dictionary<DateTime, double> DailyProfitList { get; set; }
        public List<Transactions> TransactionsList { get; set; }
        private Dictionary<DateTime, double> CommissionsList { get; set; }
        public bool CanWithdrawOrTransfer { get; set; }
        private double UpperLimit { get; }
        private double LowerLimit { get; }

        public CreditAccount(double upperLimit, double lowerLimit, double commissionRate)
        {
            AccountId = Guid.NewGuid();
            ProfitRate = 0;
            CommissionRate = commissionRate;
            AccountBalance = upperLimit;
            CanWithdrawOrTransfer = true;
            UpperLimit = upperLimit;
            LowerLimit = lowerLimit;
            DailyProfitList = new Dictionary<DateTime, double>();
            CommissionsList = new Dictionary<DateTime, double>();
            TransactionsList = new List<Transactions>();
        }

        public void Withdraw(double amountToWithdraw)
        {
            if (!(AccountBalance - amountToWithdraw <= LowerLimit))
            {
                AccountBalance -= amountToWithdraw;
                if (AccountBalance < 0 && AccountBalance - amountToWithdraw * CommissionRate <= LowerLimit)
                {
                    CommissionsList.Add(DateTime.UtcNow, amountToWithdraw * CommissionRate);
                    AccountBalance -= amountToWithdraw * CommissionRate;
                }
                else
                {
                    throw new Exception(
                        "With the banks commission rate, cannot withdraw the corresponding amount as it will exceed the account limit.");
                }
            }
            else
            {
                throw new Exception("Cannot withdraw beyond the account limit");
            }
        }

        public void Deposit(double amountToDeposit)
        {
            throw new Exception("Credit account cannot accept deposits.");
        }

        public void CalculateDailyProfit(DateTime day)
        {
            throw new Exception("Credit account doesn't have profit.");
        }

        public double CalculateMonthlyProfit()
        {
            throw new Exception("Credit account doesn't have profit.");
        }

        public void ListOfTransactions(IAccount account)
        {
            foreach (var trans in TransactionsList)
            {
                trans.GetList();
            }
        }
    }
}