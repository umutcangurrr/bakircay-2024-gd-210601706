# bakircay-2024-gd-210601706
Nasıl Oynanır?
Oyun sahnesinde iki adet mat bulunmaktadır.
Oyuncu, her bir matın üzerine aynı anda yalnızca bir nesne koyabilir.
Eğer iki matın üzerindeki nesneler eşleşirse (örneğin isimleri aynıysa), bu nesneler yok edilir.
Oyuncu tüm nesneleri eşleştirdiğinde oyun sona erer.

Proje Özellikleri
Mat Sistemi: Her mat üzerine aynı anda sadece bir nesne koyulabilir.
Eşleştirme Mantığı: İki mat üzerindeki nesneler isimlerine göre eşleştirilir (örneğin "Crown" ve "Crown (1)").
Nesne Manipülasyonu: Fare hareketleriyle nesneler taşınabilir ve yönlendirilebilir.
Nesne Yok Etme: Eşleşen nesneler otomatik olarak yok edilir.
Oyun Bitişi: Belirtilen sayıda nesne yok edildiğinde oyun otomatik olarak durur. (Projenin ilerleyen versiyonlarında her sahnenin kendinw ait nesne sayısı olacaktır ve bu nesne sayılarına ulaşıldığında sahne tamamlanıp diğer sahneye geçiş sağlanacaktır.)

Teknik Detaylar
SelectionMat.cs:
Matların üzerindeki nesneleri kontrol eder ve eşleştirme işlemini gerçekleştirir.
GameManager.cs:
Oyundaki genel yönetimi ve oyun bitişini kontrol eder.
DetectObject.cs:
Fare hareketlerini algılar ve nesneler üzerinde fiziksel etkileşim sağlar.
Nesneler seçildiğinde onlara kuvvet uygular.
TouchManager.cs:
Fare veya dokunmatik girdileri işleyen bir yönetim sistemi.
Fare basma, sürükleme ve bırakma olaylarını algılar ve diğer scriptlere iletir.
