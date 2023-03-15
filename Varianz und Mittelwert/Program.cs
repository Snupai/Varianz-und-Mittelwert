using System.Diagnostics;
using System.Globalization;
using static System.Console;
using static Yann.wc;

namespace Varianz_und_Mittelwert
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] messwerte = { 100, 99, 101, 102, 98 };

            WriteLine(Varianz(messwerte));

            ReadKey();
        }

        static double Mittelwert(double[] messwerte)
        {
            double summe = 0;
            foreach (double value in messwerte)
            {
                summe += value;
            }
            return summe / messwerte.Length;
        }

        static double Varianz(double[] messwerte)
        {
            double mittelwert = Mittelwert(messwerte);
            double summe = 0;
            foreach (double value in messwerte)
            {
                summe += Math.Pow(value - mittelwert, 2);
            }
            return summe / (messwerte.Length - 1);
        }

        static void Example()
        {
            //
            // This program demonstrates all colors and backgrounds.
            //
            Type type = typeof(ConsoleColor);
            ForegroundColor = ConsoleColor.White;
            foreach (var name in Enum.GetNames(type))
            {
                BackgroundColor = (ConsoleColor)Enum.Parse(type, name);
                WriteLine(name);
            }
            BackgroundColor = ConsoleColor.Black;
            foreach (var name in Enum.GetNames(type))
            {
                ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
                WriteLine(name);
            }

            //
            // This is an example to show you how to you WriteColor or WriteLineColor
            //
            WriteLineColor("\nYou can see all possible colors above!\nThis is an example string for <*!red*>background color<*/!*> and <*red*>foreground color<*/*>.");

        }
    }
}