using Utility;
public class BessereKreisKlasse : IShape
//erbt Methoden von System.Object automatisch
{

    // Property mit IMPLIZITEM Getter

    public string Name => "Kreis";

    //Instanzattribbut ("Objektattribut") für den radius:
    private double _Radius;// private: nur innerhalb der Klasse sichtbar. public: überall sichtbar, innerhalb der kompletten Assembly
                           // -> also ganzes Programm und alles, was hinzugefügt wird.
                           // mit'private' kann die Main-Klasse nun nicht mehr eifach auf Radius zugreifen 
                           // -braucht eine legale Methode, um darauf zuzugreifen :
                           // Art und Weise des Zugriffs wird über einen Kanal gelenkt, der leicht kontrolliert werden kann
                           // und u.a. eingaben prüfen kann d.h.: wir bauen objektmethoden, die Werte GETTEN und SETTEN

    // Default-Konstruktor
    // wird automatisch generiert, solange ich nicht einen eigenen Konstruktor für die Klasse baue
    //Konstruktor muss so heissen wie die Klasse selbst:
    public BessereKreisKlasse() 
    {

    }

    public BessereKreisKlasse(double value)
    {
        this._Radius = value;
    }

    // statische Methode ("Klassenmethode"), kann nicht auf Objekte (objekt.methode) aufgerufen werden:
    public static void PrintMetadata() 
    {
        Console.WriteLine("Dies ist ein besserer Kreis.");
    }

    //Instanzmethode ("Objektmethode"), Objekte der Klasse können die nutzen
    public void Describe()
    {
        Console.WriteLine("{0} meldet:", this); 
        Console.WriteLine("Mein Radius ist {0}", this._Radius);


        Console.WriteLine("Durchmesser: {0:0.00}, Umfang: {1:0.00}, Fläche: {2:0.00}", this.GetDiameter(), this.GetPerimeter(), this.GetArea()); // .toString(0.00) rundet korrekt
    }

    public double GetArea()
    {
        //A = pi * r * r
        return this._Radius * this._Radius * Math.PI;
    }

    public double GetPerimeter()
    {
        // U = 2* PI * r
        return this._Radius * 2 * Math.PI;
    }

    public double GetDiameter()
    {
        //d = 2* r
        return this._Radius * 2;
    }

    //GETTER und SETTER Methoden:

    public double GetRadius()
    {
        return this._Radius;
    }

    public void SetRadius (double value)
    {
        if (value > 0)
        {
            this._Radius = value;
        }
        else
        {
            throw new ArgumentException("Radius muss größer 0 sein!");
        }
    }
}