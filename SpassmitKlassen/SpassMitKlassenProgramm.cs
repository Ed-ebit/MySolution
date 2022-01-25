using Utility;
public class SpassMitKlassenProgramm
{
    public static void MainGeometrie()
    {
        KreisKlasse? circle = null;
        // ? sorgt hier dafür, das definiertes Objekt null sein darf
        circle = new KreisKlasse();
        KreisKlasse otherCircle = new KreisKlasse();
        KreisKlasse thirdCircle = otherCircle;
        // otherCircle und thirdCircle zeigen nun auf das selbe Objekt im Heap, NICHT AUFEINANDER
        // d.h. beide Kreise können weiterhin unabhängig behandelt, verändert etc. werden

        Console.WriteLine(circle.Equals(thirdCircle)); // Methode von System.Object
        Console.WriteLine(Object.Equals(circle, thirdCircle)); // Statische Methode von System.Object (kann nicht 'auf' Objekt ausgeführt werden)
        //Auch wenn Die Klasse "Kreisklasse" noch keinerlei Methoden für ihre Objekte besitzt,
        // so haben doch ALLE Objekte in C# (und auch alle anderen Datentypen, im ggstz zu z.B. Java) schon die vorgefertigten Methoden
        // der Klasse System.Objects, und klnnen mit diesen veerwendet werden (z.B. Equals, WriteLine etc.)

        // Achtung: Unterklassen können Methoden ihrer Oberklassen überschreiben (Klassenhierarchie),
        // also wir können eine andere Funktion für 'Equals' in unserer Kreisklasse festlegen.

        Console.WriteLine(Object.ReferenceEquals(otherCircle, thirdCircle));

        KreisKlasse.PrintMetadata();
        // thirdCircle.PrintDetails(); Fehler: PrintDetails ist statische Methode.

        circle.Radius = 10;
        otherCircle.Radius = 5.25;
        thirdCircle.Radius = 7; // überschreibt den Wert auf dem Heap Objekt, den otherCircle ihm zugewiesen hat,
                                // da beide Namen auf dasselbe Objekt zeigen

        circle.Describe();
        Console.WriteLine(circle.ToString());

        KreisKlasse neuerKreis = new KreisKlasse();
        neuerKreis.Describe();
        neuerKreis.Radius = -50; // Problem: negativer Radius macht keinen Sinn
        neuerKreis.Describe();

        // Achtung: hier kommt Arbeit mit besserer Kreisklasse, die über Getter- und Setter läuft

        BessereKreisKlasse geilererKreis = new BessereKreisKlasse();
        geilererKreis.SetRadius(10);
        geilererKreis.Describe();


        // Neu: Rechteck
        Console.WriteLine();

        RechteckKlasse einRechteck = new RechteckKlasse(10,15);

        einRechteck.Describe();

        //Jetzt: Dreieck
        Console.WriteLine();

        DreieckKlasse einDreieck = new DreieckKlasse(5);
        einDreieck.Describe();
        DreieckKlasse t = DreieckKlasse.CreateRightAngled(2, 5);
        t.Describe();







    }

