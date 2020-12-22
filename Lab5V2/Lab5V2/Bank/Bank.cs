using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5V2
{
    public class Bank
    {
        private double Percentage { get; }
        private double Commission { get; }
        private double LimitOnTransferForSuspiciousAccount { get; }
        private double LimitOnWithdrawingForSuspiciousAccount { get; }
        private List<Client> ClientsList = new List<Client>();

        public Bank(BankBuilder bankBuilder)
        {
            Percentage = bankBuilder.getPercentage();
            Commission = bankBuilder.getCommission();
            LimitOnTransferForSuspiciousAccount = bankBuilder.getLimitOnTransferForSuspiciousAccount();
            LimitOnWithdrawingForSuspiciousAccount = bankBuilder.getLimitOnWithdrawingForSuspiciousAccount();
        }

        public void AddClientToBank(Client client)
        {
            if (ClientsList.Contains(client))
            {
                throw new Exception("Client is already in the bank.");
            }
            ClientsList.Add(client);
        }

        public void AddAccountForClient(Client client, IAccount account)
        {
            if (!client.IsActive())
            {
                throw new Exception(
                    "Account not active, please provide passport and address info in order to add accounts to it");
            }

            client.AddAccount(account);
        }

        public void UndoLastTransaction(IAccount account)
        {
            var client = GetClientWithAccountId(account.AccountId);
            client.Undo(account);
        }

        public void Withdraw(Client client, IAccount account, double amountToWithdraw)
        {
            if (!client.IsActive() && amountToWithdraw > LimitOnWithdrawingForSuspiciousAccount)
            {
                throw new Exception(
                    $"The client is not active, maximum withdrawal allowed is {LimitOnWithdrawingForSuspiciousAccount}");
            }

            client.WithdrawFromAccount(account, amountToWithdraw);
        }

        public void Deposit(Client client, IAccount account, double amountToWithdraw)
        {
            client.AddingToAccount(account, amountToWithdraw);
        }

        public void Transfer(IAccount accountFrom, IAccount accountTo, double amountToTransfer)
        {
            var client = GetClientWithAccountId(accountFrom.AccountId);
            if (!client.IsActive() && amountToTransfer > LimitOnTransferForSuspiciousAccount)
            {
                throw new Exception("The client is not active, maximum transfer allowed is " +
                                    LimitOnTransferForSuspiciousAccount);
            }

            client.Transfer(accountFrom, accountTo, amountToTransfer);
        }

        public Client GetClientWithAccountId(Guid accountId)
        {
            return ClientsList.FirstOrDefault(client => client.GetAccount(accountId).AccountId == accountId);
        }

        public IAccount GetAccountWithAccountId(Guid accountId)
        {
            return GetClientWithAccountId(accountId).GetAccount(accountId);
        }

        public void PrintClients()
        {
            foreach (var client in ClientsList)
            {
                Console.WriteLine("Name: " + client.GetName() + "\n"
                                  + "Surname: " + client.GetSurname());
                if (client.IsActive())
                    Console.WriteLine("Client is active");
                else
                    Console.WriteLine("Client is not active");
                if (client.GetAddress() != null)
                    Console.WriteLine("Address: " + client.GetAddress());
                if (client.GetPassportNumber() != null)
                    Console.WriteLine("Passport number: " + client.GetPassportNumber());
                Console.WriteLine("");
            }
        }

        public double GetProfitRate()
        {
            return Percentage;
        }

        public double GetCommissionRate()
        {
            return Commission;
        }
    }
}