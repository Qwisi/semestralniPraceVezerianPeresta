namespace Program.Model
{
    public class Klient
    {
        public int IdKlient { get; }
        public string FirstName { get; set; }
        public string LastName{ get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int CountOfOrders { get; set; }
        public int TotalCostOfOrders { get; set; }

    }
}
