namespace Program.Model
{
    public class Сlient : SomeTable
    {
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set { _firstName = value; }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set { _lastName = value; }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; }
        }

        public Сlient(string firstName, string lastName, string phoneNumber, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _email = email;
        }
    }
}
