using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoszerviz.Fiók
{
    public class Felhasználó
    {
        public string név;
        public string jelszó;

        public bool szerelő;
        
        public Felhasználó(string név, string jelszó, bool szerelő = false)
        {
            this.név = név;
            this.jelszó = jelszó;
            this.szerelő = szerelő;
        }

        public override string ToString()
        {
            return név;
        }
    }
}
