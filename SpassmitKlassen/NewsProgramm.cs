public class Newsprogramm
{
    public static void Main()
    {
        Console.WriteLine("News Programm");

        NewsAgency agency = new NewsAgency();

        agency.NewNews += SubscriberOne;
        
        agency.NewNews += SubscriberTwo;

        agency.GetInformedByInformant("Edward", "Turkish Lira rising again!");
        //agency.NewNews("Corona endlich vorbei");
        //agency.NewNews("Gegen java! Für C#!");
    }

    //"Abonnenten" für die Neuigkeiten und damit Eventhandler schreiben

    public static void SubscriberOne(string news)
    {
        Console.WriteLine("One: Thanks for ze News!");
        Console.WriteLine(news);
    }
    public static void SubscriberTwo(string news)
    {
        Console.WriteLine("Two: Whoop Whoop alles falsch!");
        Console.WriteLine(news);
    }
}