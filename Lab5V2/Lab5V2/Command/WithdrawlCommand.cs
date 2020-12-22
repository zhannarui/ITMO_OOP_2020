namespace Lab5V2
{
    public class WithdrawCommand : ICommand
    {
        private readonly double _amountToWithdraw;
        private readonly IAccount _account;
        private Withdrawal _withdrawal;
        public WithdrawCommand(IAccount account, double amountToWithdraw)
        {
            _amountToWithdraw = amountToWithdraw;
            _account = account;
        }

        public void execute()
        {
            _account.Withdraw(_amountToWithdraw);
            _withdrawal = new Withdrawal(_account.AccountId, _amountToWithdraw);
            _account.TransactionsList.Add(_withdrawal);
        }

        public void undo()
        {
            _account.Deposit(_amountToWithdraw);
            _account.TransactionsList.Remove(_withdrawal);
        }
    }
}