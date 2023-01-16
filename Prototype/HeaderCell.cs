using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype;

[Serializable]
public class HeaderCell : ICell
{
    public string Value { get; set; }
    public Font Font { get; private set; }

    public HeaderCell() { }

    public HeaderCell(string value, string fontName, uint fontSize)
    {
        this.Value = value;
        this.Font = new Font
        {
            Name = fontName,
            Size = fontSize
        };
    }

    public ICell Clone()
    {
        //return new HeaderCell(this.Value, this.Font.Name, this.Font.Size);
        // глубокое копирование через сериализацию
        return CreateDeepCopy();
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ячейка заголовка со значением {Value}, шрифт: {Font}");
    }

    private HeaderCell CreateDeepCopy()
    {
        HeaderCell cell;

        // классы HeaderCell и Font должны быть Serializable
        using var memoryStream = new MemoryStream();
        var binaryFormatter = new BinaryFormatter();
#pragma warning disable SYSLIB0011
        binaryFormatter.Serialize(memoryStream, this);
        memoryStream.Position = 0;
        cell = binaryFormatter.Deserialize(memoryStream) as HeaderCell;
#pragma warning restore SYSLIB0011

        return cell;
    }
}

[Serializable]
public class Font
{
    public string Name { get; set; }
    public uint Size { get; set; }

    public override string ToString() => $"название {Name}, размер {Size}";
}