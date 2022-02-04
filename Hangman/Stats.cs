using System.Text.Json;

public class Stats
{
    //Properties

    public decimal Tries { get; }
    public decimal WordLength { get; }
    public decimal Score { get; }
    public string Time { get; }
    public string GamerTag { get; private set; }

    //Constructors

    public Stats(int tries, int wordLength)
    {
        this.Time = DateTime.Now.ToString();
        this.Tries = tries;
        this.WordLength = wordLength;
        this.Score = Math.Floor((this.WordLength/this.Tries)*1000);
    }

    public Stats(decimal tries, decimal wordLength, decimal score, string time, string gamerTag)
    {
        this.Tries=tries;
        this.WordLength=wordLength;
        this.Score=score;
        this.Time = time;
        this.GamerTag = gamerTag;
    }

    //Instance Methods

    public void ProcessStats()
    {
        this.SetGamerTag();
        string jsonString = JsonSerializer.Serialize(this);
        if (!File.Exists(@"Data\log.json"))
        {
            StreamWriter sw = File.CreateText(@"data\log.json");
            sw.WriteLine(jsonString);
            sw.Close();
        }
        else if (File.Exists(@"Data\log.json"))
        {
            StreamWriter sw = File.AppendText(@"Data\log.json");
            sw.WriteLine(jsonString);
            sw.Close();
        }

    }

    public void ShowScore()
    {
        Console.WriteLine("Dein Score: {0}", this.Score);
    }

    public void SetGamerTag()
    {
        Console.WriteLine("Bitte gib dein GamerTag für diese epische Punktzahl ein!");
        Console.WriteLine("Bitte GENAU 4 Zeichen:");
        while (true)
        {
            string gamertag = Console.ReadLine();
            if (gamertag.Length == 4)
            {
                this.GamerTag = gamertag.ToUpper();
                return;
            }
            else
            {
                Console.WriteLine("falsche Eingabe");
            }
        }
    }
    public void ShowHighScore()
    {

    }

    //Static Methods
    public static void ReadHighScores()
    {

    }
}