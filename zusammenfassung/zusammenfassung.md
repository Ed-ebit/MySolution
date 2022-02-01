# Was ist .NET

* .NET ist ein Ökosystem für die Entwicklung von Anwendungen. Dazu gehören:
    * eine Runtime (Laufzeitumgebung), die .NET Applikationen ausführt. Die Runtime macht u.a. folgendes:
        * die Ausführung bzw. das Laden von .NET Applikationen (_Assemblies_)
        * Just-In-Time Compilation (d.h. IL Code wird in echten Maschinen-Code übersetzt)
        * Ressourcenverwaltung (Speicher, Threads, Prozesse etc.)
        * Garbage Collection (autom. Buchführung über reservierten Speicher und autom. Freigabe)
    * eine Sammlung von Klassen-Bibliotheken (Base Class Library)
    * eine Sammlung von .NET Programmiersprachen (C#, F#, VB.NET), die sich alle an einen offen Standard namens CLS (Common Language Specification) halten
    * alle .NET Compiler erzeugen denselben Intermediate Language (IL) Code, d.h. Komponenten einer .NET Applikation lassen sich mit diversen Programmiersprachen entwicklen und miteinander integrieren
    * Entwicklerdokumentation
    * Build-System (es führt Buch über die Abhängigkeiten von Quelltextdateien und Komponenten und beschleunigt den Übersetzungsprozess, in dem es lediglich jene Quelltextdateien neu übersetzt, die direkt oder indirekt verändert worden). In .NET wird vorwiegend _MSBuild_ eingesetzt.
        * andere Build-Systeme: CMake, Maven, GNU Make, Gulp, Grunt, Ninja
    * Common-Type-System: eine Spezifikation für ein Typsystem
        * legt fest, welche Typen es gibt (Klassen, Interfaces, Enums, Delegates, Structs)
        * legt fest, welche Byte-Größen Datentypen wie int und bool etc. haben
        * legt fest, wie der Zugriff auf die Typen und deren Member erfolgt (z.B. Sichtbarkeitsspezifizierer wie public/private)
* es gibt mehrere sog. .NET Implementierungen. Zu einer .NET Implementierung gehören wie oben beschrieben: Compiler, Class Library, Runtime etc. Es existieren u.a. folgende .NET Implementierungen:
    * .Net Framework (nur für die Windows Plattform)
    * .Net Core bzw. .Net 5+ (plattformübergreifende .Net Implementierung für Linux, Windows, MacOS etc.)
    * Xamarin (Mobile App Development) bzw. Mono

# Wozu brauchen wir Datentypen

* ein Datentyp definiert eine _Interpretation_ für ein Bitmuster. Eine Folge von Nullen und Einsen könnte z.B. folgendermaßen interpretiert werden:
    * als ganze Zahl ggf. mit Vorzeichen
    * als numerische Kodierungen von Zeichen (u.a Buchstaben, Ziffern, Sonderzeichen, Zeilenumbrüche)
    * als Verkettungen von Zeichen (Zeichenketten)
    * Gleitkommazahlen (also Zahlen mit Nachkommastellen)
    * Wahrheitswerte wie wahr und falsch
    * aus primitiven Datentypen (die oben genannten) lassen sich neue Datentypen ableiten
        * wir können unterschiedliche aber dennoch logisch zusammenhängende primitive Daten zu komplexeren Datenstrukturen zusammensetzen (z.B. Person, Array, Listen)
* ein Datentyp legt auch immer einen _Wertebereich_ fest bzw. bestimmt er, welche Daten zulässig bzw. gültig sind. Bsp.: in eine Variable vom Datentyp Integer kann ich nur Zahlen speichern, aber keine Zeichenketten oder Gleitkommazahlen.
* Datentypen definieren die _Anzahl an Bytes_, die eine Variable dieses Datentyps im Speicher belegt.
* Datentypen legen (indirekt) fest, welche _Operationen_ mit den Werten, die sie repräsentieren, durchgeführt werden können. Bsp: Zahlen lassen sich addieren, subtrahieren, potenzieren etc. Strings hingegen können aneinander gehangen werden, sie können groß und klein geschrieben werden etc.

# Primitive / Elementare Datentypen

* `int` für ganze Zahlen (bzw. `System.Int32`)
* `float`, `double` für Hardware-Gleitkommazahlen (`System.Single` bzw. `System.Double`)
    * Achtung: Rundungsfehler können bei Berechnungen auftreten
    * bei Float-Literalen _muss_ der Suffix `F` verwendet werden
    * bei Double-Literalen _kann_ der Suffix `D` verwendet werden
* `decimal` für Software-Gleitkommazahlen, allerdings basiert die interne Darstellung hier auf dem Dezimalsystem und nicht auf dem Binärsystem (Die Zahl `0.1` kann hier zum Beispiel exakt dargestellt werden.)
    * bei Literalen _muss_ der Suffix `M` verwendet werden. Z.B. `1.25M`.
* `string` für Zeichenketten (`System.String`)
* `char` für ein Zeichen (`System.Char`)
* `bool` für Wahrheitswerte (`System.Boolean`)
* um explizite Konvertierungen vorzunehmen, können wir zum Beispiel die Methoden der Klasse `System.Convert` verwenden.
    * Bsp.: Konvertierung von `string` in `int` mittels `Convert.ToInt32("123")`
    * Bsp.: Konvertierung von `int` in `string` mit `Convert.ToString(123)`
    * viele Datentypen haben eine `Parse` Methode, um einen String zu konvertieren
    * jeder Datentyp hat eine `ToString` Methode, mit der sich ein Wert in einen String konvertieren lässt.
* einige wenige Typkonvertierungen nimmt der Compiler automatisch vor (_implizite Konvertierungen_). Jedoch nur dann, wenn kein Informationsverlust dabei entsteht. Z.b. ein Float kann problemlos in einen Double konvertiert werden.

```{.csharp .line-numbers}
float f = 1.2F;
double d = f; // implizite Konvertierung von Float nach Double
decimal m = Convert.ToDecimal(d); // Explizite Konvertierung von double nach decimal!
```

# Operatoren

* Arithmetische Operatoren: `+,-,*,/,%`
    * Achtung: Dividieren wir nur Werte vom Datentyp `int` (d.h. beide Operanden des Divisionsoperators sind Integer), dann ist auch das Ergebnis vom Datentyp `int`. Die Nachkommastellen werden also **abgeschnitten** (keine Rundung).

```{.csharp .line-numbers}
double quotient = 1 / 16; // quotient ist 0!
double quotient = 1.0 / 16; // Funktioniert!
```
* Logische Operatoren: `&&` (and), `||` (oder), `!` (not)
    * Hinweis: Die Priorität von `!` ist größer als die von `&&`.
    * Hinweis: Die Priorität von `&&` ist größer als die von `||`

```{.csharp .line-numbers}
true || !false && true
// Obiger Ausdruck wird folgendermaßen ausgewertet
// Ergebnis ist True
(true || ((!false) && true))
```

# Zeichenkettenverarbeitung

* Strings sind unveränderlich (engl. _immutable_)
* wenn man Strings transformiert z.B. durch ToUpper, ToLower etc. dann erhält man immer nur eine Kopie

```{.csharp .line-numbers}
> "abc".GetHashCode()
1099313834
> "abc".ToUpper()
"ABC"
> "aBC".ToLower()
"abc"
> (1.2).ToString()
"1,2"
> DateTime.Now
[12.01.2022 10:10:57]
> "abc;uvw".Split()
string[1] { "abc;uvw" }
> "abc;uvw".Split(';')
string[2] { "abc", "uvw" }
> "   abc  ".Trim()
"abc"
> "abc".Contains("bc")
true
> "abc".StartsWith("a")
true
> "abc".EndsWith("c")
true
> string s = "abcdefg";
> s
"abcdefg"
> s[2]
'c'
> s[-1]
System.IndexOutOfRangeException: Der Index war außerhalb des Arraybereichs.
  + string.get_Chars(int)
> s[6]
'g'
> s[0]
'a'
> "abc;uvw-xyz".Split(';', '-', '_')
string[3] { "abc", "uvw", "xyz" }
> string s = new String('x', 5);
> s
'xxxxx'
> "abc".Length
3
> string.Concat("abc", "uvw")
"abcuvw"
> "abc" + "uvw"
"abcuvw"
> string.Format("{0} ist cool", "C#")
"C# ist cool"
> string.Join("", "abcd".Reverse());
"dcba"
> string s = "abc";
> string t = "abc";
> object.ReferenceEquals(s,t)
True
> string.Join(';', "abc", "defg", "uvw")
"abc;defg;uvw"
```

# Eindimensionale Arrays (Datenfelder)

```{.csharp .line-numbers}
> string[] names = { "max", "ute", "ulli" };
> names
string[3] { "max", "ute", "ulli" }
> names.Length
3
> names[0]
"max"
> names[1]
"ute"
> names[2]
"ulli"
> int[] zahlen = new int[3] { 10, 5, 1 };
> zahlen
int[3] { 10, 5, 1 }
> int[] primzahlen = new int[5];
> primzahlen
int[5] { 0, 0, 0, 0, 0 }
> primzahlen[0] = 2;
> primzahlen[1] = 3;
> primzahlen[2] = 5;
> primzahlen[4] = 7;
> primzahlen[3] = 11;
> primzahlen
int[5] { 2, 3, 5, 11, 7 }
```

# Rechteckige, mehrdimensionale Arrays

```{.csharp .line-numbers}
> int[,,] tabelle = new int[2, 3, 4] 
{
    { 
        { 1,2,3,4 }, 
        { 5,6,7,8 }, 
        { 1,2,3,4 } 
    },
    { 
        { 9,8,7,6 }, 
        { 5,4,3,2 }, 
        { 1,0,0,1 } 
    },
};
> tabelle.Length
24
> tabelle.GetLength(0)
2
> tabelle.GetLength(1)
3
> tabelle.GetLength(2)
4
```

# Arrays von Arrays (Jagged Arrays / Verzweigte Arrays)

```{.csharp .line-numbers}
// tabelle ist ein eindimensionaler Array, dessen
// Elemente den Datentyp int[] haben. Die Elemente sind
// also selbst Arrays.
// Der Array tabelle speichert lediglich Objektreferenzen
// auf zwei Array-Objekte. Diese beiden Array-Objekte müssen
// separat erzeugt werden.
> int[][] tabelle = new int[2][];
> tabelle[0] = new int[] {1,2,3}; 
> tabelle[1] = new int[] {9,8,7,6,5,4};
> tabelle[0].Length
3
> tabelle[1].Length
6
> tabelle[1][2]
7
> tabelle.GetLength(0)
2
> tabelle.GetLength(1) // Fehler: tabelle ist eindimensional!
System.IndexOutOfRangeException: Der Index war außerhalb des Arraybereichs.
  + System.Array.GetLength(int)
```

# Kontrollstrukturen

* foreach-Schleife: Hiermit lassen sich die Elemente einer _Datentreihe_ elementweise durchlaufen. Zum Beispiel Arrays, Strings, Listen etc.
    * Hinweis: Die Elemente können mit diesem Schleifentyp nicht ersetzt werden.
    * Hinweis: Elemente lassen sich in den meisten Fällen nicht in einer foreach-Schleife entfernen

```{.csharp .line-numbers}
foreach (ElementDatentyp e in Datenreihe)
{
    // e ist Bezeichner für das aktuell betrachtete Element
    // e ist eine _Kopie_ des aktuellen Elements!!!
}

// Gibt 'z e i c h e n k e t t e' aus
// Hinweis: Die Elemente eines Strings sind Chars
foreach (char zeichen in "zeichenkette")
{
    Console.Write($"{zeichen} ");
}

// Gibt aus '1 2 3'
int[] zahlen = { 1, 2, 3 };
foreach (int zahl in zahlen)
{
    Console.Write($"{zahl} ");
}
```

* if-Anweisung: Hiermit lassen sich Anweisungen _bedingt_ ausführen

```{.csharp .line-numbers}
if (bedingung1)
{
    // Anweisungsblock 1
}
else if (bedingung2)
{
    // Anweisungsblock 2
    // !bedingung1 && bedingung2
}
else
{
    // !bedingung1 && !bedingung2
}
```

* switch-Anweisung: der Wert eines Berechnungsausdruckes wird nacheinander mit den _konstanten Werten_ in den case-Labels verglichen. Sobald ein Vergleich wahr ist, wird der zum case zugehörige Anweisungsblock ausgeführt. Die `break` Anweisung verlässt die switch-Kontrollstruktur und springt zur nächsten Anweisung.

```{.csharp .line-numbers}
// Gibt aus: 'Fehler ist 1 oder 3'
int errorCode = 3;
int fileNotFound = 404;
switch (errorCode)
{
    case 1: 
        // Hier ist der Anweisungsblock leer, deshalb wird der
        // Anweisungsblock für case 3 ausgeführt.
    case 2:
        Console.WriteLine("Fehler ist 1 oder 3");
        break; // hier wird die Kontrollstruktur verlassen
    case fileNotFound:
        // Funktioniert nicht, da fileNotFound kein konstanter Wert ist
        // (zur Kompilierzeit nicht berechnenbar bzw. bekannt)
        break;
    default:
        Console.WriteLine("Unbekannter Fehler");
        break;
}
// hier landen wir nach der break-Anweisung
```

* for-Schleife: eine kopfgesteuerte Schleife (Bedingung wird vor erster Iteration geprüft)
    * Hinweis: Solange die Laufbedingung erfüllt ist (`true`), wird die Schleife durchlaufen. Ist sie erstmalig nicht erfüllt (`false`) wird die Schleife beendet.


```{.csharp .line-numbers}
// Alle drei Blöcke im Kopf der Schleife sind optional
// Die Semikola sind verpflichtend.
// Iterationsanweisung wird nach jedem Schleifendurchlauf ausgeführt
// noch bevor die Laufbedingung erneut geprüft wird.
// Wird die Bedingung weggelassen, wird implizit True angenommen.
for (<initialisierung> ; <Laufbedingung> ; <Iterationsanweisung>)
{
    // Schleifenrumpf

    // mit der break Anweisung verlassen wir die Schleife sofort.
    // Die Iterationsanweisung wird in diesem Fall nicht mehr ausgeführt.

    // mit der continue Anweisung beenden wir den aktuellen Schleifendurchlauf.
    // Hier wird direkt zur Iterationsanweisung gesprungen.
    // Anschließend erfolgt eine neue Prüfung der Laufbedingung.
    
}

```

# DateTime (Datum und Zeit)

```{.csharp .line-numbers}
> DateTime.Today
[20.01.2022 00:00:00]
> DateTime.Now
[20.01.2022 08:27:59]
> DateTime.UtcNow
[20.01.2022 07:28:48]
> DateTime.UtcNow.ToShortDateString()
"20.01.2022"
> DateTime.UtcNow.ToString("d")
"20.01.2022"
> DateTime.UtcNow.ToString("D")
"Donnerstag, 20. Januar 2022"
> Console.Write("{0:D}", DateTime.Today);
Donnerstag, 20. Januar 2022
> Console.Write("{0:d}", DateTime.Today);
20.01.2022
> Console.Write("{0:MM.yyyy}", DateTime.Today);
01.2022
> new DateTime(2000, 5, 20)
[20.05.2000 00:00:00]
> DateTime.IsLeapYear(2000)
true
```


# Klassen

* repräsentieren logische Einheiten aus Attributen (Daten) und darauf arbeitenden Operationen (Verhalten)
* bieten zahlreiche Mechanismen, um Daten und Operationen zu schützen
    * Sichtbarkeitsmodifikation (z.B. `public` und `private`)
    * read-only Zugriff per `readonly` oder Properties ohne Setter
* definieren den "Bauplan" für Objekte, die anhand dieser Klassen erzeugt werden.
* können zahlreiche Member aufweisen. Z.B.:
    * Fields (klassische Datenattribute)
    * Properties (eine Art Mix aus Field und dazugehörigen Set und Get Funktionen)
    * Methoden (stellen das Verhalten der Klasse dar)
    * Events (informieren Abonennten über Zustandsveränderungen)
    * Konstanten
    * Indexer (erlaubt Zugriff per `[index]`)
    * Konstruktoren (initialisiert neues Objekt)
    * Destruktor (gibt Ressourcen eines Objekts frei)
    * statischer Konstruktor (wird einmalig beim Laden der Klasse ausgeführt)
* statische Member gelten für die Klasse selbst
* Instanz-Member gelten pro Objekt
* können beliebig viele Interfaces implementieren / beerben
* können von maximal einer Klasse erben (Einfachvererbung)

## Syntax

```{.csharp .line-numbers}
<Sichtbarkeit> class <Klassenname>
{
    // Definition der Klasse
}

// Erzeugen eines neuen Objektes mit Hilfe eines Konstruktors
Klassenname variablenname = new Klassenname(argumente);
// Aufruf einer Instanzmethode
Objektreferenz.Instanzmethode(argumente)
// Aufruf einer Klassenmethode
Klassenname.Klassenmethode(argumente)
```

## Properties

* statt separate Getter und Setter Methoden für zu schützende Attribute zu schreiben, werden in C# üblicherweise Properties implementiert. Lese und Schreibzugriffe erfolgen dann nicht mehr durch separate GetProperty und SetProperty Methoden, sondern einfach per `objekt.property` Notation. 
* Diese Zugriffsart ist konform zur Verwendung von herkömmlichen Attributen (Feldern), bietet aber dennoch zusätzliche Lese und Schreiblogik bzw. Zugriffssteuerung.
* für jedes Property kann definiert werden, ob es lesbar (`get`) und schreibbar (`set`) ist. `get` und `set` lassen sich außerdem in ihrer Sichtbarkeit einschränken. Es ist also u.a. möglich den Getter öffentlich verfügbar zu machen, den Setter aber privat zu deklarieren.
* Properties, die nur einen Getter (get) besitzen, können nur einmalig im Constructor der Klasse initialisiert und danach nicht mehr modifiziert werden.
* Nur schreibbare (set, aber kein get) Properties gibt es nicht.

```{.csharp .line-numbers}
// Konventioneller Zugriff mit separaten Set und Get Methoden
o.SetX(value);
value = o.GetX();
// Zugriff mit Properties
o.X = value;
value = o.X;
// Syntax für Property-Definition
<Sichtbarkeit> <Datentyp> <Property-Name>
{
    get
    {
        // Logik für Lesezugriff
    }
    set
    {
        // Logik für Schreibzugriff
    }
}
```

## Vererbung

* Terminologie:
    * Compile-Time-Type: Das ist der Datentyp einer Variable, so wie er zur Kompilierzeit angegeben wurde (z.B. `BaseFile` in der Definition `BaseFile? file = null`)
    * Runtime-Type: Das ist der Datentyp, auf den eine Objektvariable während des Programmablaufs tatsächlich verweist (z.B. `file` zeigt auf ein Objekt vom Typ `RichTextFile`)

```{.csharp .line-numbers}
// Compile-Time-Type ist "BaseFile"
// Runtime-Type ist aber "RichTextFile"
BaseFile file = new RichTextFile("pfad");

// Compile-Time-Type ist "ICollection<string>"
// Runtime-Type von "collection" ist aber "List<string>"
ICollection<string> collection = new List<string>();
```

* ein Aufruf der Form `anObject.Member` wird folgendermaßen aufgelöst:
    * es wird der Compile-Time-Type `CTT` von `anObject` ermittelt
    * wenn `Member` in `CTT` _nicht_ als `virtual` deklariert wurde, dann wird immer `CTT.Member` aufgerufen. Der Runtime-Type von `anObject` ist damit also unerheblich.
    * wenn `Member` in `CTT` hingegen als `virtual` deklariert wurde,dann wird der Runtime-Type `RTT` von `anObject` ermittelt. Nun wird nacheinander in folgenden Klassen nach der "neusten Version" von `Member` gesucht:
        * in der Klasse `RTT`
        * in der Oberklasse von `RTT`
        * in der Oberklasse der Oberklasse von `RTT` usw.
    * die "neuste Version", die gefunden wird, wird dann aufgerufen.
    * Bildlich gesprochen, wandert man ausgehend von `RTT` immer weiter nach oben in Richtung der Wurzelklasse bis man entweder eine überschriebene Version von `Member` findet oder bis man die erstmalige Definition von `Member` vorfindet.
* Hinweis: der Compile-Time-Type von `this` ist jene Klasse, in der das Schlüsselwort verwendet wird. Verwendet man also `this` in der Klasse `BaseFile`, so ist `BaseFile` der `CTT`. Aber auch hier kann der Runtime-Type von `this` eine Unterklasse von `BaseFile` sein!!
* Tipp: Vermeide es, `virtual` Methoden im Konstruktor aufzurufen. Problem: Ein Basisklassen-Konstruktor kann dadurch eine Methode einer seiner Unterklassen aufrufen, ohne dass das Objekt der Unterklasse schon vollständig initialisiert wurde.
* Vererbung sollte nur dann verwendet werden, wenn die Unterklasse eine sinnvolle Spezialisierung der Oberklasse ist. Die Beziehung "ist-ein" sollte erfüllt sein. Beispiel: ein ImageFile "ist-eine" Base-File. Gegenbeispiel: ein Motorrad ist kein Fahrrad, obwohl beide viel gemeinsam haben. Ein Motorrad ist allerdings ein Zweirad.
* vererbt werden alle Member der Oberklasse bis auf die Konstruktoren.
* eine Unterklasse hat die Möglichkeit Member der Oberklasse zu überschreiben. Dazu muss das Member aber als `virtual` deklariert sein. Trotz des Überschreibens eines Members, bleibt die ursprüngliche Definition in der Oberklasse erhalten! Die überschriebene Version ist nur für die überschreibende Klasse und deren Nachfahren wirksam.
* der Konstruktor einer Unterklasse muss immer _zuerst_ einen Konstruktor der Oberklasse aufrufen. Gibt es in der Oberklasse einen parameterlosen Konstruktor, wird dieser automatisch aufgerufen, sofern kein expliziter Basiskonstruktor in der Unterklasse ausgewählt wird.
    * bildlich gesprochen, werden die Konstruktoren in der Hierarchie von "oben nach unten" aufgerufen bzw. die Objekte von "oben nach unten" initialisiert.

```{.csharp .line-numbers}
public MyConstructor(someArguments) 
    : base(someOtherArguments) // Aufruf des Basiskonstruktors
{
    // Initialisierung
    // erfolgt erst nach der Initialisierung der Oberklasse
}
```


## Sichtbarkeits / Zugriffsmodifizierer

* `public`: für alle Klassen sichtbar
* `internal`: für alle Klassen innerhalb derselben Assembly sichtbar
* `private`: ausschließlich für die eigene Klasse sichtbar
* `protected`: Ausschließlich sichtbar für Nachfahren-Klassen
    * Hinweis: ein Aufruf der Form `obj.ProtectedMember` in einer Klasse `C` ist genau dann zulässig, wenn `C` dem _Compile-Time-Typ_ von `obj` entspricht oder eine Unterklasse dieses Typs ist. Diese Restriktion verhindert, dass `C` auf die Protected-Member seiner "Geschwister-Klassen" zugreifen und damit deren sichergestellte Invarianten umgehen kann. Eine Unterklasse sollte sich nur nach der internen Implementierung _einer_ Oberklasse richten und sich nicht Gedanken darüber machen müssen, ob Geschwister-Klassen die aufgestellten Invarianten umgehen könnten.

# Interfaces (Schnittstellen)

* stellen eine Art Spezifikation oder Protokoll für andere Datentypen (insbesondere Klassen) dar.
* enthalten nur Member-Deklarationen (Signatur), aber keine Definitionen (Logik/Implementierung). Die Schnittstelle definiert also nur das _Was_, aber nicht das _Wie_.
* erlauben es, Code zu schreiben, der unabhängig von einer konkreten Implementierung / Datentyp ist, sondern lediglich auf eine allgemeine, flexible Schnittstelle zugreift. Der Code kann also mit vielen verschiedenen Implementierungen einer Schnittstelle arbeiten und die Wahrscheinlichkeit, dass dieser Code angepasst werden muss, sinkt damit enorm.
* ermöglichen Plugins
* beschreiben typischerweise Features eines Datentyps
* in .NET finden sich zahlreiche Interfaces, u.a.:
    * `IEnumerable` (aufzählbare Dinge) und `ICollection` (Elementsammlungen)
    * `IList` (Zugriff per Index), `ISet` (Mengen), `IDictionary` (Schlüssel-Wert-Paare)
    * `IEquatable` (==) und `IComparable` (<,>,>=,<=)
    * `IDisposable` (erfordert Ressourcenfreigabe)
    * `ICloneable` (kopierbar)

```{.csharp .line-numbers}

// IPrinter definiert eine Schnittstelle für Drucker
public interface IPrinter
{
    // Properties (keine Logik)
    bool IsReady { get; }

    // Methoden (keine Logik)
    PrintResult Print(Page p);
    void Reset();
    bool Clean();
}

public class InkPrinter : IPrinter
{
    // Muss Implementierung für IPrinter anbieten
}

public class LaserPrinter : IPrinter
{
    // Muss Implementierung für IPrinter anbieten
}

public class NeedlePrinter : IPrinter
{
    // Muss Implementierung für IPrinter anbieten
}

// Code, der nur von der Schnittstelle IPrinter abhängig ist
// und mit allen Klassen arbeiten kann, die die Schnittstelle
// IPrinter implementieren.
public void PrintMail(IPrinter printer, string message)
{
    Page aPage = new Page(message);
    
    if (printer.IsReady)
    {
        printer.Print(aPage);
    }
}

// Aufrufden der PrintMail Methode mit unterschiedlichen Objekten
PrintMail(new LaserPrinter(), "some message");
PrintMail(new InkPrinter(), "some other message");
PrintMail(new NeedlePrinter(), "yet another message");

```

# Enumerations (Aufzählungstypen)

* definieren einen begrenzten Wertebereich und geben sowohl den einzelnen Werten als auch dem Wertebereich selbst einen deskriptiven Namen
* verbessern die Lesbarkeit des Codes, wenn viele Konstanten benötigt werden, die ansonsten nur als bloße Zahlen im Quellcode auftauchen würden.
* die Konstanten einer Enumeration werden intern als ganze Zahlen repräsentiert

```{.csharp .line-numbers}
// Der Name des Wertebereichs ist Gender. Der Wertebereich
// besteht aus den drei Konstanten namens Male, Female und Diverse.
public enum Gender
{
    Male, Female, Diverse,
}

public enum Color
{
    Red, Green, Blue, White, Black
}

public enum BookType
{
    Hardcover, Softcover, AudioBook, EBook
}

// Den Konstanten können explizite Ganzzahlen zugewiesen werden
public enum ErrorCode
{
    Unknown = 0,
    FileNotFound = 200,
    NotEnoughMemory = 12345
}

// Ein paar Variablen von den oben genannten Datentypen anlegen.
Gender g = Gender.Female;
Color c = Color.Green;
BookType b = BookType.Softcover;
ErrorCode code = ErrorCode.FileNotFound;

// StringComparison ist eine Enumeration
// Die Klasse Enum bietet einige Operationen an, um
// mit Enumerations zu arbeiten
> StringComparison.Ordinal
Ordinal
> (int)StringComparison.Ordinal
4
> (StringComparison)4
Ordinal
> Enum.IsDefined(typeof(StringComparison), -1)
false
> Enum.IsDefined(typeof(StringComparison), 4)
true
> Enum.GetName(typeof(StringComparison), 4)
"Ordinal"
> Enum.GetNames(typeof(StringComparison))
string[6] { "CurrentCulture", "CurrentCultureIgnoreCase", "InvariantCulture", "InvariantCultureIgnoreCase", "Ordinal", "OrdinalIgnoreCase" }
> Enum.Parse(typeof(StringComparison), "CurrentCulture")
CurrentCulture
> StringComparison.Ordinal.ToString()
"Ordinal"
> StringComparison.Ordinal.ToString("D")
"4"
```


# Delegates

* sind Datentypen, deren Objekte eine oder mehrere Methoden mit einer fest definierten Signatur kapseln können ("Methoden als Objekte")
* wird ein Delegate-Objekt aufgerufen, wird die gekapselte Methode aufgerufen
* Analogie: Delegates sind so etwas ähnliches wie ein Funktionszeiger in C oder eine Art Alias für eine Methode
* Multicast-Delegate: das Delegate-Objekt kapselt nicht nur eine, sondern mehrere Methoden. Ein Aufruf des Delegate-Objekts bewirkt das Nacheinanderausführen aller gekapselten Methoden in der Reihenfolge, in der sie zum Delegate-Objekt hinzugefügt wurden. Der Rückgabewert der zuletzt aufgerufenen Methode bildet den Rückgabewert des aufgerufenen Delegates.


```{.csharp .line-numbers}

// Eine Methode mit Signatur bool (string)
public bool HasAtLeast3Chars(string w) => w.Length >= 3;
// Eine Methode mit Signatur bool (string)
public bool StartsWithA(string w) => w.ToLowe().StartsWith("a");

// Definiere neuen Datentyp namens FilterDelegate.
// Objekte dieses Delegates können auf Methoden mit Signatur
// bool (string) verweisen.
public delegate bool FilterDelegate(string word);

// Erzeuge Variable vom Datentyp FilterDelegate
// filter verweist auf komptabible Methode HasAtLeast3Chars
FilterDelegate filter = HasAtLeast3Chars;

// Aufruf des Delegates filter bewirkt indirekt Aufruf von HasAtLeast3Chars
bool result = filter("Hello"); 

// Hänge Methode an das Delegate filter an
filter += StartsWithA; // filter = filter + StartsWithA;

// Rufe Delegate-Objekt auf. Es wird zuerst HasAtLeastChars aufgerufen
// und danach erfolgt der Aufruf von StartsWithA
result = filter("Hello");

// HasAtLeast3Chars von filter entfernen
filter -= HasAtLeast3Chars;
```

# Lambdas

* sind namenslose Funktionen, die "on-the-fly" an der Stelle erzeugt werden, wo man sie benötigt
* sind i.d.R. sehr kurz und einfach gehalten
* lassen sich überall dort verwenden, wo ein Delegate-Objekt erwartet wird

```{.csharp .line-numbers}
FilterDelegate filter = wort => wort.ToLower().StartsWith("a");
bool result = filter("Hello"); // Liefert false

// Lambda, welches keine Argumente erwartet.
// Der Datentyp Action ist ein Delegate, welches Methoden kapseln kann,
// folgende SIgnatur haben: void (void)
Action action = () => Console.WriteLine("Hello");
action(); // Aufruf des Delegate gibt Hello auf Konsole aus

// Lambdas mit einem Argument
Action<string> action = arg => Console.WriteLine(arg);
// oder
Action<string> action = (arg) => Console.WriteLine(arg);

// Lambdas mit mehreren Argumenten.
// Func<int,int,int> ist ein Delegate, das Methoden der Signatur
// int (int, int) kapseln kann.
Func<int, int, int> calc = (x, y) => x + y;
calc(1, 3); // Liefert 4

// Lambdas mit Anweisungsblock
Func<int, int, int> calc = (x, y) => { int sum = x + y; return sum; };
calc(1, 3); // Liefert 4
```

# Events

* implementieren das Observable-Observer-Pattern direkt in der Sprache C#
* ein Event kann als Member einer Klasse definiert werden
    * Abonnenten/Subscriber registrieren sich für die Events eines Objektes
    * das Objekt löst Events aus und informiert dadurch automatisch die registrierten Abonennten
* basieren auf Delegates, aber bieten für diese folgende Schutzmaßnahmen:
    * dem Delegate kann außerhalb der event-definiernden Klasse nichts zugewiesen werden
    * das Delegate kann von außerhalb nicht geleert werden
    * Außen-Code kann sich nur als Subscriber eintragen und wieder austragen
    * das Auslösen des Delegates kann nur die event-definierende Klasse selbst bewirken.

```{.csharp .line-numbers}
// Ein Delegate für die Abonennten (Subscriber)
public void NewsEventHandler(string reporter, string news);

// Eine event-auslösende Klasse NewsAgency
public class NewsAgency
{
    // NewsReceived ist zwar vom Delegate-Typ NewsEventHandler
    // wird aber durch das Schlüsselwort event zusätzlich geschützt.
    public event NewsEventHandler? NewsReceived;

    // Eine Methode zum Informieren der NewsAgency
    public void Inform(string informat, string news)
    {
        // Speichere News in die Datenbank
        // Verarbeite / Analysiere News etc.

        // Rufe alle registrierten Abonennten nacheinander auf
        NewsReceived?.Invoke(informant, news);
    }
}

// Irgendwo anders im Programm...
NewsAgency agency = new NewsAgency();
// Für das Event NewsReceived registrieren
agency.NewsReceived += OnNewsReceived;
agency.NewsReceived += (informant, news) => Console.WriteLine("Danke");
// NewsAgency informieren (löst intern das NewsReceived Event aus)
agency.Inform("Snowden", "USA is the king");
// Irgendwann später...Austragen für das Event
agency.NewsReceived -= OnNewsReceived;

// Definiert einen Abonennten (Subscriber)
public void OnNewsReceived(string informant, string news)
{
    // Mache etwas mit den Informant und News
}
```

# Language Integrated Query (LINQ)

* .Net bietet eine Sammlung von Erweiterungs-Methoden (extension-methods) für die Schnittstelle `IEnumerable<T>`. Diese Sammlung enthält u.a. Methoden für:
    * Sortierung und Gruppierung (`OrderBy`, `GroupBy`)
    * Filterung (`Where`, `Distinct`, `Take`, `Skip`, `First`, `Last`)
    * Transformation (`Select`)
    * Datenquellen verknüpfen mit `Join`
    * Überprüfungen (`Any`, `All`)
    * Mengenoperationen (`Union`, `Intersect`)
* neben der Methoden-Schreibweise gibt es eine SQL-ähnliche Schreibweise, die sogenannte LINQ
* Queries werden in den meisten Fällen nicht sofort ausgeführt. Folgende Situation führen jedoch zu einer Auswertung (und noch andere):
    * die Query wird mit `foreach` durchlaufen
    * einige Methoden wie `Count`, `All` und `Any` werden aufgerufen, die als Ergebnis kein `IEnumerable` liefern, sondern einen konkreten Wert wie `int` oder `boolean` liefern
    * man ruft `ToList` oder `ToArray` auf
    

```{.csharp .line-numbers}

string[] lines = File.ReadAllLines("pfad");

// Eine Query (Abfrage) die nur Zeilen ausgibt, deren Länge
// mindestens 10 Zeichen beträgt.
var longLinesQuery = lines.Where(line => line.Length >= 10);

// Alternative in LINQ
var longLinesQuery = 
    from line in lines
    where line.Length >= 10
    select line;

// Sortiere Zeilen nach deren Länge in absteigender Reihenfolge
var orderedLines = lines.OrderByDescending(line => line.Length);

// Alternative in LINQ
var orderedLines =
    from line in lines
    orderby line.Length descending
    select line;

// Prüfe, ob alle Zeilen mit A beginnen
bool result = lines.All(line => line.StartsWith("A"));
// keine direkte Alternative in LINQ

// Prüfe, ob mindestens eine Zeile mit B beginnt
result = lines.Any(line => line.StartsWith("B"));
// keine direkte Alternative in LINQ

// Projeziere alle Zeilen auf Zeilen mit zusätzlicher Längenangabe
var transformedLines = lines.Select(line => $"{line} {line.Length}");

// Alternative in LINQ
var transformedLines =
    from line in lines
    let lineLength = line.Length
    select $"{line} {lineLength}";


```

# Vergleich von Wertetypen (Value Types) mit Referenztypen (Reference Types)

* Hinweis: In der Entwicklung hat man es fast ausschließlich mit Referenztypen zu tun. Wertetypen sind nur dann sinnvoll, wenn man kleine, simple Datenstrukturen ohne "intelligentes" Verhalten benötigt, die bei Zuweisung bitweise kopiert werden sollen.
* eine Variable eines Value Types `V` _enthält_ eine Instanz von `V`. Eine Variable eines Referenztyps `R` hingegen enthält lediglich einen _Verweis_ (Speicheradresse) auf eine Instanz von `R`.
* bei der Zuweisung zweier Variablen vom Typ `V` wird die Instanz selbst bitweise kopiert. Bei der Zuweisung zweier Variablen vom Typ `R` wird lediglich der Verweis (Speicheradressen) auf die Instanz kopiert.
* Instanzen von `V` werden auf dem _Stack_ abgelegt. Instanzen von `R` hingegen landen im _Heap_.
* Beachte: eine Zuweisung findet auch statt, wenn ein Argument bei einem Methodenaufruf übergeben wird. Zuweisungen finden ebenfalls statt, wenn eine aufgerufene Methode einen Wert an den Aufrufer zurückgibt. Im Falle von Value Types würden hier stets Kopien der Instanzen erzeugt werden. Im Falle von Reference Types würden lediglich die Verweise bzw. Speicheradressen auf die Instanzen kopiert werden.

```{.csharp .line-numbers}
// int ist ein Value Type. a und b sind Variablen vom Typ int.
// Sowohl a als auch b enthalten die jeweiligen Zahlenwerte.
int a = 10;
int b = 12;
a = b; // Zahlenwert von b wird direkt in a kopiert.
// a und b enthalten nun beide den Wert 12. Dieser existiert
// zweimal im Speicher.

// string ist ein Reference Type. x und y sind Variablen vom Typ string.
// x und y enthalten lediglich Verweise auf String-Objekte im Heap.
string x = "Hello";
string y = "World";
x = y; // der Verweis in y wird nach x kopiert
// x verweist nun auf dasselbe String-Objekt wie y
// Das String-Objekt mit Wert "World" kann nun sowohl
// per x als auch per y angesprochen werden.
x.Equals("World") // liefert True
y.Equals("World") // liefert True
object.ReferenceEquals(x, y) // liefert True
```

* alle Datentypen, die per `struct` oder `enum` definiert werden, sind Value Types
* folgende Datentypen gehören u.a. zur Kategorie "Value Types": `int`, `float`, `double`, `Guid`, `bool`, `decimal`, `Point`, `Size`


```{.csharp .line-numbers}
// Structure Types sind Value Types
// Beachte: Structure Types haben _immer_ einen Default Constructor
// der alle Member mit 0 initialisiert. Dies lässt sich nicht
// verhindern!
public struct Size
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Size(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }
}

Size windowSize = new Size(1024, 768);
Size desktopSize; // OK: aber Width = 0, Height = 0!!

// Enums sind Value Types, da sie durch einen integralen Datentyp
// repräsentiert werden.
public enum Gender
{
    Male, Female, Diverse
}
```



# Glossar

* eine _Instanz_ ist u.a. ein Objekt einer Klasse

