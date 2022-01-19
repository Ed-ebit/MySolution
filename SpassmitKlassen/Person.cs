public class Person
{
    private string _Name;
    //ein Property namens Name
    //privater Setter und einem public Getter

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