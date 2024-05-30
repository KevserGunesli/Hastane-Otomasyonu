using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane_Otomasyonu
{
    public class HastaNode
    {
        public Hasta Data { get; set; }
        public HastaNode Next { get; set; }
    }
}
