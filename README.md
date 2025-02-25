# Cental Araç Kiralama Sitesi

Cental Araç Kiralama sitesi, kullanıcıların farklı araç modellerini detaylı bir şekilde incelemelerine, karşılaştırmalar yapmalarına ve kolayca rezervasyon yapmalarına olanak tanır. Kullanıcılar, siteye yönelik yorumlar bırakabilir ve araçlara değerlendirme yaparak deneyimlerini paylaşabilirler. Ayrıca siteyle ilgili her türlü sorusunu doğrudan mesaj yoluyla hızlıca ileterek destek alabilirler. Kayıtlı kullanıcılar ise, profil oluşturup bilgilerini güncelleyebilir, geçmiş rezervasyonlarını görüntüleyip yönetebilir ve kiraladıkları araçlar hakkında geri bildirimde bulunabilirler.

## Teknik Yapı :
Site tasarımında .NET Core ile N Katmanlı Mimari prensiplerine uygun bir yapı benimsenmiş ve ASP.NET Core Web App (Model-View-Controller) mimarisi kullanılmıştır. Sistemin temel katmanları, Entity, Data Access Layer, Business Layer ve DTO katmanlarından oluşmaktadır. Entity Framework Core’un Code-First Migration yaklaşımıyla veritabanı tasarlanmış ve CRUD işlemleriyle birlikte, entity’lere özgü metotlar eklenerek sistemin işleyişi daha verimli hale getirilmiştir. Kullanıcı yönetimi için Identity Kütüphanesi entegre edilerek, kullanıcıların güvenli bir şekilde siteye kayıt olup giriş yapmaları sağlanmıştır. Ayrıca, siteye esneklik kazandırmak için Admin, Manager ve User olmak üzere üç farklı panel tasarlanmış ve her panelin yetkileri özel olarak belirlenmiştir.

### Admin Paneli Özellikleri:
*	Roller & Rol Atama: Kullanıcılara farklı yetkiler tanımlayarak, rollerini yönetebilirsiniz.
*	Dashboard: Sistemdeki genel istatistikler ve önemli verileri görüntüleyebilirsiniz.
*	Rezervasyonlar: Yapılan rezervasyonları görüntüleyebilir, onaylayabilir, bekletebilir veya iptal edebilirsiniz.
*	Mesajlar: Kullanıcılardan gelen mesajları görüntüleyip yönetebilirsiniz.
*	Araç Puanlamaları & Değerlendirmeler: Kullanıcıların araçlar hakkında verdiği puanları ve yazdığı değerlendirmeleri yönetebilirsiniz.
*	Markalar & Arabalar: Araç markalarını ve sisteme kayıtlı araçları yönetebilirsiniz.
*	Hakkımızda, Öne Çıkan Alan, Özellikler, Süreçler & Hizmetler ve Genel Bilgiler: Bu sayfalarda CRUD işlemleri yapabilir, içerikleri güncelleyebilirsiniz.

### Manager Paneli Özellikleri:
* Profil Bilgilerim: Kendi hesap bilgilerinizi görüntüleyebilir ve güncelleyebilirsiniz.
*	Sosyal Medya Hesaplarım: Sosyal medya hesaplarınızı listeleyebilir, ekleyebilir, güncelleyebilir veya silebilirsiniz.
*	Rezervasyonlar: Gelen rezervasyon taleplerini görüntüleyebilir ve yönetebilirsiniz.

### User Paneli Özellikleri:
*	Profil Bilgileri: Kendi hesap bilgilerinizi görüntüleyebilir ve güncelleyebilirsiniz.
*	Rezervasyonlarım: Önceden yaptığınız rezervasyonların onay durumlarını görüntüleyebilir ve yönetebilirsiniz.
*	Araç Değerlendir: Kiraladığınız araçlar hakkında puanlama ve değerlendirme yapabilirsiniz.

### Kullanılan Kütüphane ve Paketler:
*	Identity Kütüphanesi
*	AutoMapper
*	FluentValidation
*	SweetAlert
*	PagedList
  
Ayrıca, ViewComponents yapısı ve Lazy Loading gibi gelişmiş tekniklerle site performansı optimize edilmiştir.
	
