using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cazari_la_hotel {
    static class Program {
        public static string DB_LOCATION = "Database.accdb";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Verifica daca exista fisierul cu configuratii
            string dbLocation; 
            if (ConfigurationManager.AppSettings.Count != 0)
                dbLocation = ConfigurationManager.AppSettings["dbLocation"];
            else dbLocation = DB_LOCATION;

            // Copiaza baza de date daca nu exista
            if (!File.Exists(dbLocation)) { 
                try {
                    File.WriteAllBytes(dbLocation, Properties.Resources.Database);
                } 
                catch (Exception e) {
                    MessageBox.Show(e.Message);
                    return;
                }
            }
            //MessageBox.Show(DateTime.Now.ToString());

            Application.Run(new MeniuPrincipal());
        }
    }
}
