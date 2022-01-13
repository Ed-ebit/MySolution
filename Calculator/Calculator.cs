public class Calculator
{
    public static void Main(string[] arguments)
    {
        Console.WriteLine("Willkommen beim Summatorr!");
        if (arguments.Length != 2)
        {
            string message = $"Fehler: Zwei Argumente erwartet, aber {arguments.Length}  Argumente erhalten.";
            Console.WriteLine(message);
            return; //verlasse Methode (in dem Falle Programm)
        }

        // durch obige Funktion haben wir ab hier genau 2 Argumente
        Console.WriteLine("Am rechnen...");

        int firstNumber = int.Parse(arguments[0]);
        int secondNumber = Convert.ToInt32(arguments[1]);

        Console.WriteLine("Summe von {0} und {1} ist {2}", firstNumber, secondNumber, firstNumber + secondNumber);

    }
}