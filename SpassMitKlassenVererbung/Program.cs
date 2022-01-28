
public class Program
{
    public static void Main()
    {
        TextFile file = new TextFile("abc.txt");
        Console.WriteLine(file.Describe());

        RichTextFile rich = new RichTextFile("def.txt", "Arial");
        Console.WriteLine(rich.Describe());

        RasterImageFile img = new RasterImageFile("Bild.jpeg");
        List<BaseFile> files = new List<BaseFile>();
        files.Add(file);
        files.Add(rich);
        files.Add(img);
        PrintFiles(files);

        file.Remove();
        //img.Remove();
        img.SetDimensions(50, 100);
        Console.WriteLine(img.Describe());
    }

    public static void PrintFiles(IEnumerable<BaseFile> files)
    {
        foreach (BaseFile file in files)
        {
            Console.WriteLine(file.Describe());
            // Obwohl die Objekte in einer Liste vom Typ Basefile sind,
            // wird Describe() in der jeweiligen erbenden Klasse aufgerufen,
            // zu der die Objekte gehören - Polymorphie!
            // funktioniert parallel zu Interfaces
            // Aber ACHTUNG: es können nur Methoden aufgerufen werden,
            // die in Basefile definiert sind, dann werden auch deren Überschreibungen
            // in den Subklassen aufgerufen.
            // Methoden, die ausschliesslich in einer Subclass definiert sind,
            // aber nicht in der BaseFile-Class, kann ich mit einer Liste vom typ Basefile
            // NICHT "sehen" oder aufrufen
        }
    }
}