using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class RechteckKlasse
{
    private double Width;
    private double Height;


    public void Describe()
    {
        Console.WriteLine("Ich bin ein Rechteck, meine Fläche ist {0}, " +
            "mein Umfang ist {1}, meine Höhe ist {2}, meine Weite {3}. " +
            "Bin ich ein Quadrat? {4} ", this.GetArea(),
            this.GetPerimeter(), this.Height, this.Width, this.IsSquare());
    }

    public double GetArea()
    {
        return this.Width * this.Height;
    }

    public double GetPerimeter()
    {
        return 2 * (this.Width + this.Height);
    }

    public bool IsSquare()
    {
        if (this.Width == this.Height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Getter und Setter
    public double GetWidth(double value)
    {
        return this.Width;
    }
    public double GetHeight(double value)
    {
        return this.Height;
    }
    public void SetWidth(double value)
    {
        if (value > 0)
        {
            this.Width = value;
        }
        else
        {
            throw new ArgumentException("Weite muss größer 0 sein!");
        }
    }
    public void SetHeight(double value)
    {
        if (value > 0)
        {
            this.Height = value;
        }
        else
        {
            throw new ArgumentException("Höhe muss größer 0 sein!");
        }
    }

}

