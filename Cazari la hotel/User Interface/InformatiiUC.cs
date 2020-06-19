using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cazari_la_hotel {
    public partial class InformatiiUC : UserControl {
        public InformatiiUC() {
            InitializeComponent();
        }
        public void update(DateTime data, int camereLibere, int totalComere, int nrRezervari_LunaCurenta) { 
            info_data.Text = data.ToString("dd MMMM yyyy");
            info_libere.Text = camereLibere + "/" + totalComere;
            info_ocupate.Text = (totalComere - camereLibere) + "/" + totalComere;
             
            info_rezervariLC.Text = nrRezervari_LunaCurenta.ToString();
        }
    }
}
