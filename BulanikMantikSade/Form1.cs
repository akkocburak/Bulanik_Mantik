using System;
using System.Security.Policy;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BulanikMantikSade
{

    public partial class Form1 : Form
    {
        private Chart chartDonusHizi;
        private Chart chartDeterjan;
        private Chart chartSure;
        private Chart chartHassaslik;
        private Chart chartKirlilik;
        private Chart chartMiktar;
        private DataGridView dataGridViewKurallar;


        public Form1()
        {
            InitializeComponent();

        }
        



        private void button1_Click(object sender, EventArgs e)
        {


            listBoxSonuc.Items.Clear();
            listBox1.Items.Clear();

            // TrackBar değerlerini al
            double hassaslik = trackBarHassaslik.Value / 10.0;
            double kirlilik = trackBarKirlilik.Value / 10.0;
            double miktar = trackBarMiktar.Value / 10.0;

            // Üyelik derecelerini hesapla
            double hassasDusuk = UcluUyelik(hassaslik, 0, 0, 5);
            double hassasOrta = UcluUyelik(hassaslik, 3, 5, 7);
            double hassasYuksek = UcluUyelik(hassaslik, 5, 10, 10);

            double kirliAz = UcluUyelik(kirlilik, 0, 0, 5);
            double kirliOrta = UcluUyelik(kirlilik, 3, 5, 7);
            double kirliCok = UcluUyelik(kirlilik, 5, 10, 10);

            double miktarAz = UcluUyelik(miktar, 0, 0, 5);
            double miktarOrta = UcluUyelik(miktar, 3, 5, 7);
            double miktarFazla = UcluUyelik(miktar, 5, 10, 10);

            //double hassasDusuk = YamukUyelik(hassaslik, 0, 0, 2.5, 5);
            //double hassasOrta = YamukUyelik(hassaslik, 3, 5, 5, 7);
            //double hassasYuksek = YamukUyelik(hassaslik, 5, 7.5, 10, 10);


            //double kirliAz = YamukUyelik(kirlilik, 0, 0, 2.5, 5);
            //double kirliOrta = YamukUyelik(kirlilik, 3, 5, 5, 7);
            //double kirliCok = YamukUyelik(kirlilik, 5, 7.5, 10, 10);

            //double miktarAz = YamukUyelik(miktar, 0, 0, 2.5, 5);
            //double miktarOrta = YamukUyelik(miktar, 3, 5, 5, 7);
            //double miktarFazla = YamukUyelik(miktar, 5, 7.5, 10, 10);

            // Üyelikleri ekrana yaz
            listBoxSonuc.Items.Add($"Hassaslık - Düşük: {hassasDusuk:F2}, Orta: {hassasOrta:F2}, Yüksek: {hassasYuksek:F2}");
            listBoxSonuc.Items.Add($"Kirlilik - Az: {kirliAz:F2}, Orta: {kirliOrta:F2}, Çok: {kirliCok:F2}");
            listBoxSonuc.Items.Add($"Miktar - Az: {miktarAz:F2}, Orta: {miktarOrta:F2}, Fazla: {miktarFazla:F2}");
            listBoxSonuc.Items.Add("----------------------");

          
            // Değişkenler
            Dictionary<string, double> donusHiziSonuc = new Dictionary<string, double>();
            Dictionary<string, double> sureSonuc = new Dictionary<string, double>();
            Dictionary<string, double> deterjanSonuc = new Dictionary<string, double>();

            List<Kural> kurallar = GetirKurallar();
            foreach (DataGridViewRow row in dataGridViewKurallar.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
            // Her kural için çalış
            foreach (var kural in kurallar)
            {
                double hassaslikUyelik = 0;
                if (kural.Hassaslik == "sağlam") hassaslikUyelik = hassasDusuk;
                else if (kural.Hassaslik == "orta") hassaslikUyelik = hassasOrta;
                else if (kural.Hassaslik == "hassas") hassaslikUyelik = hassasYuksek;

                double miktarUyelik = 0;
                if (kural.Miktar == "küçük") miktarUyelik = miktarAz;
                else if (kural.Miktar == "orta") miktarUyelik = miktarOrta;
                else if (kural.Miktar == "büyük") miktarUyelik = miktarFazla;

                double kirlilikUyelik = 0;
                if (kural.Kirlilik == "küçük") kirlilikUyelik = kirliAz;
                else if (kural.Kirlilik == "orta") kirlilikUyelik = kirliOrta;
                else if (kural.Kirlilik == "büyük") kirlilikUyelik = kirliCok;

                // Mamdani çıkarım = min(hassaslık, miktar, kirlilik)
                double kuralTetiklenme = Math.Min(Math.Min(hassaslikUyelik, miktarUyelik), kirlilikUyelik);
               
                if (kuralTetiklenme > 0)
                {
                    // Eğer bu kural tetiklendiyse, etkisini ekle
                    if (!donusHiziSonuc.ContainsKey(kural.DonusHizi))
                        donusHiziSonuc.Add(kural.DonusHizi, 0);
                    donusHiziSonuc[kural.DonusHizi] += kuralTetiklenme;


                    if (!sureSonuc.ContainsKey(kural.Sure))
                        sureSonuc.Add(kural.Sure, 0);
                    sureSonuc[kural.Sure] += kuralTetiklenme;

                    if (!deterjanSonuc.ContainsKey(kural.Deterjan))
                        deterjanSonuc.Add(kural.Deterjan, 0);
                    deterjanSonuc[kural.Deterjan] += kuralTetiklenme;
                }
                if (kuralTetiklenme > 0)
                {
                    // Kural tetiklendiği anda DataGridView'da o satırı mavi yap
                    int satirIndex = kurallar.IndexOf(kural);
                    dataGridViewKurallar.Rows[satirIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                    listBoxSonuc.Items.Add($"mamdani: {kuralTetiklenme:F2}");
                    
                }
            }

            // Ağırlıklı Ortalama ile Hesaplama

            Dictionary<string, int> donusHiziDegerleri = new Dictionary<string, int>()
    {
        {"hassas", 400}, {"normal_hassas", 600}, {"orta", 800}, {"normal_güçlü", 1000}, {"güçlü", 1200}
    };

            Dictionary<string, int> sureDegerleri = new Dictionary<string, int>()
    {
        {"kısa", 30}, {"normal_kısa", 45}, {"orta", 60}, {"normal_uzun", 75}, {"uzun", 90}
    };

            Dictionary<string, int> deterjanDegerleri = new Dictionary<string, int>()
    {
        {"çok_az", 25}, {"az", 50}, {"orta", 75}, {"fazla", 100}, {"çok_fazla", 125}
    };

            double donusToplam = donusHiziSonuc.Sum(x => x.Value * donusHiziDegerleri[x.Key]);
            double donusPayda = donusHiziSonuc.Sum(x => x.Value);

            double sureToplam = sureSonuc.Sum(x => x.Value * sureDegerleri[x.Key]);
            double surePayda = sureSonuc.Sum(x => x.Value);

            double deterjanToplam = deterjanSonuc.Sum(x => x.Value * deterjanDegerleri[x.Key]);
            double deterjanPayda = deterjanSonuc.Sum(x => x.Value);

            double donusHiziOrtalama = donusPayda != 0 ? donusToplam / donusPayda : 0;
            double sureOrtalama = surePayda != 0 ? sureToplam / surePayda : 0;
            double deterjanOrtalama = deterjanPayda != 0 ? deterjanToplam / deterjanPayda : 0;

            // Sonuçları yaz
            listBoxSonuc.Items.Add("=== === Ağırlıklı Ortalama Sonuçları === ===\n");
            listBoxSonuc.Items.Add($"Dönüş Hızı (rpm): {donusHiziOrtalama:F2}");
            listBoxSonuc.Items.Add($"Süre (dk): {sureOrtalama:F2}");
            listBoxSonuc.Items.Add($"Deterjan (ml): {deterjanOrtalama:F2}");

            //Centroid(Ağırlık Merkezi) hesaplama

            listBox1.Items.Add("=== Centroid (Ağırlık Merkezi) Sonuçları ===");

            // Dönüş Hızı için
            double centroidDonus = donusToplam / donusPayda;
            listBox1.Items.Add($"Dönüş Hızı (rpm): {centroidDonus:F2}");

            // Süre için
            double centroidSure = sureToplam / surePayda;
            listBox1.Items.Add($"Süre (dk): {centroidSure:F2}");

            // Deterjan için
            double centroidDeterjan = deterjanToplam / deterjanPayda;
            listBox1.Items.Add($"Deterjan (ml): {centroidDeterjan:F2}");




            // Dönüş Hızı Grafiği
            SonucGrafikGercekCiz(chartDonusHizi, donusHiziOrtalama, new List<double> { 400, 600, 800, 1000, 1200 }, "Dönüş Hızı");

            // Deterjan Grafiği
            SonucGrafikGercekCiz(chartDeterjan, deterjanOrtalama, new List<double> { 25, 50, 75, 100, 125 }, "Deterjan");

            // Süre Grafiği
            SonucGrafikGercekCiz(chartSure, sureOrtalama, new List<double> { 30, 45, 60, 75, 90 }, "Süre");

        }


        private double UcluUyelik(double x, double a, double b, double c)
        {
            if (x <= a || x > c) return 0;
            else if (x == b) return 1;
            else if (x > a && x < b) return (x - a) / (b - a);
            else return (c - x) / (c - b);
        }
        //Alternatif üyelik 
        private double YamukUyelik(double x, double a, double b, double c, double d)
        {
            if (x <= a || x >= d)
                return 0;
            else if (x > a && x <= b)
                return (x - a) / (b - a);
            else if (x > b && x <= c)
                return 1;
            else if (x > c && x < d)
                return (d - x) / (d - c);
            else
                return 0;
        }

        //Bu metot düzgün çalımadığı için kullanmıyorum 
        private double GercekCentroidHesapla(Func<double, double> uyelikFonksiyonu, double minX, double maxX, double adim)
        {
            double pay = 0;   // x * üyelik
            double payda = 0; // sadece üyelik
            for (double x = minX; x <= maxX; x += adim)
            {
                double uyelik = uyelikFonksiyonu(x);
                pay += x * uyelik;
                payda += uyelik;
            }
            if (payda == 0) return 0;
            return pay / payda;
        }
        
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            // TrackBar'ları sıfırla
            trackBarHassaslik.Value = 0;
            trackBarKirlilik.Value = 0;
            trackBarMiktar.Value = 0;

            // ListBox'ı temizle
            listBoxSonuc.Items.Clear();
            listBox1.Items.Clear();

            
            label4.Text = string.Empty;
            label5.Text = string.Empty;
            label6.Text = string.Empty;

            if (dataGridViewKurallar != null)
            {
                foreach (DataGridViewRow row in dataGridViewKurallar.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            if (chartHassaslik != null)
                CizGrafik(chartHassaslik);
            if (chartKirlilik != null)
                CizGrafik(chartKirlilik);
            if (chartMiktar != null)
                CizGrafik(chartMiktar);
            


        }

        private void trackBarHassaslik_Scroll(object sender, EventArgs e)
        {
            double deger = trackBarHassaslik.Value / 10.0;
            label4.Text = deger.ToString("0.0");

            CizSeciliDeger(chartHassaslik, deger);

        }

        private void trackBarKirlilik_Scroll(object sender, EventArgs e)
        {
            double deger = trackBarKirlilik.Value / 10.0;
            label5.Text = deger.ToString("0.0");
            CizSeciliDeger(chartKirlilik, deger);
        }

        private void trackBarMiktar_Scroll(object sender, EventArgs e)
        {
            double deger = trackBarMiktar.Value / 10.0;
            label6.Text = deger.ToString("0.0");
            CizSeciliDeger(chartMiktar, deger);
        }
        
        // burakada kod tekrarı oldu ama düzenleyemedim tabloda hangikuralın çalıştığını gösteriyor
        private List<Kural> GetirKurallar()
        {
            return new List<Kural>()
    {
        new Kural("hassas", "küçük", "küçük", "hassas", "kısa", "çok_az"),
        new Kural("hassas", "küçük", "orta", "normal_hassas", "kısa", "az"),
        new Kural("hassas", "küçük", "büyük", "orta", "normal_kısa", "orta"),
        new Kural("hassas", "orta", "küçük", "hassas", "kısa", "orta"),
        new Kural("hassas", "orta", "orta", "normal_hassas", "normal_kısa", "orta"),
        new Kural("hassas", "orta", "büyük", "orta", "orta", "fazla"),
        new Kural("hassas", "büyük", "küçük", "normal_hassas", "normal_kısa", "orta"),
        new Kural("hassas", "büyük", "orta", "normal_hassas", "orta", "fazla"),
        new Kural("hassas", "büyük", "büyük", "orta", "normal_uzun", "fazla"),
        new Kural("orta", "küçük", "küçük", "normal_hassas", "normal_kısa", "az"),
        new Kural("orta", "küçük", "orta", "orta", "kısa", "orta"),
        new Kural("orta", "küçük", "büyük", "normal_güçlü", "orta", "fazla"),
        new Kural("orta", "orta", "küçük", "normal_hassas", "normal_kısa", "orta"),
        new Kural("orta", "orta", "orta", "orta", "orta", "orta"),
        new Kural("orta", "orta", "büyük", "hassas", "uzun", "fazla"),
        new Kural("orta", "büyük", "küçük", "hassas", "orta", "orta"),
        new Kural("orta", "büyük", "orta", "hassas", "normal_uzun", "fazla"),
        new Kural("orta", "büyük", "büyük", "hassas", "uzun", "çok_fazla"),
        new Kural("sağlam", "küçük", "küçük", "orta", "orta", "az"),
        new Kural("sağlam", "küçük", "orta", "normal_güçlü", "orta", "orta"),
        new Kural("sağlam", "küçük", "büyük", "güçlü", "normal_uzun", "fazla"),
        new Kural("sağlam", "orta", "küçük", "orta", "orta", "orta"),
        new Kural("sağlam", "orta", "orta", "normal_güçlü", "normal_uzun", "orta"),
        new Kural("sağlam", "orta", "büyük", "güçlü", "orta", "çok_fazla"),
        new Kural("sağlam", "büyük", "küçük", "normal_güçlü", "normal_uzun", "fazla"),
        new Kural("sağlam", "büyük", "orta", "normal_güçlü", "uzun", "fazla"),
        new Kural("sağlam", "büyük", "büyük", "güçlü", "uzun", "çok_fazla")
       
    };
        }
        //Buradan sonrası grafik çizmek için 
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewKurallar = new DataGridView();
            dataGridViewKurallar.Size = new Size(750, 650);
            dataGridViewKurallar.Location = new Point(820, 80);
            dataGridViewKurallar.ColumnCount = 7;
            
            // DataGrid görünüm ayarları
            dataGridViewKurallar.BackgroundColor = Color.White;
            dataGridViewKurallar.BorderStyle = BorderStyle.None;
            dataGridViewKurallar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewKurallar.GridColor = Color.LightGray;
            dataGridViewKurallar.RowHeadersVisible = false;
            dataGridViewKurallar.AllowUserToAddRows = false;
            dataGridViewKurallar.AllowUserToDeleteRows = false;
            dataGridViewKurallar.ReadOnly = true;
            dataGridViewKurallar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewKurallar.MultiSelect = false;
            dataGridViewKurallar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewKurallar.EnableHeadersVisualStyles = false;
            dataGridViewKurallar.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 51);
            dataGridViewKurallar.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewKurallar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridViewKurallar.ColumnHeadersHeight = 40;
            dataGridViewKurallar.RowTemplate.Height = 35;
            dataGridViewKurallar.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridViewKurallar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dataGridViewKurallar.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridViewKurallar.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Sütun başlıkları
            dataGridViewKurallar.Columns[0].Name = "No";
            dataGridViewKurallar.Columns[1].Name = "Hassaslık";
            dataGridViewKurallar.Columns[2].Name = "Miktar";
            dataGridViewKurallar.Columns[3].Name = "Kirlilik";
            dataGridViewKurallar.Columns[4].Name = "Dönüş Hızı";
            dataGridViewKurallar.Columns[5].Name = "Süre";
            dataGridViewKurallar.Columns[6].Name = "Deterjan";

            // Kuralları DataGridView'e yükle
            List<Kural> kurallar = GetirKurallar();

            int no = 1;
            foreach (var kural in kurallar)
            {
                dataGridViewKurallar.Rows.Add(no++, kural.Hassaslik, kural.Miktar, kural.Kirlilik, kural.DonusHizi, kural.Sure, kural.Deterjan);
            }

            this.Controls.Add(dataGridViewKurallar);

            chartDonusHizi = GrafikOlusturSonuc("DÖNÜŞ HIZI", new Point(20, 500));
            chartDeterjan = GrafikOlusturSonuc("DETERJAN", new Point(320, 500));
            chartSure = GrafikOlusturSonuc("SÜRE", new Point(620, 500));

            this.Controls.Add(chartDonusHizi);
            this.Controls.Add(chartDeterjan);
            this.Controls.Add(chartSure);


            chartHassaslik = GrafikOlustur("Hassaslık", new Point(20, 150));
            chartKirlilik = GrafikOlustur("Kirlilik", new Point(280, 150));
            chartMiktar = GrafikOlustur("Miktar", new Point(540, 150));

            this.Controls.Add(chartHassaslik);
            this.Controls.Add(chartKirlilik);
            this.Controls.Add(chartMiktar);

            // İlk çizimler
            CizGrafik(chartHassaslik);
            CizGrafik(chartKirlilik);
            CizGrafik(chartMiktar);
        }
        private void CizSeciliDeger(Chart chart, double seciliX)
        { // Önce grafiği sıfırla
            CizGrafik(chart);

            // Seçilen değeri işaretle
            Series secimSerisi = new Series("Seçili Değer");
            secimSerisi.ChartType = SeriesChartType.Point;
            secimSerisi.MarkerSize = 10;
            secimSerisi.MarkerStyle = MarkerStyle.Circle;
            secimSerisi.Color = Color.Red;

            double dusuk = UcluUyelik(seciliX, 0, 0, 5);
            double orta = UcluUyelik(seciliX, 3, 5, 7);
            double yuksek = UcluUyelik(seciliX, 5, 10, 10);

            double sonuc = Math.Max(Math.Max(dusuk, orta), yuksek);

            secimSerisi.Points.AddXY(seciliX, sonuc);

            chart.Series.Add(secimSerisi);
        }
        private void AddLabel(Chart chart, double position, string labelText)
        {
            StripLine stripLine = new StripLine();
            stripLine.IntervalOffset = position;
            stripLine.StripWidth = 0.1;
            stripLine.Text = labelText;
            stripLine.TextAlignment = StringAlignment.Center;
            stripLine.ForeColor = Color.Black;
            stripLine.Font = new Font("Arial", 10, FontStyle.Bold);
            chart.ChartAreas[0].AxisX.StripLines.Add(stripLine);
        }
        private Chart GrafikOlustur(string isim, Point konum)
        {
            Chart chart = new Chart();
            chart.Name = isim; // <<< BURASI yeni eklendi!
            chart.Size = new Size(250, 150);
            chart.Location = konum;
            ChartArea area = new ChartArea();
            chart.ChartAreas.Add(area);
            Series seri = new Series(isim);
            seri.ChartType = SeriesChartType.Line;
            chart.Series.Add(seri);
            return chart;
        }
        private void CizGrafik(Chart chart)
        {
            chart.Series.Clear();

            // Düşük
            Series dusukSeri = new Series("Düşük");
            dusukSeri.ChartType = SeriesChartType.Line;
            dusukSeri.Color = Color.Blue;
            dusukSeri.BorderWidth = 2;
            chart.Series.Add(dusukSeri);

            // Orta
            Series ortaSeri = new Series("Orta");
            ortaSeri.ChartType = SeriesChartType.Line;
            ortaSeri.Color = Color.Green;
            ortaSeri.BorderWidth = 2;
            chart.Series.Add(ortaSeri);

            // Yüksek
            Series yuksekSeri = new Series("Yüksek");
            yuksekSeri.ChartType = SeriesChartType.Line;
            yuksekSeri.Color = Color.Orange;
            yuksekSeri.BorderWidth = 2;
            chart.Series.Add(yuksekSeri);

            for (double x = 0; x <= 10; x += 0.1)
            {
                double dusuk = UcluUyelik(x, 0, 0, 5);
                double orta = UcluUyelik(x, 3, 5, 7);
                double yuksek = UcluUyelik(x, 5, 10, 10);

                dusukSeri.Points.AddXY(x, dusuk);
                ortaSeri.Points.AddXY(x, orta);
                yuksekSeri.Points.AddXY(x, yuksek);
            }

            // X ekseni ayarları
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 10;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.Title = "Değer";
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;

            // Y ekseni ayarları
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 1;
            chart.ChartAreas[0].AxisY.Interval = 0.2;
            chart.ChartAreas[0].AxisY.Title = "Üyelik Derecesi";
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

            // X ekseni üzerine yazıları eklemek için StripLine kullanalım
            if (chart.Name == "Hassaslık")
            {
                AddLabel(chart, 1.5, "Sağlam");
                AddLabel(chart, 5, "Orta");
                AddLabel(chart, 8.5, "Hassas");
            }
            else
            {
                AddLabel(chart, 1.5, "Düşük");
                AddLabel(chart, 5, "Orta");
                AddLabel(chart, 8.5, "Yüksek");
            }


        }
        private Chart GrafikOlusturSonuc(string isim, Point konum)
        {
            Chart chart = new Chart();
            chart.Name = isim;
            chart.Size = new Size(200, 150);
            chart.Location = konum;
            ChartArea area = new ChartArea();
            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 10; // ilk başta 10, ama detaya göre değişecek
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 1;
            chart.ChartAreas.Add(area);
            return chart;
        }
        private void SonucGrafikGercekCiz(Chart chart, double sonucDegeri, List<double> xNoktalar, string grafikAdi)
        {
            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Minimum = xNoktalar.First() - 10;
            chart.ChartAreas[0].AxisX.Maximum = xNoktalar.Last() + 10;
            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 1.2;

            Series uyelikSeri = new Series("Üyelik Fonksiyonu");
            uyelikSeri.ChartType = SeriesChartType.Line;
            uyelikSeri.Color = Color.Black;
            uyelikSeri.BorderWidth = 2;

            // Üyelik Fonksiyonlarını Çizelim
            for (int i = 0; i < xNoktalar.Count - 1; i++)
            {
                uyelikSeri.Points.AddXY(xNoktalar[i], 0);
                uyelikSeri.Points.AddXY((xNoktalar[i] + xNoktalar[i + 1]) / 2, 1);
                uyelikSeri.Points.AddXY(xNoktalar[i + 1], 0);
            }
            chart.Series.Add(uyelikSeri);

            // Gölge Alan (Çıkan Sonuç)
            Series sonucAlan = new Series("Sonuç Alanı");
            sonucAlan.ChartType = SeriesChartType.Area;
            sonucAlan.Color = Color.FromArgb(100, Color.Magenta); // Şeffaf renk
            sonucAlan.BorderWidth = 2;

            double bolgeGenislik = (xNoktalar[1] - xNoktalar[0]); // iki nokta arası mesafe
            sonucAlan.Points.AddXY(sonucDegeri - bolgeGenislik / 2, 0);
            sonucAlan.Points.AddXY(sonucDegeri, 1);
            sonucAlan.Points.AddXY(sonucDegeri + bolgeGenislik / 2, 0);

            chart.Series.Add(sonucAlan);

            // Sonuç Değerini (Centroid) İşaretle
            StripLine stripLine = new StripLine();
            stripLine.IntervalOffset = sonucDegeri;
            stripLine.StripWidth = 0.5;
            stripLine.BackColor = Color.Red;
            chart.ChartAreas[0].AxisX.StripLines.Add(stripLine);
        }



    }
}


