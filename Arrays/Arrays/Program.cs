using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MatrixCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<int[,]> matricies = new List<int[,]> { };
            int mat1, mat2;
            int[,] result;

            Console.WriteLine("Vítejte v maticové kalkulačce v1, zmáčkněte jakoukoliv klávesu pro zadání 1. matice");
            Console.ReadKey();
            Console.Write("\b");
            matricies.Add(NewMatrix());
            Console.Clear();
            PrintMatrix(matricies[0]);
            Console.WriteLine("Vaše matice byla uložena, můžete s ní dále pracovat" + Environment.NewLine);
            PrintMenuText(matricies.Count > 1);
            while (true)
            {
                Console.WriteLine(Environment.NewLine + "Zadejte číslo operace 1 - 6, nebo 7 pro ukončení");
                switch (FetchIndex(1, 7, "Zadejte celé číslo od 1 do 7"))
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Vaše uložené matice:");
                        PrintMatrixMenu(matricies);
                        Console.WriteLine("Zadejte:");
                        Console.WriteLine("1 pro zobrazení matice");
                        Console.WriteLine("2 pro vytvoření nové matice");
                        Console.WriteLine("3 pro smazání matice");
                        Console.WriteLine("4 pro návrat do menu");
                        switch (FetchIndex(1, 3, "Zadejte 1 - 4"))
                        {
                            case 1:     //zobrazení dané matice
                                mat1 = FetchMatrixIndex(matricies) - 1;
                                if (mat1 == -1)
                                    break;
                                PrintMatrix(matricies[mat1]);
                                Console.ReadKey();
                                break;

                            case 2:     //vytvoření nové matice
                                matricies.Add(NewMatrix());
                                break;

                            case 3:     //smazání matice
                                mat1 = FetchMatrixIndex(matricies) - 1;
                                if (mat1 == -1)
                                    break;
                                matricies.RemoveAt(mat1);
                                break;

                            case 4:
                                break;
                        }
                        Console.Clear();

                        break;

                    case 2:     //prohození prvků matice
                        mat1 = FetchMatrixIndex(matricies) - 1;
                        if (mat1 == -1)
                            break;
                        SwapMatrix(matricies[mat1]);
                        Console.Clear();
                        Console.WriteLine("Upravená matice:");
                        PrintMatrix(matricies[mat1]);
                        break;

                    case 3:     //transpozice matice
                        mat1 = FetchMatrixIndex(matricies) - 1;
                        if (mat1 == -1)
                            break;
                        matricies[mat1] = TransposeMatrix(matricies[mat1]);
                        Console.Clear();
                        Console.WriteLine("Upravená matice:");
                        PrintMatrix(matricies[mat1]);
                        break;

                    case 4:     //násobení matice celým číslem
                        mat1 = FetchMatrixIndex(matricies) - 1;
                        if (mat1 == -1)
                            break;
                        MultiplyMatrixByInt(matricies[mat1]);
                        Console.Clear();
                        Console.WriteLine("Upravená matice:");
                        PrintMatrix(matricies[mat1]);
                        break;

                    case 5:     //sčítání/odčítání dvou matic
                        mat1 = FetchMatrixIndex(matricies) - 1;
                        if (mat1 == -1)
                            break;
                        mat2 = FetchMatrixIndex(matricies) - 1;
                        if (mat1 == -1)
                            break;

                        Console.WriteLine("Budete matice sčítat (+), nebo odčítat? (-)?");
                        string x = Console.ReadLine();
                        while (x != "+" && x != "-")
                        {
                            Console.WriteLine("+ nebo - ?");
                            x = Console.ReadLine();
                        }
                        bool polarity = x == "+" ? true : false;

                        result = AddMatrix(matricies[mat1], matricies[mat2], polarity);
                        Console.Clear();
                        Console.WriteLine("Výsledná matice:");
                        PrintMatrix(result);
                        Console.WriteLine("Zmáčkněte klávesu S pro uložení nové matice");
                        if (Console.ReadKey().Key == ConsoleKey.S)
                            matricies.Add(result);
                        Console.Write("\b");
                        break;

                    case 6:     //násobení dvou matic
                        mat1 = FetchMatrixIndex(matricies) - 1;
                        if (mat1 == -1)
                            break;
                        mat2 = FetchMatrixIndex(matricies) - 1;
                        if (mat1 == -1)
                            break;
                        result = MultiplyMatrixByMatrix(matricies[mat1], matricies[mat2]);
                        Console.Clear();
                        Console.WriteLine("Výsledná matice:");
                        PrintMatrix(result);
                        Console.WriteLine("Zmáčkněte klávesu S pro uložení nové matice");
                        if (Console.ReadKey().Key == ConsoleKey.S)
                            matricies.Add(result);
                        Console.Write("\b");
                        break;

                    case 7:
                        System.Environment.Exit(0);
                        break;
                }
                PrintMenuText(matricies.Count > 1);
            }
        }
        static void PrintMenuText(bool twoOrMore)
        {
            Console.WriteLine("Seznam možných operací:");
            Console.WriteLine("1 - zobrazit uložené matice, přidat novou matici");
            Console.WriteLine("2 - prohazování prvků a skupin čísel uvnitř matice");
            Console.WriteLine("3 - transpozice matice");
            Console.WriteLine("4 - násobení dané matice celým číslem");
            Console.Write("5 - sčítání / odčítání dvou matic");
            Console.WriteLine(twoOrMore ? "" : " (potřebujete více než jednu matici)");
            Console.Write("6 - násobení dvou matic");
            Console.WriteLine(twoOrMore ? "" : " (potřebujete více než jednu matici)");
            Console.WriteLine("7 - ukončit program");
        }
        static int[,] NewMatrix()
        {
            int rows, cols;
            Random rnd = new Random();


            Console.WriteLine("Zadejte rozměr A (počet řad)");
            while (!(int.TryParse(Console.ReadLine(), out rows) && rows > 0))
                Console.WriteLine("Zadejte kladné celé číslo");
            Console.WriteLine("Zadejte rozměr B (počet sloupců)");
            while (!(int.TryParse(Console.ReadLine(), out cols) && cols > 0))
                Console.WriteLine("Zadejte kladné celé číslo");

            int[,] matrix = new int[rows, cols];
            Console.WriteLine("Vyplnit matici náhodnými čísly (N), anebo řadou čísel (R)?");
            string x = Console.ReadLine();
            while (x != "n" && x != "N" && x != "r" && x != "R")
            {
                Console.WriteLine("N/R?");
                x = Console.ReadLine();
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (x == "n" || x == "N")
                        matrix[i, j] = rnd.Next(10);
                    else
                        matrix[i, j] = j + i * cols + 1;
                }
            }
            return matrix;
        }   //  1)
        static void PrintMatrix(int[,] matrix)  // ideálně max 15 * 15 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void PrintMatrixMenu(List<int[,]> mats)
        {
        }
        static int FetchWholeNumber(string request, string wrong)   // nástroj pro zadání celého čísla
        {
            int n;
            Console.WriteLine(request);
            while (!int.TryParse(Console.ReadLine(), out n))
                Console.WriteLine(wrong);
            return n;
        }
        static int FetchIndex(int lower, int upper, string wrong)   // nástroj pro zadání celého čísla v daných mezích
        {
            int index = 0;
            while (!(int.TryParse(Console.ReadLine(), out index) && index >= lower && index <= upper))
                Console.WriteLine(wrong);
            return index;
        }
        static int FetchMatrixIndex(List<int[,]> mats)
        {
            Console.WriteLine("Vaše matice jsou:");
            foreach (var matrix in mats)
            {
                Console.Write(mats.IndexOf(matrix) + 1);
                Console.Write(matrix == mats.Last() ? "\n" : ", ");
            }
            Console.WriteLine("Zadejte číslo ze seznamu, nebo '0' pro návrat do menu");
            return FetchIndex(0, mats.Count, "Zadejte číslo 1 - " + mats.Count + ", nebo 0 pro návrat do menu");

        }
        static void SwapMatrix(int[,] matrix) //  2)
        {
            int r1 = 0, r2 = 0, c1 = 0, c2 = 0, temp, shorterSide = 0;
            if (matrix.GetLength(0) <= matrix.GetLength(1))
                shorterSide = matrix.GetLength(0);
            else
                shorterSide = matrix.GetLength(1);
            Console.WriteLine("Přejete si prohodit:");
            Console.WriteLine("1 - dvě řady");
            Console.WriteLine("2 - dva sloupce");
            Console.WriteLine("3 - dva prvky");
            Console.WriteLine("4 - prvky na hlavní diagonále");
            Console.WriteLine("5 - prvky na vedlejší diagonále");
            Console.WriteLine("Zadejte číslo od 1 do 5");

            switch (FetchIndex(1, 5, "Zadejte číslo od 1 do 5"))
            {
                case 1:
                    if (matrix.GetLength(0) < 2)
                    {
                        Console.WriteLine("tato matice nemá dostatek řad");
                        break;
                    }
                    Console.WriteLine("Které dvě řady si přejete prohodit?");
                    Console.WriteLine("Zadejte číslo 1. řady (1 - " + matrix.GetLength(0) + ")");
                    r1 = FetchIndex(1, matrix.GetLength(0), "Zadejte číslo od 1 do " + matrix.GetLength(0)) - 1;
                    Console.WriteLine("Zadejte číslo 2. řady (1 - " + matrix.GetLength(0) + ")");
                    r2 = FetchIndex(1, matrix.GetLength(0), "Zadejte číslo od 1 do " + matrix.GetLength(0)) - 1;
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        temp = matrix[r1, i];
                        matrix[r1, i] = matrix[r2, i];
                        matrix[r2, i] = temp;
                    }

                    break;

                case 2:
                    if (matrix.GetLength(1) < 2)
                    {
                        Console.WriteLine("tato matice nemá dostatek sloupců");
                        break;
                    }

                    Console.WriteLine("Které dva sloupce si přejete prohodit?");
                    Console.WriteLine("Zadejte číslo 1. sloupce (1 - " + matrix.GetLength(1) + ")");
                    c1 = FetchIndex(1, matrix.GetLength(1), "Zadejte číslo od 1 do " + matrix.GetLength(1)) - 1;
                    Console.WriteLine("Zadejte číslo 2. sloupce (1 - " + matrix.GetLength(1) + ")");
                    c2 = FetchIndex(1, matrix.GetLength(1), "Zadejte číslo od 1 do " + matrix.GetLength(1)) - 1;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        temp = matrix[i, c1];
                        matrix[i, c1] = matrix[i, c2];
                        matrix[i, c2] = temp;
                    }
                    break;

                case 3:
                    if (matrix.Length < 2)
                    {
                        Console.WriteLine("tato matice nemá dostatek prvků");
                        break;
                    }
                    Console.WriteLine("Které dva prvky si přejete prohodit?");
                    Console.WriteLine("Zadejte číslo řady 1. prvku (1 - " + matrix.GetLength(0) + ")");
                    r1 = FetchIndex(1, matrix.GetLength(0), "Zadejte číslo od 1 do " + matrix.GetLength(0)) - 1;
                    Console.WriteLine("Zadejte číslo sloupce 1. prvku (1 - " + matrix.GetLength(1) + ")");
                    c1 = FetchIndex(1, matrix.GetLength(1), "Zadejte číslo od 1 do " + matrix.GetLength(1)) - 1;
                    Console.WriteLine("Zadejte číslo řady 2. prvku (1 - " + matrix.GetLength(0) + ")");
                    r2 = FetchIndex(1, matrix.GetLength(0), "Zadejte číslo od 1 do " + matrix.GetLength(0)) - 1;
                    Console.WriteLine("Zadejte číslo sloupce 2. prvku (1 - " + matrix.GetLength(1) + ")");
                    c2 = FetchIndex(1, matrix.GetLength(1), "Zadejte číslo od 1 do " + matrix.GetLength(1)) - 1;
                    temp = matrix[r1, c1];
                    matrix[r1, c1] = matrix[r2, c2];
                    matrix[r2, c2] = temp;
                    break;

                case 4:
                    for (int i = 0; i < shorterSide / 2; i++) // v případě lichého čísla se prostřední prvek nemění
                    {
                        temp = matrix[i, i];
                        matrix[i, i] = matrix[shorterSide - i - 1, shorterSide - i - 1];
                        matrix[shorterSide - i - 1, shorterSide - i - 1] = temp;
                    }
                    break;

                case 5:
                    for (int i = 0; i < shorterSide / 2; i++)
                    {
                        int j = shorterSide - i - 1;
                        temp = matrix[i, j];
                        matrix[i, j] = matrix[j, i];
                        matrix[j, i] = temp;
                    }
                    break;
            }
        }
        static void MultiplyMatrixByInt(int[,] matrix)    //  3) 
        {
            int row, collumn, multiplier = 0;
            Console.WriteLine("Přejete si násobit:");
            Console.WriteLine("1 - celou tabulku");
            Console.WriteLine("2 - řádek");
            Console.WriteLine("3 - sloupec");
            Console.WriteLine("4 - prvek");
            Console.WriteLine("Zadejte číslo od 1 do 4");

            switch (FetchIndex(1, 4, "Zadejte číslo od 1 do 4"))
            {
                case 1:
                    multiplier = FetchWholeNumber("Zadejte mocnitel", "Zadejte celé číslo");
                    for (int i = 0; i < matrix.GetLength(0); i++)
                        for (int j = 0; j < matrix.GetLength(1); j++)
                            matrix[i, j] *= multiplier;
                    break;

                case 2:
                    Console.WriteLine("Zadejte číslo řady, kterou budete násobit (1 - " + matrix.GetLength(0) + ")");
                    row = FetchIndex(1, matrix.GetLength(0), "Zadejte číslo od 1 do " + matrix.GetLength(0)) - 1;
                    multiplier = FetchWholeNumber("Zadejte mocnitel", "Zadejte celé číslo");
                    for (int i = 0; i < matrix.GetLength(1); i++)
                        matrix[row, i] *= multiplier;
                    break;

                case 3:
                    Console.WriteLine("Zadejte číslo sloupce, který budete násobit (1 - " + matrix.GetLength(1) + ")");
                    collumn = FetchIndex(1, matrix.GetLength(1), "Zadejte číslo od 1 do " + matrix.GetLength(1)) - 1;
                    multiplier = FetchWholeNumber("Zadejte mocnitel", "Zadejte celé číslo");
                    for (int i = 0; i < matrix.GetLength(0); i++)
                        matrix[i, collumn] *= multiplier;
                    break;

                case 4:
                    Console.WriteLine("Zadejte číslo řady prvku, který chcete násobit (1 - " + matrix.GetLength(0) + ")");
                    row = FetchIndex(1, matrix.GetLength(0), "Zadejte číslo od 1 do " + matrix.GetLength(0)) - 1;
                    Console.WriteLine("Zadejte číslo sloupce prvku, který chcete násobit (1 - " + matrix.GetLength(1) + ")");
                    collumn = FetchIndex(1, matrix.GetLength(1), "Zadejte číslo od 1 do " + matrix.GetLength(1)) - 1;
                    multiplier = FetchWholeNumber("Zadejte mocnitel", "Zadejte celé číslo");
                    matrix[row, collumn] += multiplier;
                    break;
            }
        }
        static int[,] AddMatrix(int[,] matrix1, int[,] matrix2, bool pol) //  4) 
        {
            int rows = matrix1.GetLength(0) < matrix2.GetLength(0) ? matrix1.GetLength(0) : matrix2.GetLength(0);
            int cols = matrix1.GetLength(1) < matrix2.GetLength(1) ? matrix1.GetLength(1) : matrix2.GetLength(1);
            int[,] result = new int[rows, cols];
            //vytvoří matici z dvou menších rozměrů

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = pol ? matrix1[i, j] + matrix2[i, j] : matrix1[i, j] - matrix2[i, j];
            return result;
        }
        static int[,] TransposeMatrix(int[,] matrix)    //  5) 
        {
            int[,] result = new int[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    result[i, j] = matrix[j, i];
            return result;
        }
        static int[,] MultiplyMatrixByMatrix(int[,] matrix1, int[,] matrix2)    //  6)  
        {
            int rows = matrix1.GetLength(0) < matrix2.GetLength(0) ? matrix1.GetLength(0) : matrix2.GetLength(0);
            int cols = matrix1.GetLength(1) < matrix2.GetLength(1) ? matrix1.GetLength(1) : matrix2.GetLength(1);
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = matrix1[i, j] * matrix2[i, j];
            return result;
        }
    }
}