    public static void Main()
    {
        Person p = new Person("Hans Meyer", new DateTime(2002,04,19), "hazelmop", new Adress("Superstraße", "1b", "Erfurt", "Dänemark")) { Gender=Gender.Male};
        Console.WriteLine(p.Name);
        Console.WriteLine(p.Birthdate);
        p.Describe();
        p.Gender = Gender.Female;// 2 Arten, um Gender zu geben: initial (oben) und spätere Änderung
        p.Describe();
        p.Adresse.Describe();
        // Adresse für Person hat nur Getter, in Klasse Person kann keine neue Adresse einer best. Person zugewiesen werden
        //(Referenz ist konstant)
        //Ihr Adressobjekt kannn aber noch geändert werden,
        //indem über konstante Referenz auf Adressklasse zugegriffen wird und da drin geändert wird.
        p.Adresse.Ort = "Sangerhausen";
        p.Adresse.Describe();
        //Lösungen: man kommt über den Getter nur an eine Kopie der in Klasse geschriebenen Daten


        //Übung: implementiere eine Klasse Buchexemplar mit: eindeutige ID (Guid - global unique ID)
        // Titel, Autoren (stringarray),Seitenzahl, Sachgebiet, Medium (enum - hardcov, softc, ebook, audiobook)
        //ISBN (globale Eindeutigkeit, aber nicht exemplareindeutigkeit , Zusatzinfos

        Buch zeSharp = new Buch("C#",new string[] { "Felix", "Karl", "Maria" },1500,"Programmierung",BookMedium.Audiobook,"9-85264713","Superbuch");
        zeSharp.Describe();

        BetterBookLibrary library = new BetterBookLibrary();
        library.Add(zeSharp);
        library.CountBooks();
        library.FindBook("C#").Describe();

        Buch buch2 = new Buch("HoHoHo!");
        library.Add(buch2);
        Console.WriteLine(library.CountBooks());

        //Filter

        TitleFilter filtaa = new TitleFilter("C#");
        Console.WriteLine(library.FindBook(filtaa));

        filtaa.Title = "HoHoHo!";
        Console.WriteLine(library.FindBook(filtaa));

        library.RemoveBook(buch2);
        AuthorFilter filtaB = new AuthorFilter("Felix");
        library.FindBook(filtaB).Describe();


        List<IShape> shapes = new List<IShape>();
        BessereKreisKlasse aCircle = new BessereKreisKlasse(6);
        shapes.Add(aCircle);
        shapes.Add(new DreieckKlasse(5));
        shapes.Add(new RechteckKlasse(10,15));
        PrintGeometricShapes(shapes);

        // Delegates: man kann eine Methode als Datentyp deklarieren, damit kapseln und diese
        // wie ein Objekt behandeln. siehe Buchfilter
        FunnyDelegates();

        //und nochmal Suche via Delegates, über eine in Bibliothek ausgelagerte Methode, die dann das Buchexemplar zurückgeben kann
        Buch? findeBuch = library.FindBook(FilterByAudiobook);


        //Lambdafunktionen:
        //Sind kleine, on the fly erzeugte Funktionen ohne Namen, die ich nicht oft brauche und mal
        //eben so mit reinhacke (aka 'dynamisch erzeugt', existiert nach ihrem Aufruf nicht mehr)
        // Oft genutzt um schnell mal zu filtern, etc pp.
        // Syntax: Parameter => Rumpf
        // Bsp: Aus Buch? findeBuch = library.Findbook(FilterByAudiobook); wird:
        findeBuch = library.FindBook(sample => sample.SachGebiet == "Programmierung");
        // Achtung: Lambdafunktion benötigt Delegate-Datentyp,
        // dazu gibts auch vordefinierte delegate-Datentypen :D -
        // Bsp. Func<T> - ist Datentyp, der Parameterlose Methoden kapseln kann
        Func<string> lambda = () => "HelloWorld"; // (): keine Parameter, wird einfach HelloWorld in String geschrieben
        Console.WriteLine(lambda());
        // Bsp. Action<T> ist eine Delegate-Typ der Methoden Kapseln kann,
        // die nichts zurückgeben, aber einen Parameter vom Typ T haben.
        Action<string> action = s => Console.WriteLine(s);
        action("Hello");




    }
    public static void PrintGeometricShapes(ICollection<IShape> shapes)
    {
        foreach (IShape shape in shapes)
        {
            Console.WriteLine($"N={shape.Name} A={shape.GetArea():N2} P={shape.GetPerimeter():N2}");
        }
    }

    public static void FunnyDelegates()
    {
        // Das Delegate-Objekt filter zeigt auf die Methode Program.FilterByAudiobook 
        // Wenn wir filter callen, läuft die Methode ab.
        // Dann können wir noch ne Methode in dieselbe Variable hängen -
        // Die Methoden werden beim Variablencall dann hintereinander ausgeführt
        BuchFilter? filter = FilterByAudiobook;
        filter += FilterBySachgebiet;

        //aber Achtung: return value ist die der zuletzt ausgeführten Funktion,
        //nicht eine Mischung Der Ergebnisse oder sowas. Für unsere Bools eher ungeeigneter Usecase.

        Buch cSharp = new Buch("C#", new string[] { "Felix", "Karl", "Maria" }, 1500, "Programmierung", BookMedium.Audiobook, "9-85264713", "Superbuch");

        // Mithilfe eines Delegate-Objektes können wir eine andere
        // Methode bzw. mehrere Methoden nacheinander aufrufen
        bool result = filter(cSharp);

        //Sehr beliebt bei Eventhandlern in GUIs, z.B. Buttonklick:
        //löst mehrere Events aus die abgearbeitet werden müssen
    }


    public static bool FilterByAudiobook(Buch sample)
    {
        return sample.Medium == BookMedium.Audiobook;
    }

    public static bool FilterBySachgebiet (Buch s)
    {
        return s.SachGebiet == "Programmierung";
    }
}
