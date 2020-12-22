using System;
using System.Collections.Generic;

namespace Lab5V2
{
    public class DepositAccount : IAccount
    {
        public Guid AccountId { get; }
        public double ProfitRate { get; }
        public double CommissionRate { get; }
        public double AccountBalance { get; set; }
        public Dictionary<DateTime, double> DailyProfitList { get; set; }
        public List<Transactions> TransactionsList { get; set; }
        private bool CanWithdrawOrTransfer { get; set; }
        private DateTime DueDate { get; set; }

        public DepositAccount(double initialDepositAmount, DateTime dueDate)
        {
            
            AccountId = Guid.NewGuid();
            ProfitRate = GetProfitRate(initialDepositAmount);
            CommissionRate = 0;
            AccountBalance = initialDepositAmount;
            CanWithdrawOrTransfer = false;
            DueDate = dueDate;
            DailyProfitList = new Dictionary<DateTime, double>();
            TransactionsList = new List<Transactions>();
        }

        public double GetProfitRate(double initialDepositAmount)
        {
            if (initialDepositAmount >= 1 && initialDepositAmount <= 50000)
                return 0.03;
            else if (initialDepositAmount >= 50001 && initialDepositAmount <= 100000)
                return 0.035;
            else if (initialDepositAmount >= 100001)
                return 0.04;
            return -1;
        }
        public void Withdraw(double amountToWithdraw)
        {
            if (DateTime.Now >= DueDate)
            {
                AccountBalance -= amountToWithdraw;
            }
            else
            {
                throw new Exception("Cannot withdraw until the due date!");
            }
        }

        public void Deposit(double amountToDeposit)
        {
            AccountBalance += amountToDeposit;
        }

        public void CalculateDailyProfit(DateTime day)
        {
            var dailyProfitRate = ProfitRate / 365;
            var todaysProfit = dailyProfitRate * AccountBalance;
            DailyProfitList.Add(day, todaysProfit);
        }

        public double CalculateMonthlyProfit()
        {
            double monthlyProfit = 0;
            foreach (var day in DailyProfitList.Keys)
            {
                monthlyProfit += DailyProfitList[day];
            }
            AccountBalance += monthlyProfit;
            Console.WriteLine($"This months Profit : {monthlyProfit}");
            DailyProfitList.Clear();
            return monthlyProfit;
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