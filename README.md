# Bulanık Mantık Çamaşır Makinesi Kontrolü

Bu proje, çamaşır makinesi kontrolü için bulanık mantık (fuzzy logic) kullanarak akıllı bir kontrol sistemi uygulamasıdır. Sistem, çamaşırın hassasiyeti, kirlilik seviyesi ve miktarı gibi girdilere dayanarak optimal dönüş hızı, yıkama süresi ve deterjan miktarını belirler.

## Özellikler

- Üçlü üyelik fonksiyonları ile bulanık mantık hesaplamaları
- Mamdani çıkarım sistemi
- Ağırlıklı ortalama ve centroid (ağırlık merkezi) hesaplamaları
- Görsel grafik arayüzü ile sonuçların gösterimi
- Dinamik kural tabanı

## Gereksinimler

- .NET Framework
- Windows Forms
- System.Windows.Forms.DataVisualization

## Kullanım

1. Uygulamayı başlatın
2. TrackBar'ları kullanarak:
   - Çamaşırın hassasiyetini (0-10)
   - Kirlilik seviyesini (0-10)
   - Çamaşır miktarını (0-10) ayarlayın
3. "Hesapla" butonuna tıklayın
4. Sonuçları grafiklerde ve listelerde görüntüleyin

## Çıktılar

- Dönüş hızı (rpm)
- Yıkama süresi (dakika)
- Deterjan miktarı (ml)

