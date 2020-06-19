using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cazari_la_hotel {
    public class Persoana : ICloneable {
        private long cnp;
        private string numeComplet; 

        public Persoana(string nume, long cnp) {
            this.cnp = cnp;
            numeComplet = nume; 
        }

        public long CNP {
            get { return cnp; }
            set { cnp = value; }
        }
        public string Nume {
            get { return numeComplet; }
            set { numeComplet = value; }
        } 
        public object Clone() {
            return this.MemberwiseClone();
        }
    }
}
