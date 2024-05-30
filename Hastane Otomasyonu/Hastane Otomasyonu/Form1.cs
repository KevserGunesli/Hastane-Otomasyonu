using System.Security.Policy;

namespace Hastane_Otomasyonu
{
    public partial class Form1 : Form
    {

        private string muayeneSaati = "09.00"; 
        private int muayeneSiraNo = 1;         
        private HastaLinkedList hastalar;      
        private MaxHeap muayeneSira;           

        public Form1()
        {
            InitializeComponent();

            hastalar = new HastaLinkedList();
            muayeneSira = new MaxHeap();

        }

        private void buttonHastalariYukle_Click(object sender, EventArgs e)
        {
            dataGridViewHastalar.Visible = true;    
            label1.Visible = true;                 
            buttonHastalariYukle.Visible = false;   
            buttonMuayeneyeBasla.Visible = true;    

            HastalariYukle();

            var sortedHastalar = hastalar.ToList().OrderBy(h => DateTime.ParseExact(h.HastaKayitSaati, "HH.mm", null)).ToList();

            for (int i = 0; i < sortedHastalar.Count; i++)
            {
                sortedHastalar[i].HastaNo = i + 1;
            }

            dataGridViewHastalar.DataSource = null;
            dataGridViewHastalar.DataSource = sortedHastalar;

            hastalar.Hastalar�Temizle();

            /// hastalar ba�l� listesini tekrardan olu�tur.
            /// ba�l� liste mant��� ile devam etmek i�in (veri yap�s� kullan�m mant��� i�in yoksa buna gerek yok)
            /// Hastalar geli� saatine g�re s�ral� bir �ekilde ba�l� listeye eklendi.
            foreach (Hasta hasta in sortedHastalar)
            {
                hastalar.Add(hasta);
            }




            
        }

        private void buttonMuayeneyeBasla_Click(object sender, EventArgs e)
        {
            dataGridViewHastalar.Visible = false;          

            label1.Visible = false;                          
            buttonMuayeneyeBasla.Visible = false;             
            label2.Visible = true;                         
            dataGridViewHastalar.Visible = false;           
            listBoxMuayeneEdilenHastalar.Visible = true;   
            panelMuayene.Visible = true;                    

            MuayeneleriYurut();
        }

