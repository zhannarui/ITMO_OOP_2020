namespace Lab5V2
{
    public class TransferCommand : ICommand
    {
        private readonly double _amountToTransfer;
        private readonly IAccount _sourceAccount;
        private readonly IAccount _destinationAccount;
        private Transfer _transfer;

        public TransferCommand(IAccount sourceAccount, IAccount destinationAccount, double amountToTransfer)
        {
            _amountToTransfer = amountToTransfer;
            _sourceAccount = sourceAccount;
            _destinationAccount = destinationAccount;
        }

        public void execute()
        {
            _sourceAccount.Withdraw(_amountToTransfer);
            _destinationAccount.Deposit(_amountToTransfer);
            _transfer = new Transfer(_sourceAccount, _destinationAccount, _amountToTransfer);
            _sourceAccount.TransactionsList.Add(_transfer);
            _destinationAccount.TransactionsList.Add(_transfer);
        }

        public void undo()
        {
            _sourceAccount.Deposit(_amountToTransfer);
            _destinationAccount.Withdraw(_amountToTransfer);
            _sourceAccount.TransactionsList.Remove(_transfer);
            _destinationAccount.TransactionsList.Remove(_transfer);
        }
    }
}