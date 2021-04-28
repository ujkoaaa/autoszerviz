using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoszerviz.Fiók
{
    public class IdopontMuveletek
    {
        private const string IdopontokFile = "../../../időpontok.json";

        private List<Időpont> idopontok;

        public IdopontMuveletek()
        {
            using (StreamReader r = new StreamReader(IdopontokFile))
            {
                string json = r.ReadToEnd();
                idopontok = JsonConvert.DeserializeObject<List<Időpont>>(json) ?? new List<Időpont>();
            }
        }

        public List<Időpont> GetSzerelo(string szerelo) => idopontok.Where(ip => ip.szerelőnév == szerelo).ToList();

        public void AddIdopont(Időpont idopont) => idopontok.Add(idopont);

        public void Mentes()
        {
            string json = JsonConvert.SerializeObject(idopontok, Formatting.Indented);
            File.WriteAllText(IdopontokFile, json);
        }

        public Időpont GetIdopont(DateTime idopont, string szerelo)
        {
            return idopontok
                .Where(ip => ip.szerelőnév == szerelo)
                .Where(ip => ip.idő == idopont)
                .First();
        }
    }
}
