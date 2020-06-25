using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokacije
{
    public class Lokacije
    {
        [DisplayName("ID lokacije")]
        public int id { get; set; }

        [DisplayName("Naziv")]
        public string Naziv { get; set; }

    }
}
