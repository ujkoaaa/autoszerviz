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
        
        public Felhasználó(string név_, string jelszó_) { név = név_; jelszó = jelszó_; }
    }
}
