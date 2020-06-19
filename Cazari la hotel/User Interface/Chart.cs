using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cazari_la_hotel {
    public partial class Chart : Form {
        private const string MONEDA = "RON";

        private Color[] culoriDefault = {
            Color.FromArgb(66, 135, 245),
            Color.FromArgb(245, 66, 66),
            Color.FromArgb(114, 245, 66),
            Color.FromArgb(200, 66, 245),
            Color.FromArgb(245, 236, 66),
            Color.FromArgb(87, 176, 46), // vi
            Color.FromArgb(66, 245, 233),
            Color.FromArgb(245, 66, 66),
            Color.FromArgb(46, 79, 176),
            Color.FromArgb(171, 39, 129),
            Color.FromArgb(245, 66, 161),
            Color.FromArgb(176, 46, 46)  
        };

        //private List<Color> culoriRandom;

        private List<string> luni;// = new List<string> { "Ianuarie", "Februarie", "Decembrie" };
        private List<float> valori;// = new List<float> { 2345f, 23423.1f, 1231.13f };

        public Chart(List<string> luni, List<float> valori) {
            InitializeComponent();


            this.luni = luni;
            this.valori = valori;
        }
        private void Chart_Load(object sender, EventArgs e) {
            // Generare random
            /*culoriRandom = new List<Color>(); 
            Random rnd = new Random(); 
            foreach(var l in luni)
                culoriRandom.Add(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256))); */

            // Populare normala
        }

        private void chartPanel_Paint(object sender, PaintEventArgs e) {  
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality; 

            // Calculeaza dimensiunea si pozitia graficului
            int dim = Math.Min(chartPanel.Width, chartPanel.Height);
            if (dim <= 40) return; // nu se mai vede nimic de la 40 in jos...

            Pen pen = new Pen(new SolidBrush(Color.Black), 0.1f);
            Rectangle rect = new Rectangle{ 
                X = 5, 
                Y = 5, 
                Width = dim - 10, 
                Height = dim - 10 
            };
            if(chartPanel.Width > chartPanel.Height) rect.X = (chartPanel.Width - rect.Width) / 2;
            else rect.Y = (chartPanel.Height - rect.Height) / 2;

            // Deseneaza graficul 
            float unghi = 0;
            for (int i = 0; i < valori.Count; i++) {
                g.FillPie(new SolidBrush(culoriDefault[i]), rect, unghi, valori[i] / valori.Sum() * 360); 
                g.DrawPie(pen, rect, unghi, valori[i] / valori.Sum() * 360);

                unghi += valori[i] / valori.Sum() * 360;
            }
            g.DrawEllipse(pen, rect);

            // Scrie textul
            float unghiTotal = 0; // pt orientarea textului
            unghi = 0;
            g.ResetTransform();
            g.TranslateTransform((float)chartPanel.Width / 2, (float)chartPanel.Height / 2);
            for (int i = 0; i < valori.Count; i++) {
                // Roteste pana la jumatatea feliei din pie
                unghi = valori[i] / valori.Sum() * 360;
                unghiTotal += unghi/2;
                g.RotateTransform(unghi/2);

                // Calculeaza dimensiunea textului
                string str = luni[i].Substring(0, 3);
                Font fnt = new Font(FontFamily.GenericSansSerif, dim/20);
                SizeF strSize = g.MeasureString(str, fnt);

                float x = dim / 2 - strSize.Width - 5;
                float y = -strSize.Height / 2;

                // Scrie luna in pie (daca are loc ...)
                if (strSize.Height > 0) { 
                    if (unghiTotal > 90 && unghiTotal < 270)
                        scrieInvers(g, str, fnt, new SolidBrush(Color.Black), x, y, strSize.Width, strSize.Height);
                    else g.DrawString(str, fnt, new SolidBrush(Color.Black), x, y); 
                }
                // Roteste si cealalta jumatate
                g.RotateTransform(unghi / 2);
                unghiTotal += unghi / 2;

            }

        }  
        private void scrieInvers(Graphics g, string str, Font fnt, Brush brs, float x, float y, float width, float height) {
            g.TranslateTransform(x, y);
            g.TranslateTransform(width, height);

            g.RotateTransform(180);
            g.DrawString(str, fnt, brs, 0, 0);
            g.RotateTransform(-180);

            g.TranslateTransform(-width, -height);
            g.TranslateTransform(-x, -y);
        }
        private void groupBox2_Paint(object sender, PaintEventArgs e) { 
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
             
            for (int i = 0; i < luni.Count; i++) {
                g.FillRectangle(new SolidBrush(culoriDefault[i]), 5, (i+1) * 15 + 2, 10, 10);
                groupBox2.Controls.Add(new Label {
                    Text = luni[i],
                    Bounds = new Rectangle(20, (i+1)* 15, 60, 15)
                });

                groupBox2.Controls.Add(new Label {
                    Text = valori[i].ToString("N2") + $" {MONEDA}",
                    Bounds = new Rectangle(90, (i+1) * 15, 140, 15)
                }); 
            }

            g.DrawLine(new Pen(new SolidBrush(Color.LightGray)), 85, 15, 85, 15 * 13); 
        }

        private void mainSplitContainer_SplitterMoved(object sender, SplitterEventArgs e) {
            chartPanel.Invalidate();
        } 
        private void Chart_Resize(object sender, EventArgs e) {
            chartPanel.Invalidate();
        }

        private void imprimaToolStripMenuItem_Click(object sender, EventArgs e) {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("custom", mainSplitContainer.Width, mainSplitContainer.Height);
            pd.PrintPage += new PrintPageEventHandler(pd_print);

            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd; 
            dlg.ShowDialog();
        } 
        private void pd_print(object sender, PrintPageEventArgs e) {
            Graphics g = e.Graphics; 

            Bitmap bmp = new Bitmap(mainSplitContainer.Width, mainSplitContainer.Height);
            mainSplitContainer.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            g.DrawImage(bmp,0,0,bmp.Width  , bmp.Height  );
        }
    }
}
