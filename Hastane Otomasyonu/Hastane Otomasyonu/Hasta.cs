using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane_Otomasyonu
{
    public class Hasta : IComparable<Hasta>
    {
        public int HastaNo { get; set; }
        public string HastaAdi { get; set; }
        public int HastaYasi { get; set; }
        public char Cinsiyet { get; set; }
        public bool MahkumlukDurum { get; set; }
        public int EngelliOran { get; set; }
        public string KanamaliHastaDurum { get; set; }
        public string HastaKayitSaati { get; set; }
        public string MuayeneSaati { get; set; }
        public int MuayeneSuresi { get; set; }
        public int Oncelik { get; set; }
        public string MuayeneZamani { get; set; } 

        public int CompareTo(Hasta other)
        {
            if (other == null) return 1;
            int priorityComparison = this.Oncelik.CompareTo(other.Oncelik);
            if (priorityComparison == 0)
            {
                return DateTime.ParseExact(this.HastaKayitSaati, "HH.mm", null).CompareTo(DateTime.ParseExact(other.HastaKayitSaati, "HH.mm", null));
            }
            return priorityComparison;
        }
    }
}