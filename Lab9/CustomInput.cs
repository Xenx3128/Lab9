    using System;
using System.Globalization;
namespace Input
{
    public static class CustomInput
    {
        public static int IntInput(
            string startInput,
            double lowerBoundary = Int32.MinValue,
            double upperBoundary = Int32.MaxValue
            )  // Process input of int parameters
        {
            int output;
            string input;
            bool ok = true;
            bool boundaryOk = true;
            do
            {
                if (ok && boundaryOk)
                {
                    Console.WriteLine(startInput);
                }
                else
                {
                    if (!ok)
                    {
                        Console.WriteLine($"Ошибка: введён не тип double. Повторите ввод");
                    }
                    else if (!boundaryOk)
                    {
                        Console.WriteLine($"Ошибка: число вышло за допустимые границы. Повторите ввод");
                    }
                }
                input = Console.ReadLine().Replace(',', '.');
                ok = int.TryParse(input, out output);
                boundaryOk = output > lowerBoundary && output < upperBoundary;
            } while (!ok || !boundaryOk);
            return output;
        }

        public static double DoubleInput(
            string startInput,
            double lowerBoundary = Double.MinValue,
            double upperBoundary = Double.MaxValue
            )  // Process input of int parameters
        {
            double output;
            string input;
            bool ok = true;
            bool boundaryOk = true;
            do
            {
                if (ok && boundaryOk)
                {
                    Console.WriteLine(startInput);
                }
                else
                {
                    if (!ok)
                    {
                        Console.WriteLine($"Ошибка: введён не тип double. Повторите ввод");
                    }
                    else if (!boundaryOk)
                    {
                        Console.WriteLine($"Ошибка: число вышло за допустимые границы. Повторите ввод");
                    }
                }
                input = Console.ReadLine().Replace(',', '.');
                ok = double.TryParse(input, System.Globalization.NumberStyles.Float, CultureInfo.InvariantCulture, out output);
                boundaryOk = output > lowerBoundary && output < upperBoundary;
            } while (!ok || !boundaryOk);
            return output;
        }
    }
}