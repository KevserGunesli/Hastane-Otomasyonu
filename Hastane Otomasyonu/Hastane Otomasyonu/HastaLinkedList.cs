using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane_Otomasyonu
{
    public class HastaLinkedList
    {
        public HastaNode Head { get; set; }

        public void HastalarıTemizle()
        {
            Head = null;
        }

        public void Add(Hasta hasta)
        {
            HastaNode newNode = new HastaNode { Data = hasta };
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                HastaNode current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public List<Hasta> ToList()
        {
            List<Hasta> list = new List<Hasta>();
            HastaNode current = Head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            return list;
        }
    }
}
