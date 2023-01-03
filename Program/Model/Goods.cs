namespace Program.Model
{
    public class Goods : SomeTable
    {
        private string _type;
        public string Type
        {
            get => _type;
            set { _type = value; }
        }

        private string _firm;
        public string Firm
        {
            get => _firm;
            set { _firm = value; }
        }
        private int _price;
        public int Price
        {
            get => _price;
            set { _price = value; }
        }

        private string _material;
        public string Material
        {
            get => _material;
            set { _material = value; }
        }

        public Goods(string type, string firm, int price, string material)
        {
            _type = type;
            _firm = firm;
            _price = price;
            _material = material;
        }
    }
}
