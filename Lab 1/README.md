# Software Construction Principles

## 1. DRY
Avoiding code duplication by using reusable classes and methods.
> Example: The [ReducePrice method](./Services/ProductService.cs#L7-L14) in ProductService avoids code duplication. This method ensures that price reduction logic is centralized and not repeated in multiple places.

## 2. KISS
The code is structured clearly and avoids unnecessary complexity.
  - Each class has a single responsibility.
  - Methods are short and perform one function at a time.
> Example: The [Warehouse](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%201/Models/Warehouse.cs) class stores products in a straightforward list. Instead of using complex data structures or patterns, a simple List<Product> is used to manage inventory efficiently.
   
## 3. YAGNI
The code includes only necessary features without premature optimizations.
> Example: The [Product](./Models/Product.cs#L5-L22) class does not include unused methods.Only essential fields and methods exist. No unnecessary setters or unused methods.

## 4. Composition Over Inheritance
Rather than using deep inheritance hierarchies, the project prefers composition.
> Example: [Product](./Models/Product.cs#L7-L9) class uses Money as a field instead of extending it. Instead of making Product inherit from Money, it simply contains an instance of Money, making the relationship more flexible.

## 5. Program to Interfaces, Not Implementations
The services interact with abstract structures rather than being tightly coupled.
> Example: [WarehouseService](./Services/WarehouseService.cs#L8-L15) only interacts with Warehouse's public methods. The WarehouseService does not depend on a specific implementation of storage, making it adaptable for future modifications.

## 6.SOLID Principles

### 6.1. S - Single Responsibility Principle (SRP)
Each class has a single, clear purpose.
> Example: [Reporting](./Services/Reporting.cs#L6-L16) is responsible only for generating reports.The Reporting class does not handle inventory changes, focusing only on reporting.

### 6.2 O - Open/Closed Principle (OCP)
The system allows extensions without modifying existing code.
> Example: [Money](./Models/Money.cs#L18-L21) can be extended with additional methods without altering existing logic. If new currency handling is needed, new methods can be added without changing how existing objects work.

### 6.3 L - Liskov Substitution Principle (LSP)
Objects of a subclass should be replaceable with objects of a parent class without affecting correctness.
> Example: If we extend Product, it can still work with existing services. Since WarehouseService operates on Product, a SpecialProduct would work seamlessly.
```
public class SpecialProduct : Product
{
    public string SpecialFeature { get; }

    public SpecialProduct(string name, string category, Money price, string specialFeature)
        : base(name, category, price)
    {
        SpecialFeature = specialFeature;
    }
}
```
### 6.4 I - Interface Segregation Principle (ISP)
Each class provides only the functionality it needs, avoiding unnecessary dependencies.
> Example: WarehouseService and ProductService have separate responsibilities.
>  - [WarehouseService](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%201/Services/WarehouseService.cs) handles inventory.
>  - [ProductService](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%201/Services/ProductService.cs) handles product price changes.
> Each service has its specific role without unnecessary overlap.

### 6.5 D - Dependency Inversion Principle (DIP)
High-level modules do not depend on low-level modules; both depend on abstractions.
> Example: Services interact with Warehouse and Product through well-defined methods. This setup ensures that [Program.cs](https://github.com/KotiukSofiia/KPZ/blob/main/Lab%201/Program.cs) does not depend on low-level details of product storage or pricing logic.
```
var warehouseService = new WarehouseService();
var productService = new ProductService();
```

## 7. Fail Fast
Errors should be caught early instead of propagating unexpected behaviors.
> Example: Preventing negative prices in ReducePrice in [ProductService.cs](./Services/ProductService.cs#L10). This prevents invalid prices and forces a correction immediately.
```
if (newWholePart < 0) newWholePart = 0;
```


