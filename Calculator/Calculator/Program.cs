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
            float a, b;
            Console.WriteLine("Zadejte číslo a");
            while (!float.TryParse(Console.ReadLine(), out a))
                Console.WriteLine("Zadejte prosím racionální číslo");
            Console.WriteLine("Zadejte číslo b");
            while (!float.TryParse(Console.ReadLine(), out b))
                Console.WriteLine("Zadejte prosím racionální číslo");
            Console.WriteLine("Zadejte \"+\" pro součet čísel, \"-\" pro rozdíl čísel");

            float result = 0;
            string operace = Console.ReadLine();
            while (operace != "+" && operace != "-")
            {
                Console.WriteLine("Zadejte prosím validní znaménko operace");
                operace = Console.ReadLine();
            }
            if (operace == "+")
                result = a + b;
            else
                result = a - b;
            Console.WriteLine("Výsledek je " + result);

            Console.ReadKey(); 
        }
    }
}
