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
    {
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
        //- alle Zeilen, die nur aus unterschiedlichen Buchstaben bestehen
        // zeilen 11-20 ausgeben

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
        var query4 = lines.Where(r => { string rl = r.ToLower(); return rl.Contains('a') || rl.Contains('e'); });
        List<string> results4 = query4.ToList();
        results4.ForEach(r => Console.WriteLine(r));
        //geht auch schöner!
        IEnumerable<string> query5 = lines.Where(r => r.ToLower().Contains('a') || r.ToLower().Contains('e') || r.ToLower().Contains('i') || r.ToLower().Contains('o') || r.ToLower().Contains('u'));
        List<string> results5 = query5.ToList();
        results5.ForEach(r => Console.WriteLine(r));

        // nochmal:
        //IEnumerable<string> query6 = lines.Where(l => l.ToLower().Any(c => "aeiou".Contains(c)));
        //5

        //6
        //7
        //8
        //9

        // Abfragen unter Einsatz von Linq -- für alle Datentypen, die Enumerable Interface nutzen
        // Language integrated Query (dasselbe Zeug, etwas andeere Syntax
        // 1. Alle Zeilen, die mit y oder x beginnen
        var queryL = from l in lines
                             let lToLower = l.ToLower()
                             where lToLower.StartsWith('x') || lToLower.StartsWith('y')
                             select l;
        queryL.ToList().ForEach(s => Console.WriteLine(s));

        // 2. alle zeilen die mit x beginnen, nach zeilenlänge absteigend sortiert

        IEnumerable<string>  queryL1 = from l in lines
                    let lToLower = l.ToLower()
                    where lToLower.StartsWith('x')
                    orderby lToLower.Length descending
                    select l;
        query1.ToList().ForEach(s => Console.WriteLine(s));

        // 3. alle zeilen, die mit x beginnen jeweils rückwärts ausgegeben
        var queryL2 = from l in lines
                      where l.ToLower().StartsWith('x')
                      select string.Join("", l.Reverse());// Reverse gibt einzelne chars zurück, daher wieder zu string joinen
        queryL2.ToList().ForEach(s => Console.WriteLine(s));

        // 4. erster und letzter buchstabe aller zeilen, die mit x beginnen
        // es soll select new {} zur erzeugung eines neuen anonymen Datentyps für das Ergebnis genutzt werden
        // 5.alle zeilen nach endbuchstaben gruppieren, anzahl zeilen pro gruppe,
        // Durchschnitt anzahl zeichen pro zeile pro gruppe




        // koppeln von Wörtern 'Linq-Join': alle wörter der Liste, die mit CE beginnen koppeln mit Wörtern, die auf CE enden.

        //var queryJ = from l in lines
        //             join l2 in lines on 
        //             l.Take(2) equals l2.TakeLast(2)  hier würden nur die Referenzen verglichen, nicht die Zeichenketten :(
        //deshalb:
        var queryJ = from l in lines
                     join l2 in lines on
                     string.Join("", l.Take(2)) equals string.Join("", l2.TakeLast(2)) into lineJoin
                     select new
                     {
                         Line = lines,
                         AssociatedLines = lineJoin
                     };

        foreach (var mapping in queryJ)
        {
            Console.WriteLine(mapping.Line);
            foreach (string associatedLine in mapping.AssociatedLines)
            {
                Console.WriteLine($"-> {associatedLine}");
            }
        }



    }

    public static bool FilterByA (string s)
    {
        return s.ToLower().StartsWith("a");
    }
}