        private void HastalariYukle()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Hasta.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null) 
                    {
                        var values = line.Split(','); 
                        var yeniHasta = new Hasta
                        {
                            HastaAdi = values[1],
                            HastaYasi = int.Parse(values[2]),
                            Cinsiyet = values[3][0],
                            MahkumlukDurum = bool.Parse(values[4]),
                            EngelliOran = int.Parse(values[5]),
                            KanamaliHastaDurum = values[6].Trim(),
                            HastaKayitSaati = values[7].Trim(),
                        };

                        //hastan�n �ncelik puan� ve muayene s�resini hesaplama
                        yeniHasta.Oncelik = OncelikPuaniHesapla(yeniHasta.HastaYasi, yeniHasta.MahkumlukDurum, yeniHasta.EngelliOran, yeniHasta.KanamaliHastaDurum);
                        yeniHasta.MuayeneSuresi = MuayeneSuresiHesapla(yeniHasta.HastaYasi, yeniHasta.EngelliOran, yeniHasta.KanamaliHastaDurum);
                        
                        //ba�l� listenin Add ad�nda fonksiyonu bulunmaktad�r
                        hastalar.Add(yeniHasta);
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Dosya okuma hatas�: " + ex.Message);
            }
        }
        private void MuayeneleriYurut()
        {
            bool hastalarbittimi = false; 

            while (hastalar.ToList().Count > 0) 
            {


                while (DateTime.ParseExact(hastalar.Head.Data.HastaKayitSaati, "HH.mm", null) <= DateTime.ParseExact(muayeneSaati, "HH.mm", null))
                {
                    
                    Hasta hastaal = hastalar.Head.Data; 
                    hastalar.Head = hastalar.Head.Next; 

                    muayeneSira.Add(hastaal); 

                    if (hastalar.Head == null) 
                    {
                        hastalarbittimi = true; 
                        break;
                    }

                }

                if (hastalarbittimi) 
                {
                    break;
                }

                if (muayeneSira.Count == 0)
                {
                    DakikaEkle(1);
                    continue;
                }

                MuayeneHeapGoster(muayeneSira.ToList());
                System.Threading.Thread.Sleep(500);

                var hasta = muayeneSira.ExtractMax();
                HastaMuayeneEt(hasta);
            }

            while (muayeneSira.Count > 0)
            {
                MuayeneHeapGoster(muayeneSira.ToList());
                System.Threading.Thread.Sleep(500);

                var hasta = muayeneSira.ExtractMax();
                HastaMuayeneEt(hasta);
            }

            MessageBox.Show("T�m Hastalar ba�ar�yla tedavi edildi.");

        }

        private void HastaMuayeneEt(Hasta muayeneHastasi)
        {
            muayeneHastasi.MuayeneSaati = muayeneSaati;
            string muayeneBilgisi = $"{muayeneSiraNo}. s�rada {muayeneHastasi.HastaNo} numaral� {muayeneHastasi.HastaAdi} adl� hasta muayene olmu�tur.\n" +
                                    $"�ncelik Puan�: {muayeneHastasi.Oncelik}   Muayene s�resi: {muayeneHastasi.MuayeneSuresi}  Muayene Giri� Saati: {muayeneSaati}";
            listBoxMuayeneEdilenHastalar.Items.Add(muayeneBilgisi);

            labelSAAT.Text = "SAAT: " + muayeneSaati;
            labelSAAT.Refresh();
            listBoxMuayeneEdilenHastalar.Refresh();
            System.Threading.Thread.Sleep(1000);
            muayeneSiraNo++;
            DakikaEkle(muayeneHastasi.MuayeneSuresi);
        }

        private void DakikaEkle(int dakika)
        {
            DateTime time = DateTime.ParseExact(muayeneSaati, "HH.mm", null);
            time = time.AddMinutes(dakika);
            muayeneSaati = time.ToString("HH.mm");
        }

        private int yaspuani(int yas)
        {
            if (yas < 5) return 20;
            if (yas < 45) return 0;
            if (yas < 65) return 15;
            return 25;
        }

        private int Ismahkum(bool mahkumdurumu)
        {
            return mahkumdurumu ? 50 : 0;
        }

        private int KanamaDegeri(string kanamaDurumu)
        {
            return kanamaDurumu == "agirKanama" ? 50 : (kanamaDurumu == "kanama" ? 20 : 0);
        }

        private int OncelikPuaniHesapla(int yas, bool mahkumdurumu, int engellilikOrani, string kanamaDurumu)
        {
            return yaspuani(yas) + Ismahkum(mahkumdurumu) + (engellilikOrani / 4) + KanamaDegeri(kanamaDurumu);
        }

        private int MuayeneSuresiHesapla(int yas, int engellilikOrani, string kanamaDurumu)
        {
            int muayeneSuresi = 10;
            if (yas >= 65) muayeneSuresi += 15;
            if (kanamaDurumu == "agirKanama") muayeneSuresi += 20;
            else if (kanamaDurumu == "kanama") muayeneSuresi += 10;
            muayeneSuresi += engellilikOrani / 5;
            return muayeneSuresi;
        }



        //******************************************tree yap�s�*****************************/*
        private void MuayeneHeapGoster(List<Hasta> muayeneSirasi)
{
    panelMuayene.Controls.Clear(); // Paneli temizle

    if (muayeneSirasi.Count == 0)
    {
        Label emptyLabel = new Label
        {
            Text = "Muayene s�ras� bo�.",
            AutoSize = true,
            Location = new Point(panelMuayene.Width / 2, panelMuayene.Height / 2) // Panelin merkezine yerle�tir
        };
        panelMuayene.Controls.Add(emptyLabel);
        return;
    }

    // K�k d���m� ekle (heap'in ilk eleman�)
    NodeEkle(muayeneSirasi, 0, panelMuayene.Width / 2, 20, panelMuayene.Width / 4);

    panelMuayene.Refresh();
}

        private void NodeEkle(List<Hasta> muayeneSirasi, int index, int x, int y, int offset)
        {
            if (index >= muayeneSirasi.Count) return;

            // Hasta bilgilerini g�steren Label olu�tur
            Label nodeLabel = NodeBilgisiniOlustur(muayeneSirasi[index]);
            nodeLabel.Location = new Point(x - nodeLabel.Width / 2, y);
            panelMuayene.Controls.Add(nodeLabel);

            // �ocuk d���mleri ekle
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex < muayeneSirasi.Count)
            {
                // Sol �ocuk d���m� ekle ve �izgiyi �iz
                NodeEkle(muayeneSirasi, leftChildIndex, x - offset, y + 50, offset / 2);
            }

            if (rightChildIndex < muayeneSirasi.Count)
            {
                // Sa� �ocuk d���m� ekle ve �izgiyi �iz
                NodeEkle(muayeneSirasi, rightChildIndex, x + offset, y + 50, offset / 2);
            }
        }

        private Label NodeBilgisiniOlustur(Hasta hasta)
        {
            Label nodeLabel = new Label
            {
                Text = $"{hasta.HastaAdi}\n�ncelik: {hasta.Oncelik}\nKay�t: {hasta.HastaKayitSaati}",
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(2), // Kenarl�k boyutu k���lt�ld�
                BackColor = Color.LightBlue, // Arka plan rengi
                Font = new Font("Arial", 8) // Font boyutunu k���ltt�
            };
            return nodeLabel;
        }

        //****************************************************************************************

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxMuayeneEdilenHastalar.Visible = false;
            panelMuayene.Visible = false;
            label2.Visible = false;
            dataGridViewHastalar.Visible = false;
            buttonMuayeneyeBasla.Visible= false;
            label1.Visible = false;
        }
        //******************************************------------*****************************/

    }
}
