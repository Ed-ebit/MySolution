public class Programm
{
    public static void Main1()
    {
        try
        {
            ThrowSomeExceptions();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: {0}", e.Message);
            Console.WriteLine("Programm will exit");
            return;// Wenn hier reine Textausgabe wäre statt return,
                   // wäre die Exception abgehandelt und das Programm liefer normal weiter
        }
    }

    public static void Main2()
    {
        try
        {
            Division(1);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Division durch Null");
        }
        catch(Exception e)
        {
            Console.WriteLine("Ein anderer Fehler");
        }
        finally
        {
            Console.WriteLine("Finally in Main");
        }
    }

    public static void Main()
    {
        Console.WriteLine(" Hallo, bittte Pfad angeben");
        string pfad = Console.ReadLine();
        try
        {
            TryReadLines(pfad);
        }
        catch(FileNotFoundException e)
        {

        }
        catch(UnauthorizedAccessException e)
        {

        }
        catch(Exception e)
        {
            
        }
        finally
        {

        }

    }
    //Diese Methode löst eine Ausnahme aus
    public static void ThrowSomeExceptions()
    {
        try
        {
            // Anweisungsblock, der Exceptions auslösen könnte,
            // die wir abfangen möchten
            Console.WriteLine(" i will throw Exception now");
            Exception e = new Exception(" This is a Message");
            throw e;
        }
        catch (Exception e)// sorgt dafür, dass die thrown exception an 'Catch' übergeben wird
                           // und Programmablauf vorerst nicht direkt abbricht.
                           //In 'Catch haben wir nun die Chance, darauf zu reagieren
                           //und z.B. Abbruch zu verhindern
        {
            // Wird nur ausgeführt, wenn Exception im try Block geworfen wurde.
            Console.WriteLine("I catched your Exception {0}", e.Message);
            throw;// gibt an nächsthöhere Methode weiter (hier:Main)
                  //  Wenn Main keine Fehlerbehandlung, stürzt Programm in dem Moment ab
        }
        finally
        {
            //Dieser Anweisungsblock wird immer ausgeführt
            //(auch wenn catch throw an nächsthöhere Methode anweist)
            Console.WriteLine("Es geht weiter in Main :D");
        }
        // Hier werden wir nie landen ('unreachabal Code')
        Console.WriteLine("Exception has been thrown");
    }
    //Wirft keine Exceptions
    public static void NooExceptions()
    {
        Console.WriteLine("Ich mach nix");
    }
    // Ruft Methode auf, die Exceptions wirft
    public static void CallsExceptionThroughAnotherMethod()
    {
        Console.WriteLine("before Call");
        ThrowSomeExceptions();
        Console.WriteLine("after Call");
    }

    public static int Division(int n)
    {
        if (n == 0)
        {
            throw new DivideByZeroException();
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    public static IEnumerable<string>? TryReadLines(string pfad)
    {
        IEnumerable<string> text = File.ReadAllLines(pfad);
        return text;
    }
}