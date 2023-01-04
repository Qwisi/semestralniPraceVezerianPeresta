namespace Program.Model
{
    public class Insurance : SomeTable
    {

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; }
        }


        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; }
        }

        public Insurance(string name, string phoneNumber)
        {
            _name = name;
            _phoneNumber = phoneNumber;
        }

    }
}
