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
            WriteLine(Mittelwert(messwerte));
            WriteLine(Varianz(messwerte));
            WriteLine(Standardabweichung(messwerte));
            ReadKey();
        }

        /// <summary>
        /// Errechnet den Mittelwert für alle Werte eines Arrays.
        /// </summary>
        /// <param name="messwerte"></param>
        /// <returns>Mittelwert</returns>
        static double Mittelwert(double[] messwerte)
        {
            double summe = 0;
            foreach (double value in messwerte)
            {
                summe += value;
            }
            return summe / messwerte.Length;
        }

        /// <summary>
        /// Errechnet die Varianz für alle Werte eines Arrays.
        /// </summary>
        /// <param name="messwerte"></param>
        /// <returns>Varianz</returns>
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

        /// <summary>
        /// Errechnet die Standardabweichung für alle Werte eines Arrays.
        /// </summary>
        /// <param name="messwerte"></param>
        /// <returns>Standardabweichung</returns>
        static double Standardabweichung(double[] messwerte)
        {
            double summe = Math.Round(Math.Sqrt(Varianz(messwerte)), 4);
            return summe;
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