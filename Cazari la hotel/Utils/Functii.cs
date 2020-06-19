using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cazari_la_hotel {
    public static class Functii {
        private const string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = ";

        // Camere
        public static void citireCamere(ref List<Camera> camere, string file/* = "Camere.txt"*/) {
            if (camere == null)
                camere = new List<Camera>();

            try {
                StreamReader sr = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read));
                string fisier = sr.ReadToEnd();
                foreach (string linie in fisier.Split(Environment.NewLine.ToArray())) {
                    string[] cam = linie.Split(',');
                    if (cam.Length != 6) continue;

                    try {
                        Camera c = new Camera(
                            Convert.ToInt16(cam[0]),
                            Convert.ToByte(cam[1]),
                            Convert.ToUInt32(cam[2]),
                            Convert.ToBoolean(cam[3]),
                            Convert.ToBoolean(cam[4]),
                            Convert.ToUInt32(cam[5])
                        );
                        camere.RemoveAll(ca => ca.Numar == c.Numar);
                        camere.Add(c);
                    }
                    catch (FormatException ex) {
                        MessageBox.Show("Eroare de format\n\n" + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                sr.Close();
            }
            catch (FileNotFoundException) { } //se va returna o lista goala
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void salvareCamere(List<Camera> camere, string file/* = "Camere.txt"*/) {
            try {
                FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                foreach (Camera c in camere)
                    sw.WriteLine(c.ToTxt());

                sw.Close();
                fs.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void citireCamereDb(ref List<Camera> camere, string db = null) {
            if (db == null) {
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION;
            }

            if (camere != null) camere.Clear();
            else camere = new List<Camera>();

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                OleDbCommand com = new OleDbCommand("SELECT * FROM Camere");
                com.Connection = connection;

                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    Camera c = new Camera(
                        Convert.ToInt16(reader["Numar"]),
                        Convert.ToByte(reader["Etaj"]),
                        Convert.ToUInt32(reader["Capacitate"]),
                        Convert.ToBoolean(reader["Baie"]),
                        Convert.ToBoolean(reader["Bucatarie"]),
                        Convert.ToUInt32(reader["Pret_noapte"])
                    );
                    camere.RemoveAll(ca => ca.Numar == c.Numar);
                    camere.Add(c);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                connection.Close();
            }
        }
        /*public static void rescrieCamereDbOld(List<Camera> camere, string db = null) {
            if (db == null)
                db = ConfigurationManager.AppSettings["dbLocation"];

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();

                //short[] nrs = camere.Select(c => c.Numar).ToArray(); 
                OleDbCommand delCom = new OleDbCommand("DELETE FROM Camere");// WHERE Numar NOT IN (" + String.Join(",", nrs) + ")");
                delCom.Connection = connection;
                delCom.ExecuteNonQuery();

                foreach(Camera cam in camere) {
                    OleDbCommand insCom = new OleDbCommand();
                    insCom.Connection = connection;
                    insCom.CommandText = "insert into camere values(?, ?, ?, ?, ?, ?)";
                    insCom.Parameters.Add("Numar", OleDbType.Integer).Value = cam.Numar;
                    insCom.Parameters.Add("Etaj", OleDbType.Integer).Value = cam.Etaj;
                    insCom.Parameters.Add("Capacitate", OleDbType.Integer).Value = cam.CapacitatePersoane;
                    insCom.Parameters.Add("Baie", OleDbType.Boolean).Value = cam.AreBaie;
                    insCom.Parameters.Add("Bucatarie", OleDbType.Boolean).Value = cam.AreBucatarie;
                    insCom.Parameters.Add("Pret_noapte", OleDbType.Integer).Value = cam.PretPeNoapte;
                    insCom.ExecuteNonQuery(); 
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();
            }
        }*/
        public static void rescrieCamereDb(List<Camera> camere, string db = null) {
            if (db == null) {            
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION; 
            }

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                short[] nrs = camere.Select(c => c.Numar).ToArray();
                OleDbCommand delCom;
                if (nrs.Count() != 0)
                    delCom = new OleDbCommand("DELETE FROM Camere WHERE Numar NOT IN (" + String.Join(",", nrs) + ")", connection);
                else delCom = new OleDbCommand("DELETE FROM Camere",connection);
                delCom.ExecuteNonQuery();

                foreach (Camera cam in camere) { 
                    OleDbCommand selCom = new OleDbCommand("SELECT COUNT(*) FROM Camere WHERE Numar = ?");
                    selCom.Parameters.Add("Numar", OleDbType.Integer).Value = cam.Numar;
                    selCom.Connection = connection;
                    int rowCount = (int)selCom.ExecuteScalar();

                    OleDbCommand command;
                    if (rowCount == 0) {
                        // INSERT command
                        command = new OleDbCommand("INSERT INTO Camere VALUES(?, ?, ?, ?, ?, ?)", connection);
                        command.Parameters.Add("@nr", OleDbType.Integer).Value = cam.Numar;
                        command.Parameters.Add("@etaj", OleDbType.Integer).Value = cam.Etaj;
                        command.Parameters.Add("@cap", OleDbType.Integer).Value = cam.CapacitatePersoane;
                        command.Parameters.Add("@baie", OleDbType.Boolean).Value = cam.AreBaie;
                        command.Parameters.Add("@bucatarie", OleDbType.Boolean).Value = cam.AreBucatarie;
                        command.Parameters.Add("@pret_n", OleDbType.Integer).Value = cam.PretPeNoapte;
                    }
                    else {
                        // UPDATE command
                        command = new OleDbCommand("UPDATE Camere SET " +
                       "Etaj = ?, Capacitate = ?, Baie = ?," +
                       "Bucatarie = ?, Pret_noapte = ? " +
                       "WHERE Numar = ?", connection);
                        command.Parameters.Add("@etaj", OleDbType.Integer).Value = cam.Etaj;
                        command.Parameters.Add("@cap", OleDbType.Integer).Value = cam.CapacitatePersoane;
                        command.Parameters.Add("@baie", OleDbType.Boolean).Value = cam.AreBaie;
                        command.Parameters.Add("@bucatarie", OleDbType.Boolean).Value = cam.AreBucatarie;
                        command.Parameters.Add("@pret_n", OleDbType.Integer).Value = cam.PretPeNoapte;
                        command.Parameters.Add("@nr", OleDbType.Integer).Value = cam.Numar;
                    }
                     
                    command.ExecuteNonQuery(); 
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();
            }
        }

        public static void addOrUpdate_Db(Camera cam, string db = null) {
            if (db == null) {
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION;
            }

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                OleDbCommand selCom = new OleDbCommand("SELECT COUNT(*) FROM Camere WHERE Numar = ?",connection);
                selCom.Parameters.Add("Numar", OleDbType.Integer).Value = cam.Numar; 
                int rowCount = (int)selCom.ExecuteScalar();

                OleDbCommand command;
                if (rowCount == 0) {
                    // INSERT
                    command = new OleDbCommand("INSERT INTO Camere VALUES(?, ?, ?, ?, ?, ?)", connection);
                    command.Parameters.Add("@nr", OleDbType.Integer).Value = cam.Numar;
                    command.Parameters.Add("@etaj", OleDbType.Integer).Value = cam.Etaj;
                    command.Parameters.Add("@cap", OleDbType.Integer).Value = cam.CapacitatePersoane;
                    command.Parameters.Add("@baie", OleDbType.Boolean).Value = cam.AreBaie;
                    command.Parameters.Add("@bucatarie", OleDbType.Boolean).Value = cam.AreBucatarie;
                    command.Parameters.Add("@pret_n", OleDbType.Integer).Value = cam.PretPeNoapte;
                }
                else {
                    // UPDATE
                    command = new OleDbCommand("UPDATE Camere SET " +
                     "Etaj = ?, Capacitate = ?, Baie = ?," +
                     "Bucatarie = ?, Pret_noapte = ? " +
                     "WHERE Numar = ?", connection); 
                    command.Parameters.Add("@etaj", OleDbType.Integer).Value = cam.Etaj;
                    command.Parameters.Add("@cap", OleDbType.Integer).Value = cam.CapacitatePersoane;
                    command.Parameters.Add("@baie", OleDbType.Boolean).Value = cam.AreBaie;
                    command.Parameters.Add("@bucatarie", OleDbType.Boolean).Value = cam.AreBucatarie;
                    command.Parameters.Add("@pret_n", OleDbType.Integer).Value = cam.PretPeNoapte;
                    command.Parameters.Add("@nr", OleDbType.Integer).Value = cam.Numar; 
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();
            }
        }
        public static void delete_Db(Camera cam, string db = null) {
            if (db == null) {
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION;
            }

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                OleDbCommand selCom = new OleDbCommand("DELETE FROM Camere WHERE Numar = ?", connection);
                selCom.Parameters.Add("Numar", OleDbType.Integer).Value = cam.Numar; 
                selCom.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();
            } 
        }

        // Rezervari
        public static void citireRezervari(ref List<Rezervare> rezervari, string file) {
            if (rezervari == null)
                rezervari = new List<Rezervare>();

            try {
                StreamReader sr = new StreamReader(new FileStream(file, FileMode.Open, FileAccess.Read));
                string fisier = sr.ReadToEnd();
                foreach (string linie in fisier.Split(Environment.NewLine.ToArray())) {
                    string[] rez = linie.Split(',');
                    if (rez.Length != 7) continue;

                    try {
                        Rezervare rz = new Rezervare(
                            Convert.ToInt32(rez[0]),
                            Convert.ToInt16(rez[1]),
                            new Persoana(rez[2], Convert.ToInt64(rez[3])),
                            Convert.ToDateTime(rez[4]),
                            Convert.ToDateTime(rez[5]),
                            Convert.ToUInt32(rez[6])
                        ); 
                        rezervari.RemoveAll(r => r.Id == rz.Id); 
                        rezervari.Add(rz);
                    } catch (FormatException ex) {
                        MessageBox.Show("Eroare de format\n\n" + ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                sr.Close();
            }catch(FileNotFoundException) { }
            catch(Exception ex) {
                MessageBox.Show( ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }
        public static void salvareRezervari(List<Rezervare> rezervari, string file) {
            try {
                FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                foreach (Rezervare r in rezervari)
                    sw.WriteLine(r.ToTxt());

                sw.Close();
                fs.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void citireRezervariDb(ref List<Rezervare> rezervari, string db = null) {
            if (db == null) {
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION;
            }

            if (rezervari != null) rezervari.Clear();
            else rezervari = new List<Rezervare>();

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                OleDbCommand com = new OleDbCommand("SELECT * FROM REZERVARI");
                com.Connection = connection;

                OleDbDataReader reader = com.ExecuteReader();
                while (reader.Read()) {
                    Rezervare rz = new Rezervare(
                        Convert.ToInt32(reader["Id"]),
                        Convert.ToInt16(reader["Nr_camera"]),
                        new Persoana(
                            reader["Nume_persoana"].ToString(),
                            Convert.ToInt64(reader["Cnp_persoana"])
                        ),
                        Convert.ToDateTime(reader["Data_rezervare"]),
                        Convert.ToDateTime(reader["Data_restituire"]),
                        Convert.ToUInt32(reader["Pret_total"])
                    );

                    rezervari.RemoveAll(r => r.Id == rz.Id);
                    rezervari.Add(rz);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                connection.Close();
            }
        }
        public static void rescrieRezervariDb(List<Rezervare> rezervari, string db = null) {
            if (db == null) {
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION;
            }

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                int[] ids = rezervari.Select(c => c.Id).ToArray();
                OleDbCommand delCom;
                if (ids.Count() != 0)
                    delCom = new OleDbCommand("DELETE FROM Rezervari WHERE Id NOT IN (" + String.Join(",", ids) + ")", connection);
                else delCom = new OleDbCommand("DELETE FROM Rezervari",connection);
                delCom.ExecuteNonQuery();

                foreach (Rezervare rez in rezervari) {
                    OleDbCommand selCom = new OleDbCommand("SELECT COUNT(*) FROM Rezervari WHERE Id = ?");
                    selCom.Parameters.Add("Id", OleDbType.Integer).Value = rez.Id;
                    selCom.Connection = connection;
                    int rowCount = (int)selCom.ExecuteScalar();

                    OleDbCommand command;
                    if (rowCount == 0) {
                        command = new OleDbCommand("INSERT INTO Rezervari VALUES(@id, @nr_cam, @nume_p, @cnp_p, @data_rez, @data_rest, @pret_t)", connection);
                         
                        command.Parameters.Add("@id", OleDbType.Integer).Value = rez.Id;
                        command.Parameters.Add("@nr_cam", OleDbType.Integer).Value = rez.NrCamera;
                        command.Parameters.Add("@nume_p", OleDbType.VarChar).Value = rez.Pers.Nume;
                        command.Parameters.Add("@cnp_p", OleDbType.VarChar).Value = rez.Pers.CNP.ToString();
                        command.Parameters.Add("@data_rez", OleDbType.Date).Value = rez.DataInchiriere;
                        command.Parameters.Add("@data_rest", OleDbType.Date).Value = rez.DataRestituire;
                        command.Parameters.Add("@pret_t", OleDbType.Integer).Value = rez.Pret;
                    }
                    else {
                        command = new OleDbCommand("UPDATE Rezervari SET " +
                        "Nr_camera = @nr_cam, Nume_persoana = @nume_p, Cnp_persoana = @cnp_p," +
                        "Data_rezervare = @data_rez, Data_restituire = @data_rest, Pret_total = @pret_t " +
                        "WHERE Id = @id", connection);
                         
                        command.Parameters.Add("@nr_cam", OleDbType.Integer).Value = rez.NrCamera;
                        command.Parameters.Add("@nume_p", OleDbType.VarChar).Value = rez.Pers.Nume;
                        command.Parameters.Add("@cnp_p", OleDbType.VarChar).Value = rez.Pers.CNP.ToString();
                        command.Parameters.Add("@data_rez", OleDbType.Date).Value = rez.DataInchiriere;
                        command.Parameters.Add("@data_rest", OleDbType.Date).Value = rez.DataRestituire;
                        command.Parameters.Add("@pret_t", OleDbType.Integer).Value = rez.Pret;
                        command.Parameters.Add("@id", OleDbType.Integer).Value = rez.Id;
                    }
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();
            } 
        }
        
        public static void addOrUpdate_Db(Rezervare rez, string db = null) {
            if (db == null) {
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION;
            }

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                OleDbCommand selCom = new OleDbCommand("SELECT COUNT(*) FROM Rezervari WHERE Id = ?");
                selCom.Parameters.Add("Id", OleDbType.Integer).Value = rez.Id;
                selCom.Connection = connection;
                int rowCount = (int)selCom.ExecuteScalar();

                OleDbCommand command;
                if (rowCount == 0) {
                    command = new OleDbCommand("INSERT INTO Rezervari VALUES(@id, @nr_cam, @nume_p, @cnp_p, @data_rez, @data_rest, @pret_t)", connection);

                    command.Parameters.Add("@id", OleDbType.Integer).Value = rez.Id;
                    command.Parameters.Add("@nr_cam", OleDbType.Integer).Value = rez.NrCamera;
                    command.Parameters.Add("@nume_p", OleDbType.VarChar).Value = rez.Pers.Nume;
                    command.Parameters.Add("@cnp_p", OleDbType.VarChar).Value = rez.Pers.CNP.ToString();
                    command.Parameters.Add("@data_rez", OleDbType.Date).Value = rez.DataInchiriere;
                    command.Parameters.Add("@data_rest", OleDbType.Date).Value = rez.DataRestituire;
                    command.Parameters.Add("@pret_t", OleDbType.Integer).Value = rez.Pret;
                }
                else {
                    command = new OleDbCommand("UPDATE Rezervari SET " +
                    "Nr_camera = @nr_cam, Nume_persoana = @nume_p, Cnp_persoana = @cnp_p," +
                    "Data_rezervare = @data_rez, Data_restituire = @data_rest, Pret_total = @pret_t " +
                    "WHERE Id = @id", connection);

                    command.Parameters.Add("@nr_cam", OleDbType.Integer).Value = rez.NrCamera;
                    command.Parameters.Add("@nume_p", OleDbType.VarChar).Value = rez.Pers.Nume;
                    command.Parameters.Add("@cnp_p", OleDbType.VarChar).Value = rez.Pers.CNP.ToString();
                    command.Parameters.Add("@data_rez", OleDbType.Date).Value = rez.DataInchiriere;
                    command.Parameters.Add("@data_rest", OleDbType.Date).Value = rez.DataRestituire;
                    command.Parameters.Add("@pret_t", OleDbType.Integer).Value = rez.Pret;
                    command.Parameters.Add("@id", OleDbType.Integer).Value = rez.Id;
                }

                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();
            }
        }
        public static void delete_Db(Rezervare rez, string db = null) {
            if (db == null) {
                // Verifica daca exista fisierul cu configuratii 
                if (ConfigurationManager.AppSettings.Count != 0)
                    db = ConfigurationManager.AppSettings["dbLocation"];
                else db = Program.DB_LOCATION;
            }

            OleDbConnection connection = new OleDbConnection(connString + db);
            try {
                connection.Open();
                OleDbCommand delCom = new OleDbCommand("DELETE FROM Rezervari WHERE Id = ?",connection);
                delCom.Parameters.Add("Id", OleDbType.Integer).Value = rez.Id; 
                delCom.ExecuteNonQuery(); 
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                connection.Close();
            }
        }

    }
}
