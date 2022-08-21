
<img src="https://media-exp1.licdn.com/dms/image/C4D0BAQEZxIbp8k1aXw/company-logo_200_200/0/1617369316714?e=2147483647&v=beta&t=JoshxzaFqO5pjEGJFfYNBpaR-P0U7lHM1shYJdR9G_0" width="70px"></img>
<p align="center">215. Protein .NET Bootcamp Bitirme Projesi · Egemen Gürdal UYAN </p>

# About the Project
Geliştirilen projede; 
Kullanıcıların sistemde kayıtlı ürünlere, isterlerse teklif vererek ulaşabilimesini veya direkt olarak satın almalarını amaçlamaktadır.


# Technologies
* .NET Core
* Swagger
* EntityFrameworkCore
* Etherial Mail
* PostgreSQL
* MailKit
* AutoMapper
* SeriLog



# Veritabanı Tabloları

## Account Tablosu
<table>
  <tr>
    <th>Id</th>
    <th>Email</th>
    <th>Password</th>
    <th>LastActivity</th>
    <th>IsActive</th>
    <th>CreatedAt</th>
  </tr>
  <tr>
    <td>integer</td>
    <td>text</td>
    <td>text</td>
    <td>timestamp with time zone</td>
    <td>boolean</td>
    <td>timestamp with time zone</td>
  </tr>
</table>

## Product Tablosu
<table>
  <tr>
    <th>ProductId</th>
    <th>Name</th>
    <th>Price</th>
    <th>IsOfferable</th>
    <th>IsSolid</th>
    <th>CreatedAt</th>
    <th>Description</th>
    <th>Trademark</th>
    <th>CategoryId</th>
    <th>ColorId</th>
    <th>AccountId</th>
    <th>OfferedValue</th>
    <th>Image</th>
  </tr>
  <tr>
    <td>integer</td>
    <td>text</td>
    <td>double precision</td>
    <td>boolean</td>
    <td>boolean</td>
    <td>timestamp with time zone</td>
    <td>text</td>
    <td>text</td>
    <td>integer</td>
    <td>integer</td>
    <td>integer</td>
    <td>integer</td>
    <td>byte array</td>
  </tr>
</table>

## Category Tablosu
<table>
  <tr>
    <th>CategoryId</th>
    <th>Name</th>
  </tr>
  <tr>
    <td>integer</td>
    <td>text</td>
  </tr>
</table>

## Color Tablosu
<table>
  <tr>
    <th>ColorId</th>
    <th>Name</th>
  </tr>
  <tr>
    <td>integer</td>
    <td>text</td>
  </tr>
</table>


# Servisler
## Token Servisi
* Bu serviste kullanıcının sistemde bulunan email ve şifresi ile JWT Token üretilip tüm authentication gerektiren servislerde Bearer token olarak eklenilmesi sağlanmaktadır.
![token](https://user-images.githubusercontent.com/82399866/185810909-9b1e2f0c-c197-4708-b4cb-19d13972a401.png)

## Account Servisleri
* Bu serviste kullanıcıların hesapları için oluşturulmuş CRUD işlemleri yer almaktadır. 
* Account oluşturma hariç diğer tüm servisler authentication gerektiren servislerdir.
* Şifre değiştirme, hesap silme, hesap üzerinde yapılmış olan teklifleri görüntüleme ve tüm hesapları görüntüleme.
![account](https://user-images.githubusercontent.com/82399866/185810918-894cf264-19d7-4fb8-ab4f-948684dbd3f3.png)

## Product Servisleri
* Bu serviste ürünler için oluşturulmuş ekleme ve silme işlemleri yer almaktadır.
* Aynı zamanda kullanıcıların yaptıkları teklif verme, teklif iptali ve ürün satın alma işlemlerinin gerçekleştiği yerlerdir.
![product](https://user-images.githubusercontent.com/82399866/185810922-d90c50cf-190c-4cf6-a627-bc007cfd6bc1.png)

## Category Servisleri
* Bu serviste kategoriler için oluşturulmuş CRUD işlemleri yer almaktadır.
* Ürünlerin kayıtları esnasında kullanılması için ihtiyaç duyulan kategori listesi de tüm kategorileri görüntüleme işlemi sayesinde sağlanmaktadır.
![Category](https://user-images.githubusercontent.com/82399866/185810926-953177aa-fec9-46e0-9065-a2ae687e0d23.png)


