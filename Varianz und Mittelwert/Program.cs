using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata;
using static System.Console;
using static Yann.Wc;

namespace Varianz_und_Mittelwert
{
    internal class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
                double[] array = ArrayFüllen();
                WriteLineColor($"<*!blue*>Varianz:\t\t{Varianz(array)}<*/!*>");
                WriteLineColor($"<*!red*>Mittelwert:\t\t{Mittelwert(array)}<*/!*>");
                WriteLineColor($"<*!blue*>Standardabweichung:\t{Standardabweichung(array)}<*/!*>");
                WriteLineColor($"<*!red*>Max Wert:\t\t{array.Max()}<*/!*>");
                WriteLineColor($"<*!blue*>Min Wert:\t\t{array.Min()}<*/!*>");
                WriteLineColor($"<*!red*>Median:\t\t\t{Median(array)}<*/!*>");
                string str = ReadLine();
                if (str == "s") break;
            }
        }

        static double[] ArrayFüllen()
        {
            // Erstelle ein Random-Objekt
            Random random = new Random();

            // Erstelle ein double array mit 10000 Elementen
            double[] array = new double[10_000_000];
            //double[] array = new double[] { 1, 2, 3, 4, 5 };


            // Fülle das array mit zufälligen Zahlen von -1000 bis +1000
            for (int i = 0; i < array.Length; i++)
            {
                //array[i] = random.Next(-1000, 1000);
                array[i] = -1_000 + 2_000 * random.NextDouble();
            }
            return array;

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

        static double Median(double[] messwerte)
        {
            Array.Sort(messwerte);
            int middleIndex = messwerte.Length / 2;

            if (messwerte.Length % 2 == 1)
            {
                return messwerte[middleIndex];
            }
            else
            {
                double sum = messwerte[middleIndex - 1] + messwerte[middleIndex];
                return sum / 2;
            }

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