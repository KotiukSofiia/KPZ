# Lab 6 "Генератор QR-кодів" - Котюк Софія ІПЗ-23-1

## ФУНКЦІОНАЛЬНІСТЬ

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


## PROGRAMMING PRINCIPLES

1. Single Responsibility Principle (SRP) - кожен клас має лише одну відповідальність.
-  [HistoryQueryService](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/HistoryQueryService.cs) відповідає виключно за логіку фільтрації історії QR-кодів.
-  [QrInputModel](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Models/QrInputModel.cs) містить лише дані введення користувача.

2. Don't Repeat Yourself (DRY) - повторюваний код винесений у сервіси.
- Генерація зображення QR-коду реалізована в [QRService](https://github.com/KotiukSofiia/KPZ/tree/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services).

3. KISS (Keep It Simple, Stupid) - контролери мають просту структуру — без зайвої логіки.
- [HomeController](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Controllers/HomeController.cs#L30-L64
) делегує складні дії до сервісів.

4. YAGNI (You Aren’t Gonna Need It) - реалізовано тільки ті функції, які дійсно потрібні — без зайвих абстракцій чи ускладнень.
- Наприклад, форматування контенту обмежено лише потрібними типами (SMS, Email, WiFi тощо).

6. Separation of Concerns (SoC) - чітке розділення відповідальностей:
- Controllers — викликають сервіси
- Services — обробляють логіку
- Models/ViewModels — представляють дані


## REFACTORING TECHNIQUES

1. Strategy Pattern
Використовується для форматування QR-контенту залежно від типу([HomeController.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Controllers/HomeController.cs)).
```
string content = _formatter.Format(input);
```

2. Service Layer Pattern
Сервіси інкапсулюють бізнес-логіку, що спрощує контролери.
- [HistoryQueryService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/HistoryQueryService.cs)
```
public List<QrCodeRecord> GetFiltered(...) { ... }
```
- [QRService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QRService.cs) – генерація зображень
- [ZipService.c](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/ZipService.cs)s – архівація

3. Dependency Injection (DI)
Всі сервіси додаються через DI — централізоване керування залежностями.
- [Program.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Program.cs)
```
services.AddScoped<IQRService, QRService>();
services.AddScoped<ZipService>();
```


## DESIGN PATTERNS

1. Extract Method.
Складні ділянки коду винесено в окремі методи([QRService.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QRService.cs))

```
public string GenerateQrCode(...) { ... }
public MemoryStream GenerateQrImageStream(...) { ... }
```

2. Introduce Parameter Object.
Використання [QrInputModel](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Models/QrInputModel.cs) замість передачі безлічі параметрів окремо:
```
public IActionResult Generate(QrInputModel input, string format = "png") { ... }
```

3. Replace Magic Numbers with Symbolic Constants([QrInputModel.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Models/QrInputModel.cs)).
```
[Range(100, 1000, ErrorMessage = "Розмір має бути від 100 до 1000")]
public int Size { get; set; } = 300;
```
4. Encapsulate Field / Encapsulate Collection([HistoryViewModel.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Models/ViewModels/HistoryViewModel.cs)).
```
public List<QrCodeRecord> Records { get; set; } = new();
```
5. Replace Conditional with Polymorphism (опосередковано).
Тип QR-коду обробляється за допомогою [IQrContentFormatterService](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Services/QrContentFormatterService.cs), замість if/else у [контролері](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%206/QrCodeGenerator/QrCodeGenerator/Controllers/HomeController.cs).
```
string content = _formatter.Format(input);
```



![telegram-cloud-photo-size-2-5285071757717402129-y](https://github.com/user-attachments/assets/031ba549-0724-42d2-9ac8-7eac5b2c57c7)

