#include <LiquidCrystal.h>

LiquidCrystal lcd(8, 9, 4, 5, 6, 7);

#define sag 0
#define ust 1
#define alt 2
#define sol 3
#define secim 4
#define yok 5

#define sens A1

byte durum = 0;
byte menu = 0;
byte alt_durum = 0;
byte ilk_gosterilen = 0;

byte baslangic_sayisi[5] = {0, 0, 0, 0, 0};
byte anayemek_sayisi[5] = {0, 0, 0, 0, 0};
byte corba_sayisi[5] = {0, 0, 0, 0, 0};
byte tatli_sayisi[5] = {0, 0, 0, 0, 0};
byte icecek_sayisi[5] = {0, 0, 0, 0, 0};

const float baslangic_fiyat[5] = {20, 25, 30, 23, 20};
const float anayemek_fiyat[5] = {20, 25, 30, 23, 20};
const float corba_fiyat[5] = {20, 25, 30, 23, 20};
const float tatli_fiyat[5] = {15, 20, 10, 23, 12};
const float icecek_fiyat[5] = {5, 10, 4, 8, 9};

int tus_oku() // Bu fonksiyon, analog pininden gelen değere bağlı olarak hangi tuşun basıldığını belirler.
{
  int okunan = analogRead(0);
  if (okunan > 1000) return yok;
  if (okunan < 50) return sag;
  if (okunan < 195) return ust;
  if (okunan < 380) return alt;
  if (okunan < 555) return sol;
  if (okunan < 790) return secim;
  return yok;
}

void setup() {
  lcd.begin(16, 2); // LCD'yi başlat
  animasyonluGirisEkrani(); // Animasyonlu giriş ekranını göster 
  animasyon();
  anaMenuGoster(); // Başlangıçta ana menüyü göster
}

void animasyonluGirisEkrani() {//TEK TEK GELCEK
  lcd.clear();
  const char* mesaj1 = "Lokantamiza";
  const char* mesaj2 = "Hos Geldiniz";

  for (int i = 0; i < strlen(mesaj1); i++) {
    lcd.setCursor(i, 0);
    lcd.print(mesaj1[i]);
    delay(200); // Her harf arasında 200ms gecikme
  }

  for (int i = 0; i < strlen(mesaj2); i++) {
    lcd.setCursor(i, 1);
    lcd.print(mesaj2[i]);
    delay(200); // Her harf arasında 200ms gecikme
  } 
  delay(1000); // Mesajı 1 saniye göster
}

void animasyon(){
  lcd.clear();
  lcd.setCursor(4,0),
  lcd.print("LEZZETIN");
  lcd.setCursor(6,1);
  lcd.print("ADRESI");
  //EKRANI KAPAT
  lcd.noDisplay();
  delay(800);
  //EKRANI AÇ
  lcd.display();
  delay(800);

  lcd.clear();//temizler sonra akçakoca myo yazdı
  lcd.setCursor(4,0);
  lcd.print("KEYFIN");
  lcd.setCursor(6,1);
  lcd.print("YOLU");

  //EKRANI KAPAT
  lcd.noDisplay();//: Ekranın kapatılması.
  delay(800);
  //EKRANI AÇ
  lcd.display();//Ekranın tekrar açılması.
  delay(800);
  lcd.clear();//tekrar temizledi ve başa döndü

}

void anaMenuGoster() {
  lcd.clear();
if (durum == 0) {
    lcd.setCursor(0, 0);
    lcd.print(">BASLANGIC");
    lcd.setCursor(3, 1);
    lcd.print("**SECINIZ**");
  } else if (durum == 1) {
    lcd.setCursor(0, 0);
    lcd.print(">ANA YEMEK");
    lcd.setCursor(3, 1);
    lcd.print("**SECINIZ**");
  } else if (durum == 2) {
    lcd.setCursor(0, 0);
    lcd.print(">CORBA");
    lcd.setCursor(3, 1);
    lcd.print("**SECINIZ**");
  }
  else if (durum == 3) {
    lcd.setCursor(0, 0);
    lcd.print(">TATLI");
    lcd.setCursor(3, 1);
    lcd.print("**SECINIZ**");
  }
  else if (durum == 4) {
    lcd.setCursor(0, 0);
    lcd.print(">ICECEK");
    lcd.setCursor(3, 1);
    lcd.print("**SECINIZ**");
  }
}

void altMenuGoster(const char* items[], byte itemCount, byte miktar[]) {
  lcd.clear();
  for (byte i = 0; i < 2 && ilk_gosterilen + i < itemCount; i++) {
    lcd.setCursor(0, i);
    if (alt_durum == ilk_gosterilen + i) {
      lcd.print(">");
    } else {
      lcd.print(" ");
    }
    lcd.print(items[ilk_gosterilen + i]);
    lcd.print(" ");
    lcd.print(miktar[ilk_gosterilen + i]);
  }
}

void toplamFiyatGoster() {
  float toplam_fiyat = 0;

  for (int i = 0; i < 5; i++) {
    toplam_fiyat += baslangic_sayisi[i] * baslangic_fiyat[i];
  }
  for (int i = 0; i < 5; i++) {
    toplam_fiyat += anayemek_sayisi[i] * anayemek_fiyat[i];
  }
  for (int i = 0; i < 5; i++) {
    toplam_fiyat += corba_sayisi[i] * corba_fiyat[i];
  }
  for (int i = 0; i < 5; i++) {
    toplam_fiyat += tatli_sayisi[i] * tatli_fiyat[i];
  }
  for (int i = 0; i < 5; i++) {
    toplam_fiyat += icecek_sayisi[i] * icecek_fiyat[i];
  }

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("Toplam Fiyat:");
  lcd.setCursor(0, 1);
  lcd.print(toplam_fiyat);
  delay(2000); // Toplam fiyatı 2 saniye göster
  anaMenuGoster(); // Ana menüye dön
}

