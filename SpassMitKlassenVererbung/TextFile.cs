// A : B bedeutet: A ist Unterklasse von B
// Kostruktoren sind das einzige, das nicht vererbt wird

public class TextFile : BaseFile
{

    public int LineCount { get; private set; }

    // Bevor der Constructor von Textfile ausgeführt werden kann,
    // muss ein Konstruktor der Oberklasse ausgeführt werden
    // Allgemein: die Konstruktoren der Vorfahren
    // werden VOR dem eigenen Konstruktor aufgerufen
    public TextFile(string path) : base(path)
    {
        LineCount = 0;
    }

    // Aber: Methhoden der oberen Klassen werden automatisch vererbt,
    // können auch auf Objekte aufgerufen werden, die in Unterklassen gebiuldet wurden
    // vererbte Meth. kann ich überschreiben, Wenn vererb. klasse dies erlaubt

    public override string Describe()
    {
        string description = base.Describe();
        return $"{description}\nLineCount: {this.LineCount}";
    }
}