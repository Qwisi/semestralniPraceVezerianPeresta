using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace semestralniPraceVezerianPeresta.Model
{
    internal class Worker
    {
         public int IdWorker { get; }
        public string FirstName { get; set; }
        public string SecondName{ get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}
