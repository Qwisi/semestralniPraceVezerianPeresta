namespace Program.Model
{
    public class Adress : SomeTable
    {
        private string _city;
        public string City
        {
            get => _city;
            set { _city = value; }
        }

        private string _street;
        public string Street
        {
            get => _street;
            set { _street = value; }
        }
        private int _houseNumber;
        public int HouseNumber
        {
            get => _houseNumber;
            set { _houseNumber = value; }
        }

        private int _flatNumber;
        public int FlatNumber
        {
            get => _flatNumber;
            set { _flatNumber = value; }
        }

        public Adress(string city, string street, int houseNumber, int flatNumber)
        {
            _city = city;
            _street = street;
            _houseNumber = houseNumber;
            _flatNumber = flatNumber;
        }

        public Adress()
        {

        }
    }
}
