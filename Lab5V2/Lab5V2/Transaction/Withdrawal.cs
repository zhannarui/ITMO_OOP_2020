using System;

namespace Lab5V2
{
    public class Withdrawal : Transactions
    {
        public string typeOfTransaction = "Withdraw";

        public Withdrawal(Guid sourceAccountId, double amountToWithdraw) {
            SourceAccountId = sourceAccountId;
            TransactionAmount = amountToWithdraw;
        }

        public override string GetType() {
            return typeOfTransaction;
        }

        public override void GetList() {
            Console.WriteLine(GetType());
            Console.WriteLine("transaction ID: " + GetTransactionId());
            Console.WriteLine("Date: " + GetTime());
            Console.WriteLine("Transaction amount: " + GetTransactionAmount() + "\n");
        }
    }
}