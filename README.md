### Meyve Eşleştirme Oyunu - README

## Oyun Hakkında
Bu oyun, oyuncuların meyve eşleştirmesi yaparak puan kazandığı bir oyun deneyimi sunar. Oyun içinde belirli skiller (Q, W, E) kullanarak oyunculara ekstra avantajlar sağlanır. Oyuncular, meyveleri doğru şekilde eşleştirerek ve çeşitli skilleri kullanarak yüksek puanlar elde etmeye çalışır.

Temel Özellikler
Meyve Eşleştirme: Oyuncular, kabın içine düşen meyveleri eşleştirerek puan toplar. Eğer iki meyve aynıysa, bu eşleşme geçerli olur ve oyuncuya puan kazandırır.
Puan Sistemi: Eşleşen meyveler, oyuncuya puan kazandırır. Puanlar, meyve türüne göre değişir ve oyuncunun toplam puanı ekranda görüntülenir.
UI Göstergeleri: Oyuncunun toplam puanı, ekranda bir TextMesh Pro UI öğesi ile gösterilir.
Skiller
Oyun içerisinde üç farklı skill bulunmaktadır: Q, W, ve E. Bu skiller, oyunculara farklı avantajlar sağlar ve belirli zaman dilimlerinde kullanılabilirler.

1. Q Skilli
Ne Yapar: Q tuşuna basıldığında, "Q Skill" aktif olur ve oyuncunun puanları 2 katına çıkar. Bu skill 10 saniye boyunca geçerli olur.
Kullanılabilirlik: Q skilli aktif olduğunda, Q UI görseli kaybolur. 10 saniye sonra skill sona erer ve 10 saniye daha beklenir, ardından Q tekrar kullanılabilir hale gelir.
UI Görseli: Q skillini aktive etmek için ekranın köşesinde bir görsel bulunur. Skill aktif olduğunda, bu görsel kaybolur.
2. W Skilli
Ne Yapar: W tuşuna basıldığında, "Golden Apple" adlı özel bir meyve spawn edilir. Bu meyve, oyuncuya ekstra puan kazandırabilir.
Kullanılabilirlik: W skilli 15 saniye boyunca devre dışı bırakılır ve bu süre zarfında W skillini tekrar kullanmak mümkün değildir. 15 saniye sonunda skill tekrar aktif olur ve UI görseli geri gelir.
UI Görseli: W skillinin aktif olduğu anda bir UI görseli kaybolur ve 15 saniye sonunda geri gelir.
3. E Skilli
Ne Yapar: E tuşuna basıldığında, tüm meyvelerden 2 tane daha spawn edilir. Bu skill, 60 saniyede bir kullanılabilir.
Kullanılabilirlik: E skilli aktif olduğunda, 60 saniye boyunca tekrar kullanılmaz. Skill sona erdiğinde, UI görseli kaybolur ve 60 saniye sonra geri gelir.
UI Görseli: E skillini aktive etmek için ekranın köşesinde bir görsel bulunur. Skill aktif olduğunda, bu görsel kaybolur.
Oyun Mekanikleri
Meyve Ekleme: Meyveler, kabın içine düştükçe, oyuncu bu meyveleri eşleştirmeye çalışır. Aynı meyveler eşleştiğinde, oyuncuya puan kazandırılır.
Farklı Harfler: Eğer iki meyve farklıysa, bu meyveler sabit bir pozisyona ışınlanır ve oyuncu bunları yeniden kullanamaz.
Puan Kazanma: Eşleşen meyveler için puanlar toplanır ve toplam puan, ekranda güncellenir.
Kontroller
Q Tuşu: Q skilli aktif eder ve puanları 2x yapar. 10 saniye boyunca geçerlidir.
W Tuşu: W skilli aktif eder ve Golden Apple spawn eder. 15 saniye boyunca geçerlidir.
E Tuşu: E skilli aktif eder ve tüm meyvelerden 2 tane daha spawn eder. 60 saniye bekleme süresi vardır.
İpuçları
Q, W ve E skillerini stratejik olarak kullanarak daha fazla puan kazanabilirsiniz. Özellikle Q ve E skilleri, doğru zamanda kullanıldığında yüksek puanlar kazandırabilir.
Meyve eşleştirmelerini dikkatli yapın, çünkü aynı meyveler eşleştiğinde daha fazla puan kazanırsınız.

Oyun Link: https://umutcangurrr.itch.io/matchgame