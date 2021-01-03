# Web Programlama dersi proje ödevi

* Arif Damar - G171210009 - 2B
* Ömer Çağrı Şayir - G171210028 - 2C

Proje açıklaması Youtube linkleri: 

Arif Damar anlatımı: https://youtu.be/junm0SoALS8

Ömer Çağrı Şayir anlatımı: https://youtu.be/dZu7xZzfDrI

## Açıklama

Bu blog projesi Sakarya Üniversitesi Bilgisayar Mühendisliği Web Programlama dersi için hazırlanmıştır. 
Bu projenin amacı, Web Programlama dersinde teorik ve pratik olarak öğrenilen bilgilerin, gerçek bir probleme uygulanarak bu probleme çözüm üreten bir web projesi geliştirilmesidir.
Bu projede kendimizi tanıtan dinamik olarak içerik ve menü oluşturabilecek, blok yazılarına yorum yapılabilen kişisel bir web sitesi uygulaması yaptık. 

## Projede Kullanılan Teknolojiler
* Asp.net Core 3.1 MVC
* C#
* Veritabanı
* Entity Framework Core ORM
* Bootstrap Tema
* HTML5
* CSS3
* JavaScript
* JQUERY

## Proje Özellikleri
* Front-End
* Admin Paneli var.
* Kullanıcıların üye olacakları sayfa var.
* Çok dillidir (Türkçe - İngilizce)



Proje’de Asp.Net Identity ile birlikte eklenen AspNetUsers, AspNetUserRoles,
AspNetRoles, AspNetRoleClaims, AspNetUserLogins, AspNetUserClaims ve
AspNetUserTokens tabloları haricinde Blogs, CategoryBlog, Categories ve Comments
tabloları bulunmakta.


Identity haricindeki ilişkileri özetlemek gerekirse;

1- 1 kullanıcının çok blogu olabilir

2- 1 blog 1 kullanıcıya ait olabilir

3-1 blogun çok yorumu olabilir

4- 1 yorum 1 bloga ait olabilir

5- 1 yorumun çok yorumu olabilir

6- 1 yorum 1 ebeveyn yoruma ait olabilir

7- 1 blogun çok kategorisi olabilir

8- 1 kategorinin çok blogu olabilir

Bloglar var kategoriler arasında çoka çok ilişki bulunduğundan araya 3. Bir
CategoryBlogs tablosu eklenir
