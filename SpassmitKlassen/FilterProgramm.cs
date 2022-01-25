public class FilterProgramm
{
    public static void MainBsp()
    {
        Console.WriteLine("FilterProgramm");
        string[] lines = File.ReadAllLines(@"data\wortliste.txt");
        // LOL: Console.WriteLine(lines.Length + string.Join("\n", lines)); seehr viele Ergebnisse
        //erweiterte Methoden: ist keine Vererbung
        //Bsp. für alle Klassen, die IEnumerable implementieren:
        Console.WriteLine(lines.Count());
        foreach (string line in lines.Take(10)) // gibt 1. Zehn Lines aus
        {
            Console.WriteLine(line);
        }
        // HEHE: ist ein Syntax-Trick, da diese Funktionen statisch und Teil der statischen Klasse Enumerable sind.
        // was bei lines.Count(); in Wirklichkeit aufgerufen wird:
        //         Enumerable.Count();

        foreach (string line in lines.TakeLast(10)) // gibt letzten Zehn Lines aus
        {
            Console.WriteLine(line);
        }

        // Func<string, bool> ist ein Delegate-Typ der Methoden
        // kapselt, die als Eingabeparameter einen string erwarten
        // und als Ausgabe einen bool-Wert liefern.
        // Vgl. public static bool FilterBya und FilterbyX für explizites
        // Schreiben der Funktion und Verkürzung via Lambda
        foreach (string line in lines.Where(FilterByA))
        {
            //Console.WriteLine(line); seehr viele Ergebnisse
        }

        foreach (string l in lines.Where(s => s.ToLower().StartsWith("x"))) // entspricht Spez. Func<string, bool>
        {
            Console.WriteLine(l); 
        }

        // Any prüft, ob es mindestens 1 Element gibt,
        // das eine vorgegebene Bedingung erfüllt
        Console.WriteLine(lines.Any(s =>s.Length >=15));
        // First liefert uns das erste Element,
        // das eine vorgegebene Bedingung erfüllt
        string word = lines.First(s => s.Length >= 15);
        Console.WriteLine(word);

        //Nimm die 1. 10 Elemente und schreibe sie gross
        IEnumerable<string> query = lines.Take(10).Select(line => line.ToUpper()); // dies führt noch nix aus,
        // ist eine reine Berechnungsvorschrift. Hier wird noch nix ermittelt

        // erst durch das Auflisten der Elemente der query wird die Abfrage ausgeführt
        //(per foreach, ToList, ToArray, etc.)
        List<string> results = query.ToList();

        //Klasse List hat noch eine tolle foreach lambda-Methode:
        results.ForEach (s => Console.WriteLine(s));

        // Merke: Lambdafunktionen & Extensionmethods hängen von Delegates ab. Die brauch ich um
        // mir eine LambdaF. zu bauen. Aber viieele Klassen haben schon
        // eine Menge Delegates vorbereitet, ich werde sie also selten selbst schreiben müssen

        query.OrderByDescending(x => x).ToList().ForEach(Console.WriteLine);//special Überladung von Writeline


    }

    public static void Main()

    //Übung:
    // Alles via query:
    //Ausgehend von Wortliste, erzeuge Abfrage und gib aus:
    //-Alle Zeilen, die mit b oder B beginnen
    //-Alle Zeilen, deren Länge mind. 10 Zeichen beträgt
    //-Nimm die letzten 5 Zeilen und gebe in Kleinbuchstaben aus
    //-Alle Zeilen mit mind. einem Vokal
    //- alle Zeilen, die mit y&x beginnen jeweils rückwärts
    // - alle zeilen, die nur aus vokalen bestehen
    //- jede zeile und ihre länge
    //-alle zeilen beginnend mit b und endend mit e
    {
        Console.WriteLine("Filterprogramm Übung:");
        string[] lines = File.ReadAllLines(@"data\wortliste.txt");
        //1
        IEnumerable<string> query1 = lines.Where(s => s.ToLower().StartsWith("b"));
        List<string> results1 = query1.ToList();
        results1.ForEach(s => Console.WriteLine(s));
        //2
        IEnumerable<string> query2 = lines.Where(l => l.Length >= 10);
        List<string> results2 = query2.ToList();
        results2.ForEach(r => Console.WriteLine(r));
        //3
        IEnumerable<string> query3 = lines.TakeLast(5).Select(q => q.ToLower());
        List<string> results3 = query3.ToList();
        results3.ForEach(r => Console.WriteLine(r));
        //4
        var query4 = lines.Where(r => { string rl = r.ToLower(); return rl.Contains('a') || rl.Contains('e'); } );
        //geht auch schöner!
        //5
        //6
        //7
        //8
        }

    public static bool FilterByA (string s)
    {
        return s.ToLower().StartsWith("a");
    }
}