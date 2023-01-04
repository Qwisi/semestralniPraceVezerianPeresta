namespace Program.Model
{
    public class Card : Payment
    {
        private string _bankName;

        public Card(PaymentsEnum paymentType, string bankName) : base(paymentType)
        {
            _bankName = bankName;
        }

        public string BankName
        {
            get => _bankName;
            set { _bankName = value; }
        }
    }
}
