namespace Prototype;

public class ValueCell : ICell
//public class ValueCell : ICloneable
{
    public string Value { get; set; }
    public string TextColor { get; set; }

    public ValueCell(string value, string textColor)
    {
        this.Value = value;
        this.TextColor = textColor;
    }

    public ValueCell(ValueCell prototype)
    {
        this.Value = prototype.Value;
        this.TextColor = prototype.TextColor;
    }

    public ICell Clone()
    {
        return new ValueCell(this);
        // неглубокое копирование
        //return this.MemberwiseClone() as ICell;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ячейка значения со значением {Value}, цвет текста {TextColor}");
    }
}
