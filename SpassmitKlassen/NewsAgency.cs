
public class NewsAgency
{
    public event NewsEventHandler? NewNews;
    public event NewsEventHandler? FakeNews;// 'event' verhindert Auslösung des Delegates durch Drittcode,
                                            // Delegate wird geschützt. Code kann nur noch über Klasse ausgelöst werden.
                                            // Leichtere Kontrolle. Aber Methoden um auslösen müssen nun in die Klasse,
                                            // nicht ins Hauptprogramm

    public void GetInformedByInformant ( string name, string report)
    {
        string news = $"Informant: {name}\nNews: {report}";
        if (NewNews is not null)
        {
            //Callen der Subscriber
            NewNews.Invoke(news);
        }
    }

    public NewsAgency()
    {

    }
}