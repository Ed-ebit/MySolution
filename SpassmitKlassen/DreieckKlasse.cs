public class DreieckKlasse
{
    //Fields / Instanzattribute
    private double SideA;
    private double SideB;
    private double SideC;

    //Konstruktoren

    public DreieckKlasse(double a, double b, double c)
    {
        SetLengths(a, b, c);
    }

    public DreieckKlasse(double length)
    {
        SetLengths(length, length, length);
    }

    //Statische Methoden

    public static DreieckKlasse CreateRightAngled(double a, double b)
    {
        double c = Math.Sqrt((a * a + b * b));
        return new DreieckKlasse(a, b, c);
    }

    //Instanzmethoden

    public void SetLengths(double a, double b, double c)
    {
        if (!IsValid(a, b, c))
        {
            throw new ArgumentException("Invalid triangle");
        }
        SideA = a;
        SideB = b;
        SideC = c;
    }

    public void Describe()
    {
        Console.WriteLine("Ich bin ein Dreieck Namens {0}, meine Fläche ist {1}, mein Umfang {2}, " +
            "Seitenlängen: a = {3}, b = {4}, c = {5}",this, this.GetArea(), this.GetPerimeter(), SideA, SideB, SideC);
        //Console.WriteLine("Bin ich rechtwinklig? {0}", this.IsRightAngled());
    }

    public double GetArea()
    {
        double s = 0.5 * GetPerimeter();
        double area = Math.Sqrt(
            s * (s - SideA) * (s - SideB) * (s - SideC));

        return area;
    }

    public double GetPerimeter()
    {
        return SideA + SideB + SideC;
    }

    public bool IsRightAngled()
    {
        double[] sortiert = new double[3] { SideA, SideB, SideC };
        Array.Sort(sortiert);
        for (int i = 0; i <= sortiert.Length; i++)
        {
            Console.WriteLine("{0}", sortiert[i]);
        }
        if (sortiert[0] * sortiert[0] + sortiert[1] * sortiert[1] == sortiert[2] * sortiert[2])
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool IsValid(double a, double b, double c)
    {
        return (a + b > c) && (c + b > a) && (a + c > b);
    }


}