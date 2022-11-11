using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestralniPraceVezerianPeresta.Model
{
    internal class Goods
    {
         public int IdGoods { get; }
        public string Type { get; set; }
        public string Firm{ get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string Material{ get; set; }
    }
}
