using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Cazari_la_hotel { 
    public partial class ManagerCamere : Form {
        private const string MONEDA = "RON";

        private Timer clearStatus;
        public List<Camera> camere;

        public ManagerCamere(List<Camera> cam) {
            InitializeComponent();
            clearStatus = new Timer();
            camere = cam;

            repopulareLvCamere();
        } 
        private void repopulareLvCamere() {
            camereLV.Items.Clear();
            foreach (Camera ca in camere) {
                ListViewItem itm = new ListViewItem(ca.Numar.ToString());
                itm.SubItems.Add(ca.Etaj.ToString());
                itm.SubItems.Add(ca.CapacitatePersoane.ToString()+" persoane");
                itm.SubItems.Add(ca.AreBaie ? "Da" : "Nu");
                itm.SubItems.Add(ca.AreBucatarie ? "Da" : "Nu");
                itm.SubItems.Add(ca.PretPeNoapte.ToString("N2") + " " + MONEDA);

                camereLV.Items.Add(itm);
            }
        }

        private void adaugareBtn_Click(object sender, EventArgs e) {
            if(add_nr.Value == 0 || add_pret.Value == 0) { 
                statusLabel.Text = "Introduceti date valide !";
                statusLabel.ForeColor = Color.Red; 
                return;
            }
            Camera ca = new Camera(
                (short)add_nr.Value, (byte)add_etaj.Value, (uint)add_pers.Value,
                add_baie.Checked, add_bucatarie.Checked, (uint)add_pret.Value
            );

            // Daca exista camera cu acest nr, se va modifica
            int i;
            for (i = 0; i < camere.Count; i++) { 
                if (camere[i].Numar == add_nr.Value) {
                    camere[i] = ca;
                    break;
                }
            }

            if (i == camere.Count) { // a fost adaugata
                // adauga in ListView
                ListViewItem itm = new ListViewItem(ca.Numar.ToString());
                itm.SubItems.Add(ca.Etaj.ToString());
                itm.SubItems.Add(ca.CapacitatePersoane.ToString() + " persoane");
                itm.SubItems.Add(ca.AreBaie ? "Da" : "Nu");
                itm.SubItems.Add(ca.AreBucatarie ? "Da" : "Nu");
                itm.SubItems.Add(ca.PretPeNoapte.ToString("N2") + " " + MONEDA);

                camereLV.Items.Add(itm);

                // adauga in lista
                camere.Add(ca);

                statusLabel.Text = "Camera a fost adaugata !";
                statusLabel.ForeColor = Color.Black;
            } else {// a fost modificata
                repopulareLvCamere(); 
                statusLabel.Text = "Camera a fost modificata !";
                statusLabel.ForeColor = Color.Black;
            }
        }

        private void preiaCamereleDinBdToolStripMenuItem_Click(object sender, EventArgs e) {
            Functii.citireCamereDb(ref camere);
            // transmit prin referinta pt a avea posibilitatea de a modifica si obiectul nu doar continutul lui

            repopulareLvCamere();
            statusLabel.Text = "Camerele au fost preluate din baza de date !";
            statusLabel.ForeColor = Color.Black;
        } 
        private void savleazaCamereleInBdToolStripMenuItem_Click(object sender, EventArgs e) {
            Functii.rescrieCamereDb(camere);
            statusLabel.Text = "Camerele au fost salvate in baza de date !";
            statusLabel.ForeColor = Color.Black;
        } 

        private void importaCamereDinFisierExternToolStripMenuItem_Click(object sender, EventArgs e) { 
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = Environment.CurrentDirectory;
            //dlg.FileName = "Camere.txt";

            if (dlg.ShowDialog() == DialogResult.OK) {
                Functii.citireCamere(ref camere, dlg.FileName);

                repopulareLvCamere();
                statusLabel.Text = "Camerele au fost importate din fisier !";
                statusLabel.ForeColor = Color.Black;
            }
            else {
                statusLabel.Text = "Importare din fisier anulata !";
                statusLabel.ForeColor = Color.Red;
            }
        }
        private void exportaCamereInFisierExternToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = Environment.CurrentDirectory;
            //dlg.FileName = "Camere.txt";

            if (dlg.ShowDialog() == DialogResult.OK) {
                Functii.salvareCamere(camere, dlg.FileName);
                statusLabel.Text = "Camerele au fost exportate in fisier !";
                statusLabel.ForeColor = Color.Black;
            }
            else {
                statusLabel.Text = "Exportare in fisier anulata !";
                statusLabel.ForeColor = Color.Red;
            }
        }

        private void modificaToolStripMenuItem_Click(object sender, EventArgs e) {
            if (camereLV.SelectedItems.Count != 1) {
                statusLabel.Text = "Selectati o camera !";
                statusLabel.ForeColor = Color.Red;
                return;
            }

            // Pune prima camera bifata la editare 
            int idx = camereLV.SelectedIndices[0]; 
            add_nr.Value = camere[idx].Numar;
            add_etaj.Value = camere[idx].Etaj;
            add_pers.Value = camere[idx].CapacitatePersoane;
            add_baie.Checked = camere[idx].AreBaie;
            add_bucatarie.Checked = camere[idx].AreBucatarie;
            add_pret.Value = (decimal)camere[idx].PretPeNoapte;

            statusLabel.Text = "Modificati datele camerei !";
            statusLabel.ForeColor = Color.Blue;

        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e) {
            if (camereLV.SelectedItems.Count != 1) {
                statusLabel.Text = "Selectati o camera !";
                statusLabel.ForeColor = Color.Red;
                return;
            }
            int idx = camereLV.SelectedIndices[0];
             
            camereLV.Items.RemoveAt(idx);
            camere.RemoveAt(idx); 

            statusLabel.Text = "Camera a fost stearsa !";
            statusLabel.ForeColor = Color.Black;
        } 
        private void stergereBtn_Click(object sender, EventArgs e) {
            stergeToolStripMenuItem_Click(sender, e);
        }

        private void camereLV_MouseMove(object sender, MouseEventArgs e) { 
            if (e.Button == MouseButtons.Left && camereLV.SelectedIndices.Count != 0)
                camereLV.DoDragDrop(camereLV.SelectedIndices.Cast<int>().First(), DragDropEffects.Copy);
        } 
        private void stergereBtn_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(typeof(int)) && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        } 
        private void stergereBtn_DragDrop(object sender, DragEventArgs e) { 
            int index = (int)e.Data.GetData(typeof(int));

            camereLV.Items.RemoveAt(index);
            camere.RemoveAt(index);

            statusLabel.Text = "Camera a fost stearsa !";
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
