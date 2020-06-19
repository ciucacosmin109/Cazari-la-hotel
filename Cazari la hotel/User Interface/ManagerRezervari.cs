using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cazari_la_hotel {
    public partial class ManagerRezervari : Form {
        private const string MONEDA = "RON";

        private Timer clearStatus;
        private List<Camera> camere;
        private List<Rezervare> rezervari;

        public ManagerRezervari(List<Camera> cam, List<Rezervare> rez) {
            InitializeComponent();
            this.Activated += (s, a) => actualizeazaInfomatii(); 

            clearStatus = new Timer();
            camere = cam;
            rezervari = rez;
            repopulareLvRezervari();
        }
        private void repopulareLvRezervari() {
            rezervariLV.Items.Clear();
            foreach (Rezervare r in rezervari) {
                ListViewItem itm = new ListViewItem(r.Id.ToString());
                itm.SubItems.Add(r.NrCamera.ToString());
                itm.SubItems.Add(r.Pers.Nume);
                itm.SubItems.Add(r.Pers.CNP.ToString());
                itm.SubItems.Add(r.DataInchiriere.ToString("dd/MM/yyyy"));
                itm.SubItems.Add(r.DataRestituire.ToString("dd/MM/yyyy"));
                itm.SubItems.Add(r.Pret.ToString("N2") + $" {MONEDA}");

                rezervariLV.Items.Add(itm);
            }
            actualizeazaInfomatii();
        }
        private void actualizeazaInfomatii() { 
            DateTime dt = DateTime.Now;

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

        private void preiaRezervarileDinBdToolStripMenuItem_Click(object sender, EventArgs e) { 
            Functii.citireRezervariDb(ref rezervari);
            repopulareLvRezervari();
            statusLabel.Text = "Rezervarile au fost preluate din baza de date !";
            statusLabel.ForeColor = Color.Black;
        } 
        private void salveazaRezervarileInBdToolStripMenuItem_Click(object sender, EventArgs e) { 
            Functii.rescrieRezervariDb(rezervari);
            statusLabel.Text = "Rezervarile au fost salvate in baza de date !";
            statusLabel.ForeColor = Color.Black;
        }

        private void importaRezervariDinFisierExternToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = Environment.CurrentDirectory;
            //dlg.FileName = "Rezervari.txt";

            if (dlg.ShowDialog() == DialogResult.OK) {
                Functii.citireRezervari(ref rezervari, dlg.FileName);
                repopulareLvRezervari();
                statusLabel.Text = "Rezervarile au fost importate din fisier !";
                statusLabel.ForeColor = Color.Black;
            }
            else {
                statusLabel.Text = "Importare din fisier anulata !";
                statusLabel.ForeColor = Color.Red;
            }
        } 
        private void exportaRezervariInFisierExternToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = Environment.CurrentDirectory;
            //dlg.FileName = "Rezervari.txt";

            if (dlg.ShowDialog() == DialogResult.OK) {
                Functii.salvareRezervari(rezervari, dlg.FileName);
                statusLabel.Text = "Rezervarile au fost exportate in fisier !";
                statusLabel.ForeColor = Color.Black;
            }
            else {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Exportare in fisier anulata !";
            }
        }

        private void stergeRezervareaToolStripMenuItem_Click(object sender, EventArgs e) { 
            if (rezervariLV.SelectedItems.Count != 1) {
                statusLabel.Text = "Selectati o rezervare !";
                statusLabel.ForeColor = Color.Red;
                return;
            }
            int idx = rezervariLV.SelectedIndices[0];

            rezervariLV.Items.RemoveAt(idx);
            rezervari.RemoveAt(idx); 
            actualizeazaInfomatii();

            statusLabel.Text = "Rezervarea a fost stearsa !";
            statusLabel.ForeColor = Color.Black;
        } 
        private void deleteButton_Click(object sender, EventArgs e) => stergeRezervareaToolStripMenuItem_Click(sender, e);

        private void newButton_Click(object sender, EventArgs e) {
            RezervareNoua rezervareNoua = new RezervareNoua(camere, rezervari);
            if (rezervareNoua.ShowDialog() == DialogResult.OK) { 
                repopulareLvRezervari();

                Functii.addOrUpdate_Db(rezervari.Last());
                //Functii.rescrieCamereDb(camere);

                statusLabel.Text = "Rezervarea a fost adaugata !";
                statusLabel.ForeColor = Color.Black;
            }
        }

        private void rezervariLV_MouseMove(object sender, MouseEventArgs e) {
            // Pt drag and drop
            // Am folosit MouseMove cu conditia ca butonul din stanga sa fie apasat
            // Pt ca MoseDown (la listView) se intampla inainte ca itemul sa fie selectat 

            if (e.Button == MouseButtons.Left && rezervariLV.SelectedIndices.Count != 0)
                rezervariLV.DoDragDrop(rezervariLV.SelectedIndices.Cast<int>().First(), DragDropEffects.Copy);
        } 
        private void deleteButton_DragEnter(object sender, DragEventArgs e) { 
            // Am pus aici conditia cu getDataPresent pt a se schimba iconita in interzis
            // daca trag altceva

            if (e.Data.GetDataPresent(typeof(int)) && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        } 
        private void deleteButton_DragDrop(object sender, DragEventArgs e) {  
            int index = (int)e.Data.GetData(typeof(int));

            rezervariLV.Items.RemoveAt(index);
            rezervari.RemoveAt(index);

            statusLabel.Text = "Rezervarea a fost stearsa !"; 
            statusLabel.ForeColor = Color.Black;
        }

        private void statusLabel_TextChanged(object sender, EventArgs e) { 
            clearStatus.Stop();
            clearStatus.Interval = 1700;
            clearStatus.Tick += (snd, ev) => {
                statusLabel.Text = "...";
                statusLabel.ForeColor = Color.Black;
                clearStatus.Stop();
            };
            clearStatus.Start();
        }
         
    }
}
