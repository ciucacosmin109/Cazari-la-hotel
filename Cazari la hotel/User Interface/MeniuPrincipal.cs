using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cazari_la_hotel {
    public partial class MeniuPrincipal : Form {
        private List<Camera> camere;
        private List<Rezervare> rezervari;

        public MeniuPrincipal() {
            InitializeComponent();
            //Functii.citireCamere(ref camere,"Camere.txt");
            //Functii.citireRezervari(ref rezervari,"Rezervari.txt");

            Functii.citireCamereDb(ref camere);
            Functii.citireRezervariDb(ref rezervari);

            actualizareInfoPrincipale();

        } 
        private void actualizareInfoPrincipale() {
            DateTime dt = DateTime.Now;

            //int ocupate = camere.Join(rezervari, c => c.Numar, r => r.NrCamera, (c, r) => new { di = r.DataInchiriere, dr = r.DataRestituire }).Where(a => a.di < dt && dt <= a.dr).Count();
            /*int ocupate = (from camera in camere
                            join rezervare in rezervari
                            on camera.Numar equals rezervare.NrCamera
                            where rezervare.DataInchiriere < dt && dt <= rezervare.DataRestituire
                            select new { }).Count();*/
            int ocupate = 0;
            for (int i = 0; i < camere.Count; i++) {
                for (int j = 0; j < rezervari.Count; j++) {
                    if (camere[i].Numar == rezervari[j].NrCamera) {
                        if (rezervari[j].DataInchiriere < dt && dt <= rezervari[j].DataRestituire) {
                            ocupate++;
                            break;
                        }
                    }
                }
            }
            int nrRez = rezervari.Select(r => r.DataInchiriere.Month == dt.Month).Count();
            informatii.update(dt, camere.Count - ocupate, camere.Count, nrRez); 
        }
        private void MeniuPrincipal_Activated(object sender, EventArgs e) => actualizareInfoPrincipale(); 

        private void rezBtn_Click(object sender, EventArgs e) {
            RezervareNoua rezervareNoua = new RezervareNoua(camere, rezervari);
            if (rezervareNoua.ShowDialog() == DialogResult.OK) {
                // Am facut o rezervare noua => SALVEZ IN BD
                Functii.addOrUpdate_Db(rezervari.Last());
                Functii.addOrUpdate_Db(camere.Last());
            } 
        }
        private void chartBtn_Click(object sender, EventArgs e) {
            List<string> luni = new List<string>();
            List<float> valori = new List<float>();

            for(int i = 1; i <= 12; i++) {
                float x = rezervari
                         .Where(r => r.DataInchiriere.Month == i && r.DataInchiriere.Year == DateTime.Now.Year)
                         .Select(r => r.Pret)
                         .Sum(p => p);
                if (x != 0) {
                    luni.Add((new DateTime(2000, i, 1)).ToString("MMMM"));
                    valori.Add(x);
                }
            }

            if (luni.Count == 0) {
                MessageBox.Show("Rezervari insuficiente");
                return;
            }

            Chart chart = new Chart(luni, valori);
            chart.ShowDialog();
        }

        private void mgrBtn_Click(object sender, EventArgs e) {
            ManagerCamere managerCamere = new ManagerCamere(camere);
            managerCamere.ShowDialog(); 

            Functii.rescrieCamereDb(camere); 
        } 
        private void mgrRezBtn_Click(object sender, EventArgs e) {
            ManagerRezervari managerRezervari = new ManagerRezervari(camere, rezervari);
            managerRezervari.ShowDialog();

            Functii.rescrieRezervariDb(rezervari);
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit(); 
        private void despreToolStripMenuItem_Click(object sender, EventArgs e) => (new AboutBox()).ShowDialog(); 
         

    }
}
