using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cazari_la_hotel {
    public class Camera : IComparable, ICloneable, IText {
        private short numar; // max 32,767 
        private byte etaj; // max 255 

        private uint capacitatePersoane;
        private bool areBaie;
        private bool areBucatarie;
        private uint pretPeNoapte; 

        public Camera(short nr, byte et, uint capPers, bool baie, bool bucatarie, uint pretN) {
            numar = nr;
            etaj = et;
            capacitatePersoane = capPers;
            areBaie = baie;
            areBucatarie = bucatarie;
            pretPeNoapte = pretN;
        }

        public short Numar {
            get { return numar; }
            set { numar = value; }
        }
        public byte Etaj {
            get { return etaj; }
            set { etaj = value; }
        }
        public uint CapacitatePersoane {
            get { return capacitatePersoane; }
            set { capacitatePersoane = value; }
        }
        public bool AreBaie {
            get { return areBaie; }
            set { areBaie = value; }
        }
        public bool AreBucatarie {
            get { return areBucatarie; }
            set { areBucatarie = value; }
        }
        public uint PretPeNoapte {
            get { return pretPeNoapte; }
            set { pretPeNoapte = value; }
        }

        public static explicit operator short (Camera c){
            return c.numar;
        }

        public object Clone() {
            return MemberwiseClone();
        }

        public int CompareTo(object obj) {
            Camera c = (Camera)obj; // shallow copy
            return pretPeNoapte.CompareTo(c.pretPeNoapte);
        }
        public override string ToString() {
            return "Nr:" + numar + ", Etaj:" + etaj + ", Nr.pers:" + capacitatePersoane
                 + ", Baie:" + (areBaie ? "DA" : "NU") + ", Bucatarie:" + (areBucatarie ? "DA" : "NU")
                 + ", Pret/Nopate:" + pretPeNoapte + "lei";
        }
        public string ToTxt() {
            return numar + "," + etaj + "," + capacitatePersoane
                 + "," + areBaie.ToString() + "," + areBaie.ToString()
                 + "," + pretPeNoapte;
        }

    }
}
