using System;

namespace Lab5V2
{
    public abstract class Transactions
    {
        public Guid transactionId;
        public DateTime TransactionTime;
        public Guid SourceAccountId;
        public double TransactionAmount;
        public Guid DestinationAccountId;

        public Transactions()
        {
            transactionId = Guid.NewGuid();
            TransactionTime = DateTime.Now;
        }

        public double GetTransactionAmount()
        {
            return TransactionAmount;
        }

        public Guid GetTransactionId()
        {
            return transactionId;
        }

        public abstract string GetType();

        public DateTime GetTime()
        {
            return TransactionTime;
        }

        public abstract void GetList();
    }
    
    }