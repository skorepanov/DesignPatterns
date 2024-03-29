﻿# Design patterns - Паттерны проектирования

### Creational - Порождающие 
1. [Factory method - Фабричный метод](./FactoryMethod/FactoryMethod.md)
2. [Abstract factory - Абстрактная фабрика](./AbstractFactory/AbstractFactory.md)
3. [Builder - Строитель](./Builder/Builder.md)
4. [Prototype - Прототип](./Prototype/Prototype.md)
5. [Singleton - Одиночка](./Singleton/Singleton.md)

### Structural - Структурные
1. [Adapter - Адаптер](./Adapter/Adapter.md)
2. [Decorator - Декоратор](./Decorator/Decorator.md)
3. [Facade - Фасад](./Facade/Facade.md)
4. [Bridge - Мост](./Bridge/Bridge.md)
5. [Composite - Компоновщик](./Composite/Composite.md)
6. [Flyweight - Легковес (Приспособленец)](./Flyweight/Flyweight.md)
7. [Proxy - Заместитель](./Proxy/Proxy.md)

### Behavioral - Поведенческие
1. [Strategy - Стратегия](./Strategy/Strategy.md)
2. [State - Состояние](./State/State.md)
3. [Template method - Шаблонный метод](./TemplateMethod/TemplateMethod.md)
4. [Observer - Наблюдатель (Слушатель, Издатель-подписчик)](./Observer/Observer.md)
5. [Mediator (Controller) - Посредник](./Mediator/Mediator.md)
6. [Visitor - Посетитель](./Visitor/Visitor.md)
7. [Chain of Responsibility (Chain of Command) - Цепочка обязанностей](./ChainOfResponsibility/ChainOfResponsibility.md)
8. [Command (Action, Transaction) - Команда (Действие, Транзакция)](./Command/Command.md)
9. [Memento - Снимок (Хранитель)](./Memento/Memento.md)
10. [Iterator (Cursor) - Итератор (Курсор)](./Iterator/Iterator.md)
11. [Interpreter - Интерпретатор](./Interpreter/Interpreter.md)

### Паттерны (шаблоны) проектирования
* Часто встречающееся решение определённой проблемы при проектировании архитектуры программ.
* Представляют собой общую концепцию решения той или иной проблемы, которую нужно будет подстроить под нужды разрабатываемой программы.
* Паттерны не являются алгоритмами.

### Преимущества от использования паттернов
* Проверенные решения - быстрее использовать готовое решение, чем изобрести велосипед.
* Стандартизация кода - проще проектирование
* Использование общего словаря - проще коммуникации, проще документирование.
* Повышение гибкости программы.
* Повышение повторного использования кода.

### Недостатки от использования паттернов
* Не приспособить паттерн к реалиям проекта.
* Неоправданное применение паттерна.
  * "Если у тебя в руках молоток, то все предметы вокруг начинают напоминать гвозди".

### Вывод
* Отталкиваться от решаемой задачи, а не от паттернов.
* Выбирать подходящее решение исходя из проблемы.

### Аспекты дизайна, которые могут измениться при изменении паттернов проектирования
| Назначение             | Паттерн проектирования | Переменные аспекты                                                                                                           |
|------------------------|------------------------|------------------------------------------------------------------------------------------------------------------------------|
| Порождающие паттерны   | Фабричный метод        | Подкласс создаваемого объекта                                                                                                |
|                        | Абстрактная фабрика    | Семейства порождаемых объектов                                                                                               |
|                        | Строитель              | Способ создания составного объекта                                                                                           |
|                        | Прототип               | Класс, на основе которого создается объект                                                                                   |
|                        | Одиночка               | Единственный экземпляр класса                                                                                                |
| Структурные паттерны   | Адаптер                | Интерфейс к объекту                                                                                                          |
|                        | Декоратор              | Обязанности объекта без порождения подкласса                                                                                 |
|                        | Фасад                  | Интерфейс к подсистеме                                                                                                       |
|                        | Мост                   | Реализация объекта                                                                                                           |
|                        | Компоновщик            | Структура и состав объекта                                                                                                   |
|                        | Легковес               | Затраты на хранение объектов                                                                                                 |
|                        | Заместитель            | Способ доступа к объекту, его местоположение                                                                                 |
| Поведенческие паттерны | Стратегия              | Алгоритм                                                                                                                     |
|                        | Состояние              | Состояние объекта                                                                                                            |
|                        | Шаблонный метод        | Шаги алгоритма                                                                                                               |
|                        | Наблюдатель            | Множество объектов, зависящих от другого объекта; способ, которым зависимые объекты поддерживают себя в актуальном состоянии |
|                        | Посредник              | Взаимодействующие объекты и механизм их совместной работы                                                                    |
|                        | Посетитель             | Операции, которые могут применяться к объекту или объектам, не меняя класса                                                  |
|                        | Цепочка обязанностей   | Объект, выполняющий запрос                                                                                                   |
|                        | Команда                | Время и способ выполнения запроса                                                                                            |
|                        | Снимок                 | Закрытая информация, хранящаяся вне объекта, и время ее сохранения                                                           |
|                        | Итератор               | Способ перебора элементов агрегата                                                                                           |
|                        | Интерпретатор          | Грамматика и интерпретация языка                                                                                             |
