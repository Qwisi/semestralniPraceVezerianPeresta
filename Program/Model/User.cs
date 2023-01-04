namespace Program.Model
{
    public class User : SomeTable
    {
        /*private UsersEnum _userType;
        public UsersEnum UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }*/

        private string _email;
        public string Email
        {
            get => _email;
            set {  _email = value; }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set {  _password = value; }
        }

        public User(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public User() { }

    }
}
