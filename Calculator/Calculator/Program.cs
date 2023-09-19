using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float a, b = 0;
            string[] operatory = { "+", "-", "*", "/", "pow", "sqrt" };
            double result = 0;
            do
            {
                TextWall();
                string operace = Console.ReadLine();
                while (!operatory.Contains(operace))
                {
                    Console.WriteLine("Zadejte prosím validní operaci");
                    operace = Console.ReadLine();
                }

                Console.WriteLine("Zadejte číslo a");
                while (!float.TryParse(Console.ReadLine(), out a))
                    Console.WriteLine("Zadejte prosím racionální číslo");
                if (Array.IndexOf(operatory, operace) < 5)
                {
                    Console.WriteLine("Zadejte číslo b");
                    while (!float.TryParse(Console.ReadLine(), out b))
                        Console.WriteLine("Zadejte prosím racionální číslo");
                }

                switch (Array.IndexOf(operatory, operace))
                {
                    case 0:
                        result = Add(a, b);
                        break;
                    case 1:
                        result = Sub(a, b);
                        break;
                    case 2:
                        result = Mult(a, b);
                        break;
                    case 3:
                        result = Div(a, b);
                        break;
                    case 4:
                        result = Pow(a, b);
                        break;
                    case 5:
                        result = Sqrt(a);
                        break;
                }

                Console.WriteLine(Environment.NewLine + "Výsledek je " + result);
                Console.WriteLine(Environment.NewLine + "Zmáčkněte klávesu 'Y' pro další příklad");
                if (Console.ReadKey().Key != ConsoleKey.Y)
                    break;
                Console.Clear();
            } while (true);
        }
        static void TextWall()
        {
            Console.WriteLine("Zadejte:");
            Console.WriteLine("'+' pro součet");
            Console.WriteLine("'-' pro rozdíl");
            Console.WriteLine("'*' pro násobek");
            Console.WriteLine("'/' pro podíl");
            Console.WriteLine("'pow' pro mocninu");
            Console.WriteLine("'sqrt' pro druhou odmocninu");
        }
        static float Add(float a, float b)
        {
            return a + b;
        }
        static float Sub(float a, float b)
        {
            return a - b;
        }
        static float Mult(float a, float b)
        {
            return a * b;
        }
        static float Div(float a, float b)
        {
            return a / b;
        }
        static double Pow(float a, float b)
        {
            return Math.Pow(a, b);
        }
        static double Sqrt(float a)
        {
            return Math.Sqrt(a);
        }
    }
}
