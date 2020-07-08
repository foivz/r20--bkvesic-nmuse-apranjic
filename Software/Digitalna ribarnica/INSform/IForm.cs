using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prijava;
namespace INSform
{
    public interface Iform
    {
        Form nova { get; set; }

        Panel panel { get; set; }

        Autentifikator autentifikator { get; set; }
    }
}
