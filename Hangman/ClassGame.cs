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
        return chosenWord.ToLower();
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

    public void CheckGuess(string eingabe)
    {
        Console.Clear();
        if (eingabe.Length > 1 || eingabe.Length < 1)
        {
            Console.WriteLine("Ungültige Eingabe, bitte genau einen Buchstaben eingeben!");
        }
        else
        {
            char taste = eingabe.ToLower()[0];
            if (WordAsChars.Contains(taste) &! WordUnderline.Contains(taste))
            {
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
                Console.WriteLine("Leider kein Treffer! Nächster Versuch!");
            }
        }
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
        while (true)
        {
            Console.WriteLine();
            foreach(char ch in this.WordUnderline)
            {
                Console.WriteLine(" {0}", WordUnderline[(ch-1)]);
            }
            //Console.WriteLine(this.WordUnderline));
            Console.WriteLine("Bitte einen Buchstaben raten und mit Enter bestätigen");
            Console.WriteLine("Um das Spiel zu beenden, die Zahl 1 eingeben");
            eingabe = Console.ReadLine();

            this.CheckGuess(eingabe);

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
        Console.WriteLine("Glückwunsch! Gewonnen!");
        Console.WriteLine(this.WordUnderline);
        Thread.Sleep(2500);
    }


    //Static Methods



}