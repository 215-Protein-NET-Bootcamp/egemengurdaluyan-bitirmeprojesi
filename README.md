# 215. Protein .NET Bootcamp Bitirme Projesi

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

# Servisler
## Token Servisi
![token](https://user-images.githubusercontent.com/82399866/185810909-9b1e2f0c-c197-4708-b4cb-19d13972a401.png)

## Account Servisleri
![account](https://user-images.githubusercontent.com/82399866/185810918-894cf264-19d7-4fb8-ab4f-948684dbd3f3.png)

## Product Servisleri
![product](https://user-images.githubusercontent.com/82399866/185810922-d90c50cf-190c-4cf6-a627-bc007cfd6bc1.png)

## Category Servisleri
![Category](https://user-images.githubusercontent.com/82399866/185810926-953177aa-fec9-46e0-9065-a2ae687e0d23.png)

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

