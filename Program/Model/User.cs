namespace Program.Model
{
    public class User
    {
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }

    }
}
