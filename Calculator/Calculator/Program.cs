using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

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
            Console.OutputEncoding = Encoding.UTF8; 
            float a = 0, b = 0;
            string[] operators = { "+", "-", "*", "/", "pow", "rt", "log", "convert", "var" };
            string[] clen1 = { "první sčítanec", "menšenec", "první činitel", "dělenec", "základ", "odmocněnec", "základ"};
            string[] clen2 = { "druhý sčítanec", "menšitel", "druhý činitel", "dělitel", "exponent", "odmocnitel", "argument"};
            float[] vars = new float[3];
            double result = 0;
            string operation;
            bool validinput;
            System.ConsoleKey check;
            do {
                do  //pokud uživatel bude zadávat proměnné, vrátí ho to na výběr operace 
                {
                    TextWall();
                    operation = Console.ReadLine();

                    while (!operators.Contains(operation))
                    {
                        Console.WriteLine("Zadejte prosím validní operaci");
                        operation = Console.ReadLine();  
                    }
                    if (Array.IndexOf(operators, operation) == 7) // pro převod mezi soustavami
                        Conv();
                    if (Array.IndexOf(operators, operation) == 8) // pro zapsání proměnné
                        Var(vars);
                }
                while (Array.IndexOf(operators, operation) >= 7);

                Console.WriteLine("Zadejte " + clen1[Array.IndexOf(operators, operation)] + ", anebo proměnnou ('X', 'Y', 'Z')");
                validinput = false;
                while (!validinput)     //rozdělení podle toho, jestli jde o proměnnou anebo platné číslo
                {
                    string input = Console.ReadLine();
                    if (input == "X" || input == "x")
                    {
                        a = vars[0];
                        validinput = true;
                    }
                    else if (input == "Y" || input == "y")
                    {
                        a = vars[1];
                        validinput = true;
                    }
                    else if(input == "Z" || input == "z")
                    {
                        a = vars[2];
                        validinput = true;
                    }
                    else if (float.TryParse(input, out a))
                        validinput = true;
                    else    
                        Console.WriteLine("Zadejte prosím racionální číslo");
                }

                Console.WriteLine("Zadejte " + clen2[Array.IndexOf(operators, operation)] + ", anebo proměnnou");
                validinput = false;
                while (!validinput)     //rozdělení podle toho, jestli jde o proměnnou anebo platné číslo
                {
                    string input = Console.ReadLine();
                    if (input == "X" || input == "x")
                    {
                        b = vars[0];
                        validinput = true;
                    }
                    else if (input == "Y" || input == "y")
                    {
                        b = vars[1];
                        validinput = true;
                    }
                    else if (input == "Z" || input == "z") 
                    {
                        b = vars[2];
                        validinput = true;
                    }
                    else if (float.TryParse(input, out b))
                        validinput = true;
                    else
                        Console.WriteLine("Zadejte prosím racionální číslo");
                }

                switch (Array.IndexOf(operators, operation))  //podle operace vykoná danou funkci
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
                        if(b == 0)
                            Console.WriteLine("Dělenec se nesmí rovnat nule");
                        result = Div(a, b); 
                        break;
                    case 4:
                        result = Pow(a, b);
                        break;
                    case 5:
                        result = Root(a, b);
                        break;
                    case 6:
                        if (a < 0 || a == 1)
                        {
                            Console.WriteLine("Základ musí být kladné číslo (kromě 1)");
                            result = float.NaN;
                        }
                        else
                            result = Log(a, b);
                        break;
                    case 7:
                        Console.WriteLine("Jestli se tenhle text objevil, něco je HODNĚ ŠPATNĚ");
                        break;
                    case 8:
                        Console.WriteLine("Jestli se tenhle text objevil, něco je HODNĚ ŠPATNĚ");
                        break;
                }

                Console.WriteLine(Environment.NewLine + "Výsledek je " + result);
                Console.WriteLine(Environment.NewLine + "Zmáčkněte klávesu 'Y' pro další příklad");

                check = Console.ReadKey().Key;
                Console.Clear();
            } while (check == ConsoleKey.Y);    //pokud není výstupní podmínka splněna, program končí
        }


        static void TextWall()
        {
            Console.WriteLine("Nejdříve zadejte operaci, kterou chcete vypočítat:");
            Console.WriteLine("'+' pro součet");
            Console.WriteLine("'-' pro rozdíl");
            Console.WriteLine("'*' pro násobek");
            Console.WriteLine("'/' pro podíl");
            Console.WriteLine("'pow' pro mocninu");
            Console.WriteLine("'rt' pro odmocninu");
            Console.WriteLine("'log' pro logaritmus");
            Console.WriteLine("Zadejte 'convert' pro převod mezi desítkovou a danou soustavou");
            Console.WriteLine("Zadejte 'var' pro definování nové proměnné");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
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
        static double Root(float a, float b)
        {
            return Math.Pow(a, 1 / b);
        }
        static double Log(float a, float b)
        {
            return Math.Log(a, b);
        }
        static void Conv()
        {
            int base1, base2, result1 = 0;
            string result2 = "";
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Zadejte soustavu, ze které převádíte (2 - 16)");
            while (!(int.TryParse(Console.ReadLine(), out base1) && base1 >= 2 && base1 <= 16))
                Console.WriteLine("Neplatný vstup");
            Console.WriteLine("Zadejte soustavu, do které převádíte (2 - 16)");
            while (!(int.TryParse(Console.ReadLine(), out base2) && base2 >= 2 && base2 <= 16))
                Console.WriteLine("Neplatný vstup");
            Console.WriteLine("Zadejte celé číslo ke konverzi");
            string toConvert = Console.ReadLine().ToUpper().Trim();

            char[] tmp = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            List<char> znaky = new List<char>(tmp);
            //převod na 10 soustavu
            for (int i = 0; i < toConvert.Length; i++)
            {
                char c = toConvert[i];
                var index = znaky.IndexOf(c);
                if(index == -1)
                {
                    Console.WriteLine("Zadané číslo obsahuje neplatný znak");
                    return;
                }
                result1 += index * (int)Pow(base1, toConvert.Length - i - 1);
            }
            //převod z 10 soustavy
            while (result1 > 0)
            {
                var index = result1 % base2;
                result2 = znaky[index] + result2;
                result1 /= base2;
            }

            Console.WriteLine(Environment.NewLine + "Výsledek je " + result2);
            Console.WriteLine(Environment.NewLine + "Zmáčkněte klávesu 'Y' pro další příklad");
            if (Console.ReadKey().Key != ConsoleKey.Y)
                Environment.Exit(0);
            Console.Clear();
            return;
        }
        static void Var(float[] variables)
        {
            Console.OutputEncoding = Encoding.UTF8;
            float x, y, z;  //pro zjednodušení kontroly vstupu
            Console.Clear();
            Console.WriteLine("Vyberte proměnnou, do které chcete zapsat");
            for (int i = 0; i < variables.Length; i++)      //výpis proměnných a jejich aktuálních hodnot
                Console.WriteLine("Proměnná " + (Char)(88 + i) + " má hodnotu " + variables[i]);
            Console.WriteLine(Environment.NewLine + "Zmáčkněte klávesu s názvem proměnné pro zapsání/úpravu hodnoty, anebo libovolnou jinou pro ukončení");
            switch (Console.ReadKey().Key)  //zápis do vybrané proměnné
            {
                case ConsoleKey.X:
                    Console.WriteLine("\bZadejte hodnotu pro x");
                    while (!float.TryParse(Console.ReadLine(), out x))
                        Console.WriteLine("Zadejte prosím racionální číslo");
                    variables[0] = x;
                    break;
                case ConsoleKey.Y: 
                    Console.WriteLine("\bZadejte hodnotu pro y");
                    while (!float.TryParse(Console.ReadLine(), out y))
                        Console.WriteLine("Zadejte prosím racionální číslo");
                    variables[1] = y;
                    break;
                case ConsoleKey.Z:
                    Console.WriteLine("\bZadejte hodnotu pro z");
                    while (!float.TryParse(Console.ReadLine(), out z))
                        Console.WriteLine("Zadejte prosím racionální číslo");
                    variables[2] = z;
                    break;
                default:
                    Console.Clear();
                    return;
            }

            Console.WriteLine(Environment.NewLine + "Zmáčkněte klávesu 'Y' pro zadání další proměnné, anebo libovolnou jinou pro ukončení");
            if (Console.ReadKey().Key == ConsoleKey.Y)
                Var(variables);
            Console.Clear();
        }
    }
}