void loop() {

  if (tus_oku() == secim && menu == 0) { // Ana menüde seçim tuşuna basıldıysa alt menüye gir
    menu = 1;
    delay(300);
  }

  while (menu == 1) {
    if (tus_oku() == sag && durum < 4) durum++; // Sağ tuşuna basılırsa menüde ilerle
    if (tus_oku() == sol && durum > 0) durum--; // Sol tuşuna basılırsa menüde geri git
    anaMenuGoster();
    delay(300);
    if (tus_oku() == secim) {
      menu = 2;
      alt_durum = 0;
      ilk_gosterilen = 0;
      delay(300);
    }
  }

  const char* baslangiclar[] = {"Humus:20", "Borek:25", "Haydari:30", "Mucver:23", "Ezme:20"};
  const char* anayemekler[] = {"Iskender:20", "Kebab:25", "Karniyarik:30", "Kofte:23", "Pilav:20"};
  const char* corbalar[] = {"Mercimek:20", "Ezogelin:25", "Tarhana:30", "Tavuk Suyu:23", "Sehriye:20"};
  const char* tatlilar[] = {"Tulumba:15", "Baklava:20", "Kazandibi:10", "Ekler:23", "Sutlac:12"};
  const char* icecekler[] = {"Su:15", "Ayran:20", "Cay:10", "Limonata:23", "Kola:9"};

  while (menu == 2) {// Alt menüde olduğumuz sürece bu döngü çalışır.
    if (tus_oku() == ust && alt_durum > 0) {//yukarı tuşuna basılmışsa ve alt menüdeki pozisyon sıfırdan büyükse.
      alt_durum--;// Alt menüdeki pozisyon bir azaltılır.
      if (alt_durum < ilk_gosterilen) {
        ilk_gosterilen--;//Ekranda gösterilen ilk öğe bir azaltılır.
      }
    }

    if (tus_oku() == alt && alt_durum < (durum == 0 ? sizeof(baslangiclar)/sizeof(baslangiclar[0]) : 
                                         (durum == 1 ? sizeof(anayemekler)/sizeof(anayemekler[0]) : 
                                         (durum == 2 ? sizeof(corbalar)/sizeof(corbalar[0]) : 
                                         (durum == 3 ? sizeof(tatlilar)/sizeof(tatlilar[0]) : 
                                         sizeof(icecekler)/sizeof(icecekler[0]))))) - 1) {
      alt_durum++; //Alt menüdeki pozisyon bir artırılır.
      if (alt_durum > ilk_gosterilen + 1) {
        ilk_gosterilen++;//Ekranda gösterilen ilk öğe bir artırılır.
      }
    }
     // Menü kategorisine göre alt menü öğelerini ve miktarlarını gösterir.
    if (durum == 0) {
      altMenuGoster(baslangiclar, sizeof(baslangiclar)/sizeof(baslangiclar[0]), baslangic_sayisi);
    } else if (durum == 1) {
      altMenuGoster(anayemekler, sizeof(anayemekler)/sizeof(anayemekler[0]), anayemek_sayisi);
    } else if (durum == 2) {
      altMenuGoster(corbalar, sizeof(corbalar)/sizeof(corbalar[0]), corba_sayisi);
    } else if (durum == 3) {
      altMenuGoster(tatlilar, sizeof(tatlilar)/sizeof(tatlilar[0]), tatli_sayisi);
    } else if (durum == 4) {
      altMenuGoster(icecekler, sizeof(icecekler)/sizeof(icecekler[0]), icecek_sayisi);
    }

    delay(300);

    if (tus_oku() == secim) { //Eğer seçim tuşuna basılmışsa.
      if (durum == 0) {
        baslangic_sayisi[alt_durum]++;//Başlangıçlar kategorisinde miktar bir artırılır.
      } else if (durum == 1) {
        anayemek_sayisi[alt_durum]++;
      } else if (durum == 2) {
        corba_sayisi[alt_durum]++;
      } else if (durum == 3) {
        tatli_sayisi[alt_durum]++;
      } else if (durum == 4) {
        icecek_sayisi[alt_durum]++;
      }
      delay(300); // Seçim yapıldıktan sonra bekle
    }
    
    if (tus_oku() == sol) { //Eğer sol tuşuna basılmışsa.
      if (durum == 0 && baslangic_sayisi[alt_durum] > 0) { //Başlangıçlar miktar sıfırdan büyükse bir azaltılır.
        baslangic_sayisi[alt_durum]--;
      } else if (durum == 1 && anayemek_sayisi[alt_durum] > 0) {
        anayemek_sayisi[alt_durum]--;
      } else if (durum == 2 && corba_sayisi[alt_durum] > 0) {
        corba_sayisi[alt_durum]--;
      } else if (durum == 3 && tatli_sayisi[alt_durum] > 0) {
        tatli_sayisi[alt_durum]--;
      } else if (durum == 4 && icecek_sayisi[alt_durum] > 0) {
        icecek_sayisi[alt_durum]--;
      }
      delay(300); // Geri alma işlemi yapıldıktan sonra bekle
    }

    if (tus_oku() == sag) {
      toplamFiyatGoster(); // Toplam fiyatı göster
      menu = 0; // Ana menüye dön
      ilk_gosterilen = 0;
      alt_durum = 0;
      delay(300);
    }
  }
}
