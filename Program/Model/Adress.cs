using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestralniPraceVezerianPeresta.Model
{
    internal class Adress
    {
       public int IdAdress { get; }
        public string City { get; set; }
        public string Street{ get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
