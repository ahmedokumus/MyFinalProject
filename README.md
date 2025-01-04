# Yazılım Geliştirici Yetiştirme Kampı (.NET & ANGULAR) Final Projesi

Bu proje, [Engin Demiroğ](https://www.linkedin.com/in/engindemirog/)'un 2021 yılında YouTube'da canlı olarak yayınlanan Yazılım Geliştirici Yetiştirme Kampı kapsamında geliştirilen final projesidir.

📺 [Kurs Playlist'i](https://www.youtube.com/playlist?list=PLqG356ExoxZVN7rC0KmMo0lvECK97VRZg)

## Proje Yapısı

Proje, kurumsal yazılım mimarisi (N-Layer Architecture) prensiplerine uygun olarak geliştirilmiş olup, SOLID prensiplerine uygun şekilde tasarlanmıştır.

### Katmanlar

- **Core**: Projenin çekirdek katmanı. Tüm katmanlar tarafından kullanılan ortak kodları içerir.
  - Entity Framework Repository
  - Interceptor
  - Aspects (Caching, Validation, Transaction, Performance)
  - Security
  - Cross Cutting Concerns
  - Extensions
  - Utilities

- **Entities**: Veritabanı nesnelerinin bulunduğu katman
  - Concrete (Somut Nesneler)
  - DTOs (Data Transfer Objects)

- **DataAccess**: Veritabanı işlemlerinin yapıldığı katman
  - Abstract (Soyut Nesneler/Interfaces)
  - Concrete
    - EntityFramework
    - InMemory
    - Dapper
    - AdoNet

- **Business**: İş kurallarının bulunduğu katman
  - Abstract (Soyut Nesneler/Interfaces)
  - Concrete (İş Sınıfları)
  - Constants (Sabit Mesajlar)
  - DependencyResolvers
    - Autofac
  - ValidationRules
    - FluentValidation

- **WebAPI**: REST API katmanı
  - Controllers
  - Program.cs (Startup)

## Kullanılan Teknolojiler

- .NET 6.0
- Entity Framework Core 7.0.4
- Autofac 7.0.0 (IoC Container)
- FluentValidation
- JWT (JSON Web Token)
- Aspect Oriented Programming (AOP)
- Cross Cutting Concerns
  - Caching
  - Validation
  - Transaction
  - Performance
  - Logging

## Özellikler

- Generic Repository Pattern
- JWT ile Kimlik Doğrulama
- AOP ile Cross Cutting Concerns
- Autofac ile Dependency Injection
- FluentValidation ile Doğrulama
- Extensions
- Custom Error Middleware
- Custom Exception Handling

## Veritabanı

Proje Northwind veritabanını kullanmaktadır. Entity Framework Core ile Code First yaklaşımı kullanılmıştır.

## Kurulum

1. Projeyi klonlayın
2. Veritabanı bağlantı dizesini `DataAccess/Concrete/EntityFramework/NorthwindContext.cs` dosyasında güncelleyin
3. Package Manager Console'da `Update-Database` komutunu çalıştırın
4. Projeyi başlatın

## Katkıda Bulunma

1. Bu depoyu fork edin
2. Yeni bir özellik dalı oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Dalınıza push yapın (`git push origin feature/amazing-feature`)
5. Bir Pull Request oluşturun 