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
    public class fiókMűveletek
    {
        public fiókMűveletek() { }
        public void regisztrál(string név, string jelszó)
        {
            if(!létezőFiók(név,jelszó, true))
            {
                MessageBox.Show("Sikeres regisztráció");
            }
            else
            {
                MessageBox.Show("Létezik már a felhasználó");
            }
        }
        public bool létezőFiók(string név, string jelszó,bool reg)
        {
            List<Felhasználó> felhasználók = new List<Felhasználó>();
            using (StreamReader r = new StreamReader("../../../adatok.json"))
            {
                string json = r.ReadToEnd();
                felhasználók = JsonConvert.DeserializeObject<List<Felhasználó>>(json);
            }
            if(felhasználók != null)
            {
                foreach (Felhasználó f in felhasználók)
                {
                    if (f.név == név && f.jelszó == jelszó)
                    {
                        return true;
                    }
                    if(f.név == név)
                    {
                        if(reg)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            fiókHozzáadása(név, jelszó, felhasználók);
            return false;
        }
        public void fiókHozzáadása(string név, string jelszó, List<Felhasználó> lista)
        {
            if(lista == null)
            {
                lista = new List<Felhasználó>();
            }
            lista.Add(new Felhasználó(név, jelszó));
            string json = JsonConvert.SerializeObject(lista);
            System.IO.File.WriteAllText("../../../adatok.json", json);
        }

        public List<Felhasználó> összesSzerelő()
        {
            List<Felhasználó> felhasználók = new List<Felhasználó>();
            using (StreamReader r = new StreamReader("../../../adatok.json"))
            {
                string json = r.ReadToEnd();
                felhasználók = JsonConvert.DeserializeObject<List<Felhasználó>>(json);
            }

            return felhasználók.Where(f => f.szerelő).ToList();
        }
    }
}
