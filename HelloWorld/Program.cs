// Methode um Strings umzukehren: abc zu bca
class SpassMitStrings
{

    public static void Main()
    {
        Console.WriteLine("Moin. Bitte eine Zeichenkette eingeben und mit Enter bestätigen!");
        string s = Console.ReadLine();
        Console.WriteLine(" Kehrt man die eingegebene Zeichenkette um, erhält man {0}", ReverseString(s));
        Console.WriteLine(" Ist die Zeichenkette ein Palindrom? {0}!", IsPalindrome(s));
    }
    //Methoden
    public static string? ReverseString(string s)
    {
        string neuS = "";
        for (int i = s.Length-1; i >= 0; i--)
        {
            neuS += s[i];
        }
        return neuS;
    }

    public static bool IsPalindrome(string s)
    {
        if (s.Equals(ReverseString(s), StringComparison.CurrentCultureIgnoreCase))
        {
            return true;
        }
            else 
        {
            return false;
        }
    }
}