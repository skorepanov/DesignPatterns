#region Пример 1 - Классическая реализация
using Observer.ClassicalImplementation;

var observer1 = new Observer1();
var subject = new Subject();
subject.RegisterObserver(observer1);
subject.MakeBusinessLogic();
Console.WriteLine();

var observer2 = new Observer2();
subject.RegisterObserver(observer2);
subject.MakeBusinessLogic();
Console.WriteLine();

subject.RemoveObserver(observer1);
subject.MakeBusinessLogic();
#endregion

#region Пример 2 - Реализация с событиями (events)
// using Observer.Events;
//
// var subject = new Subject();
// var observer1 = new Observer1(subject);
// subject.MakeBusinessLogic();
// Console.WriteLine();
//
// using (var observer2 = new Observer2(subject))
// {
//     subject.MakeBusinessLogic();
//     Console.WriteLine();
// }
//
// subject.MakeBusinessLogic();
#endregion
