using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registracija
{
    public class RegistrationException:Exception
    {
        public string Poruka { get; set; }
        public RegistrationException(string poruka)
        {
            Poruka = poruka;
        }
    }
}
