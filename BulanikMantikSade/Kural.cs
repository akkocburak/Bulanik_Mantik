using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulanikMantikSade
{
    public class Kural
    {
        public string Hassaslik { get; set; }
        public string Miktar { get; set; }
        public string Kirlilik { get; set; }
        public string DonusHizi { get; set; }
        public string Sure { get; set; }
        public string Deterjan { get; set; }

        public Kural(string hassaslik, string miktar, string kirlilik, string donusHizi, string sure, string deterjan)
        {
            Hassaslik = hassaslik;
            Miktar = miktar;
            Kirlilik = kirlilik;
            DonusHizi = donusHizi;
            Sure = sure;
            Deterjan = deterjan;
        }
    }
}
