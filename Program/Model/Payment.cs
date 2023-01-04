namespace Program.Model
{
    public class Payment : SomeTable
    {
        private PaymentsEnum _paymentType;
        public PaymentsEnum PaymentType
        {
            get => _paymentType;
            set { _paymentType = value; }
        }

        public Payment(PaymentsEnum paymentType)
        {
            _paymentType = paymentType;
        }
    }
}
