using System;

namespace Lab5V2
{
    class Program
    {
        static void Main(string[] args)
        {
            var client1 = new ClientBuilder()
                    .Name("Zhanna")
                    .Surname("Rui")
                    .Address("Mira 18")
                    .Passport(668676)
                    .Build();
            
                var bank1 = new BankBuilder()
                    .bankID()
                    .percentage(0.05)
                    .commission(0.002)
                    .limitOnTransferForSuspiciousAccount(5000)
                    .limitOnWithdrawingForSuspiciousAccount(5000)
                    .build();
            
            
                bank1.AddClientToBank(client1);

                IAccount account1 = new DebitAccount(bank1.GetProfitRate());
                bank1.AddAccountForClient(client1, account1);

                Console.WriteLine("");
                Console.WriteLine("Information about client:" + "\n");


                bank1.PrintClients();

                bank1.Deposit(client1, account1, 10000);

                bank1.Withdraw(client1,account1, 5000);

                Console.WriteLine("Information about transactions:" + "\n");
            
                account1.ListOfTransactions(account1);

                bank1.UndoLastTransaction(account1);

                Console.WriteLine("Information about transactions:" + "\n");
                account1.ListOfTransactions(account1);

        }
    }
}