using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab5V2
{
    public class Client
    {
        private List<IAccount> accounts = new List<IAccount>();
        private ICommand _command;
        private string _name;
        private string _surname;
        private string _address;
        private int _passport;

        public Client(ClientBuilder clientBuilder)
        {
            _name = clientBuilder.GetName();
            _surname = clientBuilder.GetSurname();
            _address = clientBuilder.GetAddress();
            _passport = clientBuilder.GetPassport();
        }


        public void AddAccount(IAccount account)
        {
            accounts.Add(account);
        }

        public void AddingToAccount(IAccount account, double money)
        {
            _command = new DepositCommand(account, money);

            _command.execute();
        }

        public void WithdrawFromAccount(IAccount account, double amountToWithdraw)
        {
            _command = new WithdrawCommand(account, amountToWithdraw);
            _command.execute();
        }

        public void Transfer(IAccount sourceAccount, IAccount destinationAccount, double amountToTransfer)
        {
            _command = new TransferCommand(sourceAccount, destinationAccount, amountToTransfer);
            _command.execute();
        }

        public void Undo(IAccount account)
        {
            _command.undo();
        }

        public bool IsActive()
        {
            return _address != null || _passport != null;
        }

        public IAccount GetAccount(Guid accountId)
        {
            IAccount account = null;
            foreach (var acc in accounts)
            {
                if (acc.AccountId == accountId)
                    account = acc;
            }

            if (account == null)
                throw new Exception("Account does not exist");
            return account;
        }

        public void SetPassportNumber(int passportNumber)
        {
            _passport = passportNumber;
        }

        public void SetAddress(string address)
        {
            _address = address;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public string GetAddress()
        {
            return _address;
        }

        public int GetPassportNumber()
        {
            return _passport;
        }
    }
    
}