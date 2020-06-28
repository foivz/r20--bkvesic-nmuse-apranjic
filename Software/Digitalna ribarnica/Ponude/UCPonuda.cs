using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ponude
{
    public partial class UCPonuda : UserControl
    {
        private Ponuda ponuda = null;
        public UCPonuda()
        {
            InitializeComponent();
        }

        public void LoadPonuda(Ponuda ponuda)
        {
            this.ponuda = ponuda;
        }
    }
}
