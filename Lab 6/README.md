# Lab 6 "Генератор QR-кодів"

## Функціональність

- Генерація QR-кодів із підтримкою форматів: **text, email, SMS, WiFi**  
  > [QrContentFormatterService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QrContentFormatterService.cs)

- Збереження даних про згенеровані QR-коди в базі даних  
  > [AppDbContext.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Data/AppDbContext.cs)

- Перегляд історії QR-кодів із фільтрацією та сортуванням  
  > [HistoryQueryService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/HistoryQueryService.cs)

- Експорт QR-кодів у **PDF**  
  > [PdfService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/PdfService.cs)

- Завантаження QR-кодів у **ZIP**  
  > [ZipService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/ZipService.cs)

- Привітальний інтерфейс Razor View  
  > [Index.cshtml](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Views/Home/Index.cshtml)


## Programming Principles

- **Single Responsibility Principle (SRP)** – кожен сервіс/клас відповідає за одну конкретну дію  
  > [QrContentFormatterService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QrContentFormatterService.cs),  
  > [HistoryQueryService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/HistoryQueryService.cs)

- **Open/Closed Principle (OCP)** – сервіси легко розширити без модифікації існуючого коду  
  > [IQrContentFormatterService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/IQrContentFormatterService.cs)
  > [QrContentFormatterService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QrContentFormatterService.cs)

- **Dependency Injection** – реалізовано через DI контейнер в .NET  
  > [Program.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Program.cs)

- **Separation of Concerns** – UI, логіка, сховище — розділено за окремими папками і відповідальністю  
  > Контролери → [`Controllers/`](https://github.com/KotiukSofiia/KPZ/tree/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Controllers)  
  > Сервіси → [`Services/`](https://github.com/KotiukSofiia/KPZ/tree/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services)  
  > Моделі → [`Models/`](https://github.com/KotiukSofiia/KPZ/tree/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Models)  
  > Інтерфейс → [`Views/`](https://github.com/KotiukSofiia/KPZ/tree/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Views)

- **DRY (Don't Repeat Yourself)** – повторна логіка винесена в окремі сервіси  
  > [ZipService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/ZipService.cs),  
  > [PdfService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/PdfService.cs)


## Refactoring Techniques

- **Extract Method** – виділення частин логіки в приватні методи  
  > [QrContentFormatterService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QrContentFormatterService.cs)  
  > [HistoryQueryService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/HistoryQueryService.cs)

- **Rename Variable** – покращено іменування змінних для підвищення читабельності  
  > [HomeController.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Controllers/HomeController.cs)

- **Inline Variable** – видалено непотрібні змінні, логіку інлайнено  
  > [QRService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QRService.cs)

- **Replace Magic Numbers with Constants** – заміна магічних чисел константами у форматерах  
  > [QrContentFormatterService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QrContentFormatterService.cs)

- **Consolidate Duplicate Conditional Fragments** – уникнення дублювання логіки в умовах  
  > [HistoryQueryService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/HistoryQueryService.cs)


## Design Patterns

- **Strategy Pattern** – для форматування контенту залежно від типу QR  
  > [QrContentFormatterService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QrContentFormatterService.cs)

- **Repository Pattern** – доступ до даних через Entity Framework Core  
  > [AppDbContext.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Data/AppDbContext.cs)

- **Facade Pattern** – сервіси `ZipService` і `PdfService` приховують складність створення файлів  
  > [ZipService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/ZipService.cs)  
  > [PdfService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/PdfService.cs)

