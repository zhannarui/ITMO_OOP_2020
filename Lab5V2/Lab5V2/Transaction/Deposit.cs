using System;

namespace Lab5V2
{
    public class Deposit : Transactions
    {
        public string typeOfTransaction = "Deposit";


        public Deposit(Guid sourceAccountId, double amountToDeposit)
        {
            SourceAccountId = sourceAccountId;
            TransactionAmount = amountToDeposit;
        }

        public override string GetType()
        {
            return typeOfTransaction;
        }

        public override void GetList()
        {
            Console.WriteLine(GetType());
            Console.WriteLine("transaction ID: " + GetTransactionId());
            Console.WriteLine("Date: " + GetTime());
            Console.WriteLine("Transaction amount: " + GetTransactionAmount() + "\n");
        }
    }
}