### Meyve Eşleştirme Oyunu - README
Oyun Hakkında
Bu oyun, oyuncuların meyve eşleştirmesi yaparak puan kazandığı ve çeşitli butonlarla (skiller) ekstra avantajlar elde edebildiği bir oyun deneyimi sunar. Oyuncular, meyveleri doğru şekilde eşleştirerek ve farklı butonları (x2 Puan, Bonus Obje Yarat, Objeleri Tekrar Düşür) kullanarak yüksek puanlar elde etmeye çalışır.

Temel Özellikler
Meyve Eşleştirme

Meyveler, bir “kaba” düştükçe eşleşmeye çalışır.
Aynı harfle başlayan iki meyve eşleştiğinde, oyuncuya puan kazandırır.
Puan Sistemi

Eşleşen meyveler, türlerine (baş harflerine) göre farklı puan değerlerine sahiptir.
Toplam puan, ekranda bir TextMesh Pro UI öğesi ile anlık olarak gösterilir.
UI Göstergeleri

Oyunun üst veya alt kısmında, toplam puan ve butonların (x2 Puan, Bonus Obje, Objeleri Tekrar Düşür) durumu bulunur.
Butonlar (Skiller)
Oyunda üç farklı buton vardır. Her biri belirli bir süre ve cooldown mantığına sahiptir.

1. x2 Puan Butonu
Ne Yapar:
Bu butona bastığınızda, x2 Puan skilli devreye girer.
10 saniye boyunca kazandığınız tüm puanlar iki katına çıkar.
Kullanılabilirlik:
10 saniyelik aktif süreden sonra skill biter ve 10 saniyelik bir bekleme (cooldown) devreye girer.
Cooldown tamamlandığında buton tekrar görünür ve basılabilir hale gelir.
UI Durumu:
Skill aktif olduğunda, x2 Puan butonu gizlenir.
Cooldown bittiğinde buton geri gelir.
2. Bonus Obje Yarat Butonu
Ne Yapar:
Bu butona bastığınızda, oyuna “Lahana” adlı özel bir meyve eklenir.
Lahana, yüksek puan potansiyeli sağlar.
Kullanılabilirlik:
Butona basıldıktan sonra, 15 saniye boyunca tekrar kullanılamaz.
15 saniye sonunda buton yeniden görünür ve aktif hale gelir.
UI Durumu:
Butona basar basmaz buton kaybolur.
15 saniye sonra tekrar ortaya çıkar.
3. Objeleri Tekrar Düşür Butonu
Ne Yapar:
Bu butona bastığınızda, tüm meyvelerden 2’şer tane daha sahnede belirmiş olur.
Böylece daha fazla eşleştirme şansı elde edersiniz.
Kullanılabilirlik:
Kullanıldıktan sonra, 60 saniyelik bir bekleme süresi başlar.
Bu süre bitene kadar buton tekrar tıklanamaz.
UI Durumu:
Aktifleştirilir edilmez buton gizlenir.
60 saniye sonunda yeniden görünür ve basılabilir hale gelir.
Oyun Mekanikleri
Meyve Ekleme:
Sahnede periyodik olarak veya butonlar sayesinde yeni meyveler spawn edilir.
Kabın içine düşen meyveler, eşleşme bekler.
Eşleşme Kuralları:
İki meyve aynı harfle başlıyorsa, eşleşir ve belirli bir puan kazandırır.
Farklı harfle başlıyorsa, ikisi de sabit bir pozisyona ışınlanarak pasifleştirilir.
Puan Kazanma:
Eşleşen meyveler, baş harfe göre puan ekler (A, B, C, vb.).
x2 Puan butonu aktifken eşleşirseniz, puanlar iki kat yazılır.
Kontroller
x2 Puan Butonu: Ekrandaki bu butona basıldığında, 10 saniye boyunca 2 kat puan kazanma aktif olur.
Bonus Obje Yarat Butonu: Bastığınızda, 15 saniyelik cooldown’a girer ve sahneye 2 adet Golden Apple eklenir.
Objeleri Tekrar Düşür Butonu: Bastığınızda, meyvelerden 2’şer tane daha spawn edilmesini sağlar ve 60 saniyelik cooldown’a girer.
(Oyun içerisinde klavye kullanımı kaldırıldı; artık tüm skilller bu UI butonları ile devreye girer.)

İpuçları
x2 Puan özelliğini, meyvelerin bolca eşleşeceği anlarda kullanmak en yüksek getiriyi sağlar.
Bonus Obje olarak gelen Golden Apple, diğer meyvelerden daha değerli olabilir.
Objeleri Tekrar Düşür butonunu, kabın içi boşalmaya başladığında veya hızlı puan artışı hedeflediğinizde kullanmak mantıklı olabilir.