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
* 	Profil Bilgilerim: Kendi hesap bilgilerinizi görüntüleyebilir ve güncelleyebilirsiniz.
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

## Proje Görselleri
![2025-02-25_23-12-23](https://github.com/user-attachments/assets/2becfa20-c9b1-48eb-8228-fd38d598e4dd)

![2025-02-25_23-16-29](https://github.com/user-attachments/assets/23830ecc-1f00-4b60-9fac-96675fa6e8b7)

![2025-02-25_23-16-51](https://github.com/user-attachments/assets/3c07ce4f-be49-48ab-9488-3207b57ba8c9)

![2025-02-25_23-17-32](https://github.com/user-attachments/assets/57ff28c3-2223-46e8-b771-2e2996c77f1a)

![2025-02-25_23-17-53](https://github.com/user-attachments/assets/b68440fe-8727-46ff-aa64-77d232b473b6)

![2025-02-25_23-15-56](https://github.com/user-attachments/assets/7f51fa23-bc8f-4109-9570-143f6ae91f27)

![2025-02-25_23-15-50](https://github.com/user-attachments/assets/9ca0fd60-62e5-4984-9ebf-b853d928cc11)


### Admin Paneli
![2025-02-25_23-09-03](https://github.com/user-attachments/assets/a234a7d7-48dd-4aca-962e-ffa009e9e4dc)

![2025-02-25_23-07-23](https://github.com/user-attachments/assets/abca106b-8e08-4ad0-8841-e82ef878dcde)

![2025-02-25_23-07-58](https://github.com/user-attachments/assets/fe63322b-34fe-4646-ae7e-3b6c75a4c18a)

![2025-02-25_23-08-41](https://github.com/user-attachments/assets/388bb7be-52f5-4927-a248-8825f5f7d4df)

![2025-02-25_23-09-21](https://github.com/user-attachments/assets/c0d73a60-25ae-4735-b9be-5d9c99d80112)

### Manager Paneli
![2025-02-25_23-13-17](https://github.com/user-attachments/assets/0a2f091e-637e-44f5-a8b0-80ccbc674a46)

![2025-02-25_23-13-39](https://github.com/user-attachments/assets/8f58180e-7d36-4018-afb0-a3d7bf41c770)

### User Paneli
![2025-02-25_23-15-01](https://github.com/user-attachments/assets/34f6009c-b984-4b76-a7a2-07fc69c1e778)

![2025-02-25_23-14-47](https://github.com/user-attachments/assets/002f20e0-105d-4af3-ade6-03ad1b17e156)

