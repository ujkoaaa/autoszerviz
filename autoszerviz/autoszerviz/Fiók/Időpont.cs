using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoszerviz.Fiók
{
    public class Időpont
    {
        public string szerelőnév;
        public string ügyfél;
        public DateTime idő;
        public Időpont(string szerelő, string kliens, DateTime dátum)
        {
            szerelőnév = szerelő;
            ügyfél = kliens;
            idő = dátum;
        }
    }
}
