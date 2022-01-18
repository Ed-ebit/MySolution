using Utility;
public class KreisKlasse
    //erbt Methoden von System.Object automatisch
{

    //Instanzattribbut ("Objektattribut") für den radius:
    public double Radius;  

    // Default-Konstruktor
    // wird automatisch generiert, solange ich nicht einen eigenen Konstruktor für die Klasse baue
    public KreisKlasse() //Konstruktor muss so heissen wie die Klasse selbst.
    {

    }


    public static void PrintMetadata() // statische Methode ("Klassenmethode"), kann nicht auf Objekte (objekt.methode) aufgerufen werden
    {
        Console.WriteLine("Dies ist ein sehr runder Kreis.");
    }

    //Instanzmethode ("Objektmethode"), Objekte der Klasse können die nutzen
    public void Describe()
    {
        Console.WriteLine("{0} meldet:", this); // this gibt Klassennamen statt Objektnamen aus weil: Standardmethode toString hat einen Default:
                                                // bei Aufruf Klassennamen ausgeben, nicht etwa Objektnamen.
                                                // Dazu müsste sie (toString) überschreieben werden.
                                                // Vgl. Beispiel: Circle.ToString(); hätte als output ebenfalls nur 'Kreisklasse'
        Console.WriteLine("Mein Radius ist {0}", this.Radius); //this: Referenziert das aktuelle Objekt,
                                                               //auf dem wir die Methode aufrufen

        //Erweiterung:

        Console.WriteLine("Durchmesser: {0:0.00}, Umfang: {1:0.00}, Fläche: {2}", this.GetDiameter(), this.GetCircumference(), this.GetArea()); // .toString(0.00) rundet korrekt
    }

    public double GetArea()
    {
        //A = pi * r * r
        return this.Radius * this.Radius * Math.PI;
    }

    public double GetCircumference()
    {
        // U = 2* PI * r
        return this.Radius * 2 * Math.PI;
    }

    public double GetDiameter()
    {
        //d = 2* r
        return this.Radius * 2;
    }
}