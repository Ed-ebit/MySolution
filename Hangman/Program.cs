public class Program
{
    public static void Main()
    {
        string[] liste = File.ReadAllLines(@"data\wortliste.txt");
        Console.WriteLine($"Herzlich Willkommen zu Hangman!\n" +
            "zum Spielen 'j' drücken, zum beenden 'n'!");
        string taste = Console.ReadLine();
        if (taste == "j")
        {
            Game spiel = new (@"data\wortliste.txt");    
            spiel.Run();
        }
        else if (taste == "n")
        {
            Console.WriteLine("Ciao");
            return;
        }
        else 
        {
            Console.WriteLine("Ungültige Eingabe! Ciao!");
        }

    }
}