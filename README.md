 Dosya Yükleme ve Yönetim Uygulaması

Bu proje, kullanıcıların dosya yükleyebildiği, yüklenen dosyaları listeleyip silebildiği temel bir **dosya yönetim sistemidir**. 
Kullanıcı kimlik doğrulaması **JWT** (JSON Web Token) ile sağlanmaktadır.
Proje bir **.NET Web API** ve basit bir **HTML/JavaScript** istemcisi içerir.

🚀 Özellikler

- ✅ JWT ile kullanıcı kimlik doğrulama
- 📤 PDF, PNG, JPG dosyalarını yükleme
- 📄 Kullanıcıya ait dosyaları listeleme
- ❌ Dosya silme
- 🔒 Yetkisiz erişimlere karşı koruma

 🧰 Teknolojiler

- .NET 8 Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- HTML / JavaScript (Frontend)

 📦 Kurulum

1. Bu repoyu klonlayın:
   ```bash
   git clone https://github.com/kullanici-adi/proje-adi.git
   cd proje-adi
2.Gerekli NuGet paketlerini yükleyin:
    dotnet restore
4.Veritabanını oluşturun: 
    dotnet ef database update
5.API'yi çalıştırın:
    dotnet run
6.index.html ve files.html dosyalarını bir tarayıcıda açarak frontend arayüzünü kullanabilirsiniz.

Giriş Bilgileri:
   Kullanıcı Adı: Test
   Kullanıcı Şifresi:Test123
Dosya Yapısı:
  /Client        → HTML + JS dosyaları
  /Controllers   → API controller'ları
  /Models        → Veri modelleri
  /Data          → DbContext ve veri erişimi

  
  

