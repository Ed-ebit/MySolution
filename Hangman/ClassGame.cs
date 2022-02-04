public class Game
{

    //Properties
    public string Path { get; }
    public char[]? WordAsChars { get; set; }
    public char[]? WordUnderline { get; set; }
    //Constructors
    public Game(string path)
    {
        this.Path = path;
    }
    //Instance Methods

    public string ChooseWord()
    {
        string[] words = File.ReadAllLines(this.Path);
        Random random = new Random();
        int wahlIndex = random.Next(0, words.Length);
        string chosenWord = words[wahlIndex];
        return chosenWord.ToUpper();
    }

    public void PrepareWord(string word)
    {
        char[] wordAsChars = new char[word.Length];
        char[] wordUnderline = new char[word.Length];
        for (int i = 0; i < word.Length; i++)
        {
            wordAsChars[i] = (char)word[i];
        }
        this.WordAsChars = wordAsChars;
        for (int i = 0; i < word.Length; i++)
        {
            wordUnderline[i] = '_';
        }
        this.WordUnderline = wordUnderline;

    }

    public int CheckGuess(string eingabe, int versuche)
    {
        Console.Clear();
        if (eingabe.Length > 1 || eingabe.Length < 1)
        {
            Console.WriteLine("Ungültige Eingabe, bitte genau einen Buchstaben eingeben!");
        }
        else
        {
            char taste = eingabe.ToUpper()[0];
            if (WordAsChars.Contains(taste) &! WordUnderline.Contains(taste))
            {
                versuche += 1;
                Console.WriteLine("Richtiiig!");

                for (int i = 0; i < this.WordAsChars.Length; i++)
                {
                    if (this.WordAsChars[i] == taste)
                    {
                        this.WordUnderline[i] = taste;
                    }
                }

            }
            else if(WordAsChars.Contains(taste) & WordUnderline.Contains(taste))
            {
                Console.WriteLine(" Der Buchstabe wurde schon erraten, probier mal einen neuen!");
            }
            else
            {
                versuche += 1;
                Console.WriteLine("Leider kein Treffer! Nächster Versuch!");
            }
        }
        return versuche;
    }

    public bool AbortGame()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Spiel Abbrechen? (J)a oder (N)ein");
            string bestaetigung = Console.ReadLine();
            if (bestaetigung.ToLower() == "j")
            {
                return true;
            }
            else if (bestaetigung.ToLower() == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe");
            }
        }
    }

    public void Run()
    {
        this.PrepareWord(ChooseWord());
        string eingabe = "";
        int versuche = 0;
        while (true)
        {
            Console.WriteLine();
            foreach(char ch in this.WordUnderline)
            {
                Console.Write(" {0}", ch);
            }
            Console.WriteLine($"\n");
            Console.WriteLine("Bitte einen Buchstaben raten und mit Enter bestätigen");
            Console.WriteLine("Um das Spiel zu beenden, die Zahl 1 eingeben");
            eingabe = Console.ReadLine();

            versuche = this.CheckGuess(eingabe, versuche);

            if (!this.WordUnderline.Contains('_'))
            {
                break;
            }
            if (eingabe == "1")
            {
                if (this.AbortGame())
                {
                    return;
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine(this.WordUnderline);
        Console.WriteLine("Glückwunsch! Gewonnen! benötigte Versuche: {0}", versuche);
        Stats spiel = new Stats(versuche, this.WordAsChars.Length);
        spiel.ShowScore();
        spiel.ProcessStats();
        Console.WriteLine("Mit Enter zurück zum Menü!");
        while (true)
        {
            string taste = Console.ReadLine();
            if ( taste == "")
            {
                return;
            }
        }
    }


    //Static Methods



}