public class Person
{

    // Field / Instanzattribut
    private string _Name;


    // PROPERTIES:
    //ein Property namens Name
    //privater Setter und einem public Getter
    // erlaubt es, keine Get und Set Methode bauen und später im Programm aufrufen zu müssen
    // so kann auf Name später mit einfacher Syntax zugegriffen werden
    // (z.B. Person1.Name statt Person.GetName
    // Heisst: eine vereinfachung des Codes

    public string Name
    {
        private set
        { _Name = value; }

        get
        { return _Name; }
    }

    //Dieses Property kann nur im Constructor einmalig initialisiert werden.
    //Eine nachträgliche Änderung ist nicht möglich.

    public DateTime Birthdate
    {
        get;
    }

    public string Nationality
    {
        get;
    }

    // Methode Describe + Attribut Nationality - soll nur gelesen werden können
    //+Property namens Birthyear, auch nur lesend (in Birthyear ist schon Jahr enthalten)

    public int BirthYear
    {
        get
        {
            return this.Birthdate.Year;
        }
    }

    public Gender Gender // Beachte: nicht Teil der dem Konstruktor überg. Argumente.
                         // Siehe Implement. in Hauptprogramm
    {
        get;
        set;
    }

    public Adress Adresse
    {
        get;
    }


    // Konstruktor
    public Person(string name, DateTime birthdate, string nationality, Adress adresse)
    {
        this.Gender = Gender.Diverse;
        this.Name = name;
        this.Birthdate = birthdate;
        this.Nationality = nationality;
        this.Adresse = adresse;
    }

    //Instanzmethoden:

    public void Describe()
    {
        Console.WriteLine(" Die besagte Person heißt: {0}, geboren am {1}, Nationalität: {2}. Gender: {3}. Adresse:", this.Name, this.Birthdate, this.Nationality,this.Gender);
        this.Adresse.Describe();
    }

    // Übung: Klasse namens Adress - Straße, Hausnummer, Wohnort und Land - alle Properties als lesen und schreiben + Methode Adresse
    // Property des Datentyps Adress, nur lesen
    // +2 Konstruktoren in die Klasse

}