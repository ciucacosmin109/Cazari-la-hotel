using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cazari_la_hotel {
    public class Rezervare: IText {
        private int id;

        private short nrCamera;
        private Persoana persoana;
        private DateTime dataInchiriere;
        private DateTime dataRestituire;
        private uint pret;

        public Rezervare(int id, short nrCam, Persoana pers, DateTime inchiriere, DateTime restituire, uint pretTotal) {
            this.id = id;
            nrCamera = nrCam;
            persoana = pers;
            dataInchiriere = inchiriere;
            dataRestituire = restituire;
            pret = pretTotal;
        }

        public int Id {
            get { return id; }
            set { id = value; }
        }
        public short NrCamera {
            get { return nrCamera; }
            set { nrCamera = value; }
        }
        public Persoana Pers {
            get { return persoana; }
            set { persoana = value; }
        }
        public DateTime DataInchiriere {
            get { return dataInchiriere; }
            set { dataInchiriere = value; }
        }
        public DateTime DataRestituire {
            get { return dataRestituire; }
            set { dataRestituire = value; }
        }
        public uint Pret {
            get { return pret; }
            set { pret = value; }
        }

        public override string ToString() {
            return "Nr. camera:"+nrCamera+", Nume pers.:"+persoana.Nume+
                ", CNP pers.:"+persoana.CNP+", Data I:"+dataInchiriere.ToString() +
                ", Data R:" + dataRestituire.ToString() +
                ", Pret:" + pret.ToString();
        }
        public string ToTxt() {
            return  id + "," + nrCamera + "," + persoana.Nume +
                "," + persoana.CNP + "," + dataInchiriere.ToString() +
                "," + dataRestituire.ToString() +
                "," + pret.ToString();
        }
    }
}
