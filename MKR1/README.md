# Модульна контрольна робота №1 (Котюк Софія ІПЗ-23-1)

## Реалізовані шаблони

### Iterator 
- Реалізовано обхід у **глибину (DFS)** та **ширину (BFS)**.
- Класи: `DepthFirstIterator`, `BreadthFirstIterator`
- Інтерфейс: `ILightNodeIterator`

### Command 
- Команда для додавання елемента: `AddElementCommand`
- Менеджер команд: `CommandManager`
- Підтримка виконання та `Undo`
- Приклад: додавання `<p>` в `<div>`.

### State 
- Реалізовано 3 стани:
  - `NormalState`
  - `HighlightedState`
  - `DisabledState`
- Клас `LightElementNode` підтримує зміну стану через метод `SetRenderState()`.

### Template Method 
- Абстрактний клас: `ElementLifecycleTemplate`
- Конкретний клас: `ButtonLifecycle`
- Реалізовані хуки:
  - `OnCreated`
  - `OnClassListApplied`
  - `OnStylesApplied`
  - `OnInserted`
  - `OnTextRendered`
  - `OnRemoved`
- Виводить етапи життєвого циклу кнопки у консоль.

### Visitor 
- Інтерфейс: `ILightNodeVisitor`
- Відвідувач: `NodeCountingVisitor`
- Підрахунок кількості `LightElementNode` і `LightTextNode`
- Метод `Accept(visitor)` реалізований в обох типах вузлів.


## Вимоги які виконані
| Вимога                                   | Статус |
|-----------------------------------------|--------|
| 5 шаблонів поведінкових шаблонів        | +     |
| Pull Request для кожної фічі            | +    |
| Хуки життєвого циклу                    | +    |
| Обхід HTML-структури (глибина, ширина)  | +     |
| Застосування команд + undo              | +     |
| Реалізація Visitor                      | +     |
