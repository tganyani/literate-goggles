// Класс комплексных чисел. Реализовать операции сложения, вычитания, умножения, деления, возведения в степень, извлечения корня.
using System;
class Complex
{
    public double Re;
    public double Im;

    public Complex(double real, double imaginary)
    {
        Re = real;
        Im = imaginary;
    }

    public double Abs
    {
        get
        {
            return Math.Sqrt(Re * Re + Im * Im);
        }
    }

    public double Arg
    {
        get
        {
            if (Re > 0 && Im > 0)
            {
                return Math.Atan(Im / Re);
            }
            else if (Re < 0 && Im > 0)
            {
                return Math.PI - Math.Atan(Math.Abs(Im) / Math.Abs(Re));
            }
            else if (Re < 0 && Im < 0)
            {
                return Math.PI + Math.Atan(Math.Abs(Im) / Math.Abs(Re));
            }
            else if (Re > 0 && Im < 0)
            {
                return 2 * Math.PI - Math.Atan(Math.Abs(Im) / Math.Abs(Re));
            }
            else if (Re > 0 && Im == 0)
            {
                return 0;
            }
            else if (Re == 0 && Im > 0)
            {
                return Math.PI / 2;
            }
            else if (Re < 0 && Im == 0)
            {
                return Math.PI;
            }
            else if (Re == 0 && Im < 0)
            {
                return 3 * Math.PI / 2;
            }
            else
            {
                return 0;
            }
        }
    }
    public Complex Soprezheniye
    {
        get
        {
            this.Im = -this.Im;
            return this;
        }

    }
    // операции сложения
    public Complex Add(Complex c1)
    {
        Complex c2 = new Complex(0, 0);
        c2.Re = this.Re + c1.Re;
        c2.Im = this.Im + c1.Im;
        return c2;
    }

    // вычитания
    public Complex Subtract(Complex c1)
    {
        Complex c2 = new Complex(0, 0);
        c2.Re = this.Re - c1.Re;
        c2.Im = this.Im - c1.Im;
        return c2;
    }
    // умножения на констант
    public Complex Scalar_Product(double c)
    {
        this.Re = c * this.Re;
        this.Im = c * this.Im;
        return this;
    }
    // умножения двух комплексных чисел
    public Complex Product(Complex c1)
    {
        if (this == c1.Soprezheniye)
        {
            this.Re = Math.Pow(this.Abs, 2);
            this.Im = 0;
            return this;
        }
        Complex c2 = new Complex(0, 0);
        c2.Re = this.Re * c1.Re - this.Im * c1.Im;
        c2.Im = this.Re * c1.Im + this.Im * c1.Re;

        return c2;
    }
    //  деления
    public Complex Division(Complex c1)
    {
        double module = c1.Abs;
        Complex c2 = this.Product(c1.Soprezheniye);
        return c2.Scalar_Product(1 / Math.Pow(module, 2));

    }
    // возведения в степень
    public Complex Power(int n)
    {
        double phi_n = this.Arg * n;
        double z_n = Math.Pow(this.Abs, n);
        this.Re = z_n * Math.Cos(phi_n);
        this.Im = z_n * Math.Sin(phi_n);

        return this;
    }
    // извлечения корня
    public Complex Root(int n)
    {
        double z_n = Math.Pow(this.Abs, 1.0 / n);
        double phi = this.Arg;
        List<Complex> roots = new List<Complex>();
        for (int i = 0; i < n; i++)
        {
            double phi_i = (phi + 2 * Math.PI * i) / n;
            double Re_i = z_n * Math.Cos(phi_i);
            double Im_i = z_n * Math.Sin(phi_i);
            roots.Add(new Complex(Re_i, Im_i));
        }
        int k = 0;
        foreach (var root in roots)
        {
            if (root.Im >= 0)
            {
                Console.WriteLine($"Root{k + 1} = {root.Re} + {root.Im}i");
            }
            else
            {
                Console.WriteLine($"Root{k + 1} = {root.Re}  {root.Im}i");
            }
            k += 1;
        }

        return roots[0];
    }

    public void Show()
    {
        if (this.Im >= 0)
        {
            Console.WriteLine($"{this.Re} + {this.Im}i");
        }
        else
        {
            Console.WriteLine($"{this.Re}  {this.Im}i");
        }
    }

    // operator overloading
    // операции сложения
    public static Complex operator + (Complex c1, Complex c2){
        Complex c3 = new Complex(0, 0);
        c3.Re = c1.Re + c2.Re;
        c3.Im = c1.Im + c2.Im;
        return c3;
    }
     // вычитания
    public static Complex operator - (Complex c1, Complex c2){
        Complex c3 = new Complex(0, 0);
        c3.Re = c1.Re - c2.Re;
        c3.Im = c1.Im - c2.Im;
        return c3;
    }

}

namespace ComplexNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(5, -2);
            Complex c2 = new Complex(3, 4);
            // Console.WriteLine($"Arg c1 = {c1.Arg}");
            // Console.WriteLine($"Abs c1 = {c1.Abs}");
            // Console.WriteLine($"Arg c2 = {c2.Arg}");
            // Console.WriteLine($"Abs c2 = {c2.Abs}");
            // Console.WriteLine($"c1 + c2 = {c1.Add(c2).Re} + {c1.Add(c2).Im} j");
            // Console.WriteLine($"c1c2 = {c1.Product(c2).Re} + {c1.Product(c2).Im} j");
            Console.Write("c1 + c2 = ");
            c1.Add(c2).Show();
            Console.Write("c1 - c2 = ");
            c1.Subtract(c2).Show();
            Console.Write("c1 / c2 = ");
            c1.Division(c2).Show();
            Console.Write("c2 x c2 = ");
            c2.Product(c1).Show();
            Complex c3 = new Complex(1, -1);
            Console.WriteLine("Roots of c3");
            c3.Root(8);
            Console.WriteLine("Roots of c1");
            c1.Root(6);
            // operator overloading
             Complex c4 = new Complex(5, -2);
            Complex c5 = new Complex(3, 4);
            Console.WriteLine("Through operator overloading");
            Complex C1 = c4 + c5;
            Console.Write("c4 + c5 = ");
            C1.Show();
             Complex C2 = c4 - c5;
            Console.Write("c4 - c5 = ");
            C2.Show();
        }
    }
}



