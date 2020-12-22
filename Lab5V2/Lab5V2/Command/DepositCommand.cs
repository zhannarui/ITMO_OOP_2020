namespace Lab5V2
{
    public class DepositCommand : ICommand
    {
        private readonly double _amountToDeposit;
        private readonly IAccount _account;
        private Deposit _deposition;

        public DepositCommand(IAccount account, double amountToDeposit)
        {
            _amountToDeposit = amountToDeposit;
            _account = account;
        }

        public void execute()
        {
            _account.Deposit(_amountToDeposit);
            _deposition = new Deposit(_account.AccountId, _amountToDeposit);
            _account.TransactionsList.Add(_deposition);
        }

        public void undo()
        {
            _account.Withdraw(_amountToDeposit);
            _account.TransactionsList.Remove(_deposition);
        }
    }
    
}