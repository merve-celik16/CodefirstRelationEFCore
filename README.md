# Code First Relation - Entity Framework Core #
Bu proje, Entity Framework Core kullanılarak Code First yaklaşımıyla bir veritabanı ve ilişkiler oluşturmayı amaçlamaktadır. 
Projede Users ve Posts tabloları arasında bire çok (one-to-many) ilişki kurulmuştur.
Her kullanıcı birden fazla gönderiye sahip olabilir, ancak her gönderi yalnızca bir kullanıcıya aittir.

 ## 📂 Proje İçeriği ##
 
### 1. User Tablosu

| Alan      | Veri Tipi | Açıklama                           |
|-----------|-----------|------------------------------------|
| Id        | int       | Birincil anahtar, otomatik artar. |
| Username  | string    | Kullanıcının kullanıcı adı.        |
| Email     | string    | Kullanıcının e-posta adresi.       |


### 2. Post Tablosu

| Alan     | Veri Tipi | Açıklama                                   |
|----------|-----------|--------------------------------------------|
| Id       | int       | Birincil anahtar, otomatik artar.          |
| Title    | string    | Gönderinin başlığı.                        |
| Content  | string    | Gönderinin içeriği.                        |
| UserId   | int       | Gönderinin ait olduğu kullanıcının kimliği.|

### 3. Veritabanı
 - Veritabanı İsmi: `` PatikaCodeFirstDb2 ``
 - Context Sınıfı: `` PatikaSecondDbContext ``
 - Tablolar:
    * Users
    * Posts

 ## 🛠️ Kullanılan Teknolojiler
C#: Programlama dili.
Entity Framework Core: ORM (Object-Relational Mapping) aracı.
SQL Server: Veritabanı yönetim sistemi.

 ## 🚀 Kurulum ve Çalıştırma
 
1. Gerekli NuGet Paketlerini Yükleme
Proje dizininde aşağıdaki komutları çalıştırarak gerekli paketleri yükleyin:

````
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL 
````

2. Veritabanı Oluşturma
EF Core ile Code First yaklaşımında veritabanını oluşturmak için şu adımları takip edin:

 - Migration Oluşturma
``
dotnet ef migrations add InitialCreate
``
 - Veritabanını Güncelleme
``
dotnet ef database update
``




