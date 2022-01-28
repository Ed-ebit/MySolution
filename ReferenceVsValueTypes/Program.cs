public class Program
{
    public static void Main()
    {
        Console.WriteLine("Reference und Value Types");
        string s = "Hello"; // String ist ein Referenz-Datentyp
        // d.h. die Variable zeigt auf das Objekt im Heap
        // werden Variablen von Referenztypen einander zugewiesen
        // (direkt oder per Argument an Methode),
        // so werden keine Werte kopiert, sondern
        // lediglich die Speicheradressen der dahinterliegenden Objekte:
        string t = s;
        // u.g. Methode liefert True, da s & t auf dasselbe Objekt verweisen
        Console.WriteLine(Object.ReferenceEquals(t, s));

        //Wenn man von einem Wertetyp (Value Type)
        //eine Variable erzeugt, dann landen die
        //Daten selbst auf dem Stack
        // Die Variable selbst ist das Objekt,
        // nicht nur eine Referenz auf ein Objekt im Heap
        // primitive Datentypen wie int, float,
        // double, decimal sind alle  Value-Types
        int i = 2;
        // Hier wird der Wert von i nach j "kopiert"
        int j = i;

        // Auch Guid ist ein Value Type
        Guid guid = Guid.NewGuid();
        Guid guid2 = guid; // echte Kopie
        Console.WriteLine(Object.ReferenceEquals(guid, guid2)); // immer false
        // die o.g. Objekte werden gleichgesetzt, bekommen aber jeweil
        // ihr eigenes Objekt im Heap (auch wenn die vom Inhalt her identisch sind)
        // - daher false

        //Bei Übergabe per Argument werden Wertetypen komplett kopiert
        //(bei Referenztypen ist es lediglich eine ca. 8 Byte große Speicheradr.)
        //Das Gleiche gilt auch für den Rückgabewert.
        Guid result = SomeMethod(guid, guid2);

        //Wertetypen sind struct und Enumerations
        //Wertetypen können Standardmäßig nicht null sein.

        Guid? id = null;
        //Wertetypen können zu Nullable-Typen
        int? wert = null;
        if (wert != null)
        {

        }
        Size mySize = new Size(100, 300);
        Size otherSize = mySize;
        mySize.Set(10, 10); // haben beide eigene Objekte im Stack
                            // - existieren nun unabhängig voneinander

        Console.WriteLine($"{mySize.Width} {mySize.Height}");
        Console.WriteLine($"{otherSize.Width} {otherSize.Height}");

    }
    
    public static Guid SomeMethod(Guid guid1, Guid guid2)
    {
        return guid1;
    }
}