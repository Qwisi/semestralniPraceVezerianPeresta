using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestralniPraceVezerianPeresta.Model
{
    public class Klient
    {
        public int IdKlient { get; }
        public string FirstName { get; set; }
        public string SecondName{ get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public int CountOfOrders { get; set; }
        public int TotalCostOfOrders { get; set; }

    }
}
