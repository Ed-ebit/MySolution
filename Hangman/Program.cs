public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Herzlich Willkommen zu Hangman!\n" +
                "zum Spielen 'j' drücken, zum beenden 'n'!");
            string taste = Console.ReadLine();
            if (taste == "j")
            {
                Game spiel = new(@"data\wortliste.txt");
                spiel.Run();
            }
            else if (taste == "n")
            {
                Console.WriteLine("Ciao");
                Thread.Sleep(1500);
                return;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe!");
                Thread.Sleep(800);
            }
        }

    }
}