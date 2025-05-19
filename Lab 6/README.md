# Lab 6 "Генератор QR-кодів" - Котюк Софія ІПЗ-23-1

## Функціональність

### 1. Інтерфейс користувача

Головний екран:
- Поле для введення тексту або URL
- Випадаючий список для вибору типу QR-коду (текст, SMS, Wi-Fi тощо)
- Вибір кольору QR-коду та фону
- Вибір розміру QR-коду (у px)
- Вибір формату (PNG, BMP)
- Кнопка “Згенерувати QR”
- Відображення згенерованого QR-коду в режимі реального часу
- Кнопка “Очистити”
- Посилання на екран “Історія”

Екран історії QR-кодів:
Таблиця з історією згенерованих кодів:
  - Зображення QR-коду
  - Контент (текст/посилання)
  - Тип, формат, дата генерації
- Кнопки: “Переглянути”, “Копіювати зображення”, “Email”, “Telegram”, “Видалити”
- Кнопка “Очистити всю історію”

Додатково:
- Підтримка темної і світлої теми

### 2. Логіка генерації QR-кодів

Генерація:
- Валідація введеного контенту
- Генерація QR-коду за допомогою бібліотеки
- Миттєве оновлення QR після зміни параметрів (текст, кольори, розмір)
  
Збереження:
- Збереження у вибраному форматі (PNG або BMP)
- Ім’я файлу автоматично формується на основі дати й часу
- Копіювання QR до буфера обміну
  
Історія:
- Додавання запису при кожному збереженні
- Фіксація тексту, дати, типу коду та формату
- Можливість видалення окремих записів або всієї історії

### 3. Збереження даних

- Зберігання історії QR-кодів у базі даних
- Автоматичне завантаження історії при запуску
- Очищення історії за кнопкою


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
 > [/Migrations](https://github.com/KotiukSofiia/KPZ/tree/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Migrations),
 > [AppDbContext.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Models/AppDbContext.cs)

- **Facade Pattern** – сервіси `ZipService` і `PdfService` приховують складність створення файлів  
  > [ZipService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/ZipService.cs)  
  > [PdfService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/PdfService.cs)

![telegram-cloud-photo-size-2-5285071757717402129-y](https://github.com/user-attachments/assets/031ba549-0724-42d2-9ac8-7eac5b2c57c7)

