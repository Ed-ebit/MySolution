public class MainProgram
{

    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");

        foreach (string argument in args)
        {
            Console.WriteLine(argument);
        }
    }
}