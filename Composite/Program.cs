using CompositePattern;

// создать простые компоненты
IComponent cpu = new Leaf("CPU", 10000);
IComponent ram = new Leaf("RAM", 8000);
IComponent hardDisk = new Leaf("Hard disk", 4000);
IComponent mouse = new Leaf("Mouse", 500);
IComponent keyboard = new Leaf("Keyboard", 800);

// создать составные компоненты
Composite motherboard = new Composite("Motherboard", 5000);
motherboard.AddComponent(cpu);
motherboard.AddComponent(ram);

Composite cabinet = new Composite("Cabinet", 2000);
cabinet.AddComponent(motherboard);
cabinet.AddComponent(hardDisk);

Composite peripherals = new Composite("Peripherals", 0);
peripherals.AddComponent(mouse);
peripherals.AddComponent(keyboard);

Composite computer = new Composite("Computer", 0);
computer.AddComponent(cabinet);
computer.AddComponent(peripherals);

// вывести результат
displayPrice(computer);
Console.WriteLine("------------------------");
displayPrice(motherboard);
Console.WriteLine("------------------------");
displayPrice(ram);

void displayPrice(IComponent component)
{
    component.DisplayPrice();
}