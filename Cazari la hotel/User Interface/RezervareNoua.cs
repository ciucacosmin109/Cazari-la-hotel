using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cazari_la_hotel {
    public partial class RezervareNoua : Form {
        private const string MONEDA = "RON";

        private List<Camera> camere;
        private List<Camera> camereRamase;
        private List<Rezervare> rezervari;

        public RezervareNoua(List<Camera> cam, List<Rezervare> rez) { // shallow copy - parametrii
            InitializeComponent();
            info_pretTotal.Text = $"0 {MONEDA}";

            camere = cam; // shallow copy
            rezervari = rez; // shallow copy

            rezervareDateTime.Value = DateTime.Now;
            restituireDateTime.Value = DateTime.Now.AddDays(1);
            this.rezervareDateTime.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);
            this.restituireDateTime.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);

            refreshCamere();
        }
        public void refreshCamere() { 
            nrBox.Items.Clear();
            // facem o copie a camerelor
            camereRamase = new List<Camera>();
            foreach (Camera c in camere)
                camereRamase.Add((Camera)c.Clone());

            // Stergem din copie ce e ocupat in perioada selectata
            for (int i = 0; i < camereRamase.Count; i++)
                for (int j = 0; j < rezervari.Count; j++)
                    if (camereRamase[i].Numar == rezervari[j].NrCamera)
                        // e libera in perioada selectata ?
                        if (rezervari[j].DataRestituire > rezervareDateTime.Value &&
                            rezervari[j].DataInchiriere < restituireDateTime.Value) {
                            camereRamase.RemoveAt(i);
                            i--;
                            break;
                        }

            // Adaugam camerele care libere in comboBox
            foreach (Camera c in camereRamase)
                nrBox.Items.Add("Nr " + (short)c + " | Etaj " + c.Etaj);

            // Daca au mai ramas camere selecteaz-o implicit pe prima
            if (nrBox.Items.Count > 0) {
                nrBox.SelectedIndex = 0;
                info_pretTotal.Text = (Convert.ToSingle(info_pretNoapte.Text) * (restituireDateTime.Value.AddHours(1) - rezervareDateTime.Value).Days).ToString("N2") + $" {MONEDA}";
            }
        }

        private void rezervaBtn_Click(object sender, EventArgs e) {
            errorProvider.Clear();
            bool ok = true;
            if (numeBox.Text.Length == 0) {
                errorProvider.SetError(numeBox, "Introduceti un nume!");
                ok = false;
            }
            if (cnpBox.Text.Length != 13) {
                errorProvider.SetError(cnpBox, "Introduceti un CNP valid!");
                ok = false;
            } else { 
                int an2 = Convert.ToInt32(cnpBox.Text.Substring(1, 2));
                if (DateTime.Now.Year - CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(an2) < 18) {
                    errorProvider.SetError(cnpBox, "Clientul trebuie sa fie major");
                    ok = false;
                }
            }
            if (nrBox.SelectedIndex == -1 || info_nr.Text == "-") {
                errorProvider.SetError(nrBox, "Selectati o camera!");
                ok = false;
            } 
            if(ok){
                int idMax = 0;
                if (rezervari.Count > 0)
                    idMax = rezervari.Max(r => r.Id);

                rezervari.Add(new Rezervare(
                    idMax + 1,
                    Convert.ToInt16(info_nr.Text), new Persoana(numeBox.Text, Convert.ToInt64(cnpBox.Text)),
                    rezervareDateTime.Value, restituireDateTime.Value,
                    Convert.ToUInt32(info_pretNoapte.Text) * Convert.ToUInt32((restituireDateTime.Value.AddHours(1) - rezervareDateTime.Value).Days)
                ));
                //refreshCamere();

                if (printCheckBox.Checked) {
                     
                    PrintDocument pd = new PrintDocument(); 
                    pd.PrintPage += new PrintPageEventHandler(pd_print);

                    PrintPreviewDialog dlg = new PrintPreviewDialog();
                    dlg.Document = pd;
                    dlg.ShowDialog(); 
                }

                // inchid dialogul cu rezultatul OK
                DialogResult = DialogResult.OK;
            }
        } 
        private void pd_print(object sender, PrintPageEventArgs e) {

            Bitmap dovada = new Bitmap(Properties.Resources.DovadaCazare);

            Graphics g = e.Graphics;
            g.DrawImage(dovada,-20,0);

            g.DrawString(info_nr.Text, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 198, 317);
            g.DrawString(info_etaj.Text, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 320, 317);
            g.DrawString(info_nrPers.Text, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 510, 317);
            g.DrawString(info_baieBuc.Text.Substring(0, 2), new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 725, 317);

            g.DrawString(info_baieBuc.Text.Substring(3, 2), new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 136, 347);
            g.DrawString(info_pretNoapte.Text + $" {MONEDA}", new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 358, 347);

            g.DrawString(numeBox.Text, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 170, 407);
            g.DrawString(cnpBox.Text, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 100, 437);

            g.DrawString(rezervareDateTime.Value.ToString("dd . MM . yyyy"), new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 210, 497);
            g.DrawString(restituireDateTime.Value.ToString("dd . MM . yyyy"), new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 405, 497);

            g.DrawString(info_pretTotal.Text, new Font("Arial", 15, FontStyle.Bold), new SolidBrush(Color.Black), 150, 527);


        }

        private void nrBox_SelectedIndexChanged(object sender, EventArgs e) {
            // Afisare info despre camera
            Camera c = camereRamase.ElementAt(nrBox.SelectedIndex);
            info_nr.Text = ((short)c).ToString(); // cast operator
            info_etaj.Text = c.Etaj.ToString();
            info_nrPers.Text = c.CapacitatePersoane.ToString();
            info_pretNoapte.Text = c.PretPeNoapte.ToString(); 

            info_baieBuc.Text = (c.AreBaie ? "Da" : "Nu") + "/" + (c.AreBucatarie ? "Da" : "Nu");

            info_pretTotal.Text = (Convert.ToSingle(info_pretNoapte.Text) * (restituireDateTime.Value.AddHours(1) - rezervareDateTime.Value).Days).ToString("N2") + $" {MONEDA}";
        }
         
        private void cnpBox_KeyPress(object sender, KeyPressEventArgs e) {
            if ( (e.KeyChar < '0' || e.KeyChar > '9') && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        private void numeBox_KeyPress(object sender, KeyPressEventArgs e) { 
            if ((char.ToUpper(e.KeyChar) < 'A' || char.ToUpper(e.KeyChar) > 'Z') && !" -".Contains(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dateTime_ValueChanged(object sender, EventArgs e) { 
            restituireDateTime.MinDate = rezervareDateTime.Value.AddDays(1); 
            refreshCamere();
        }

        private void cnpBox_Validating(object sender, CancelEventArgs e) {
            if (cnpBox.Text.Length == 13) {
                int an2 = Convert.ToInt32(cnpBox.Text.Substring(1, 2));
                if (DateTime.Now.Year - CultureInfo.CurrentCulture.Calendar.ToFourDigitYear(an2) >= 18) {
                    errorProvider.SetError(cnpBox,""); 
                    return;
                }
                errorProvider.SetError(cnpBox, "Clientul trebuie sa fie major");
            }else errorProvider.SetError(cnpBox, "Introduceti un CNP valid!");
        }

        private void numeBox_Validating(object sender, CancelEventArgs e) {
            if(numeBox.Text.Length != 0) {
                errorProvider.SetError(numeBox, "");
                return;
            }else errorProvider.SetError(numeBox, "Introduceti un nume!");
        }
    }
}
