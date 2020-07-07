using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using INSform;

namespace Ponude
{
    public partial class UCRezevacija : UserControl
    {
        private Rezervacija rezervacija = null;
        Iform Iform;
        public UCRezevacija(Iform novo)
        {
            InitializeComponent();
            Iform = novo;
        }

        public void LoadPonuda(Rezervacija rezervacija)
        {
            this.rezervacija = rezervacija;
        }
    }
}
