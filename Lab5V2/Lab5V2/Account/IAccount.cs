using System;
using System.Collections.Generic;

namespace Lab5V2
{
    public interface IAccount
    {
        Guid AccountId { get; }
        double ProfitRate { get; }
        double CommissionRate { get; }
        double AccountBalance { get; set; }
        Dictionary<DateTime, double> DailyProfitList { get; set; }
        List<Transactions> TransactionsList { get; set; }
        void Withdraw(double amountToWithdraw);
        void Deposit(double amountToDeposit);
        void CalculateDailyProfit(DateTime day);
        double CalculateMonthlyProfit();
        
        void ListOfTransactions(IAccount account);
    }
}