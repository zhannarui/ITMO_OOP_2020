using System;

namespace Lab5V2
{
    public class Transfer : Transactions
    {
        public string typeOfTransaction = "Transfer";

        public Transfer(IAccount sourceAccount, IAccount destinationAccount, double amountToTransfer) {
            SourceAccountId = sourceAccount.AccountId;
            TransactionAmount = amountToTransfer;
            DestinationAccountId = destinationAccount.AccountId;
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