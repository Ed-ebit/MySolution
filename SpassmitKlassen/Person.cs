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



    // Methode Describe + Attribut Nationality - soll nur gelesen werden können
    //+Property namens Birthyear, auch nur lesend (in Birthyear ist schon Jahr enthalten)

    public int Birthyear;
    {
     
    }


    public Person(string name)
    {
        this.Name = name;
    }


}