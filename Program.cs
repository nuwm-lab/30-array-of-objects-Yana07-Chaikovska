using System;

class Vector
{
    public double X { get; private set; }
    public double Y { get; private set; }

    public double Length => Math.Sqrt(X * X + Y * Y);

    public Vector(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X}, {Y}), Length = {Length:F3}";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введіть кількість векторів n: ");

        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Помилка: введіть додатне ціле число.");
            return;
        }

        Vector[] vectors = new Vector[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведіть компоненти для вектора №{i + 1}:");

            double x = ReadDouble("  X = ");
            double y = ReadDouble("  Y = ");

            vectors[i] = new Vector(x, y);
        }

        int maxIndex = 0;
        double maxLength = vectors[0].Length;

        for (int i = 1; i < n; i++)
        {
            if (vectors[i].Length > maxLength)
            {
                maxLength = vectors[i].Length;
                maxIndex = i;
            }
        }

        Console.WriteLine("\nВектор з найбільшою довжиною:");
        Console.WriteLine(vectors[maxIndex]);
    }

    static double ReadDouble(string label)
    {
        double value;

        while (true)
        {
            Console.Write(label);
            if (double.TryParse(Console.ReadLine(), out value))
                return value;

            Console.WriteLine(" Помилка: введіть число!");
        }
    }
}
