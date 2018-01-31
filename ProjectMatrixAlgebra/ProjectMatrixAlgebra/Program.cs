using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMatrixAlgebra
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Matrix> MatrixList = new List<Matrix>();

            int n;
            n = 0;
            while (n != 99)
            {

                Console.WriteLine("1. Enter New Matrix\n" +
                    "2. List of Matrixs");
                string text;


                Console.WriteLine("Select number:");
                text = Console.ReadLine();
                Int32.TryParse(text, out n);

                switch (n)
                {
                    case 1:

                        int columns;
                        int rows;
                        string MatrixName;

                        Console.WriteLine("Write number od rows, columns and Matrix like in Example\n4\n4\n1 2 3 4; 5 6 7 8; 9 10 11 12; 13 14 15 16\n");

                        text = "1 2 3 4;5 6 7 8;9 10 11 12;13 14 15 16";
                        EnterStringToIntMatrix(text, 4, 4);

                        Console.WriteLine("Name of Matrix:");
                        MatrixName = Console.ReadLine();

                        Console.WriteLine("Number of columns:");
                        text = Console.ReadLine();
                        Int32.TryParse(text, out columns);

                        Console.WriteLine("Number of rows:");
                        text = Console.ReadLine();
                        Int32.TryParse(text, out rows);

                        Console.WriteLine("Enter The Matrix:");
                        text = Console.ReadLine();

                        //Example to testing
                        //text = "221 2333 3333 4444;25 46 57 68;99 190 99911 912;0 0 0 0";

                        MatrixList.Add(new Matrix());
                        int index = (MatrixList.Count - 1);

                        MatrixList[index].Rows = rows;
                        MatrixList[index].Columns = columns;
                        MatrixList[index].MatrixName = MatrixName;
                        MatrixList[index].MatrixTab = EnterStringToIntMatrix(text, rows, columns);

                        WriteMatrix(MatrixList[index].MatrixTab);

                        Console.ReadKey();
                        break;

                    case 2:

                        foreach (Matrix show in MatrixList)
                            Console.WriteLine(show.MatrixName);

                        Console.WriteLine();
                        Console.ReadKey();
                        break;


                }

            }


        }
        class Matrix
        {

            private String matrixName;
            private int rows, columns;
            private int[,] matrixTab;

            public string MatrixName { get => matrixName; set => matrixName = value; }
            public int Rows { get => rows; set => rows = value; }
            public int Columns { get => columns; set => columns = value; }
            public int[,] MatrixTab { get => matrixTab; set => matrixTab = value; }


        }
        static int[,] EnterStringToIntMatrix(string text, int rows, int columns)
        {

            int[,] MatrixTab = new int[columns, rows];
            int i, j, row, column, number;
            string cache;
            cache = "";
            row = 0;
            column = 0;
            number = 0;
            for (i = 0; i < text.Length; i++)
            {

                if (text[i] != ' ' && text[i] != ';')
                {
                    cache += text[i];
                    Int32.TryParse(cache, out number);

                    MatrixTab[row, column] = number;
                }
                else if (text[i] == ';')
                {
                    row++;
                    column = 0;
                    cache = "";
                }
                else
                {
                    column++;
                    cache = "";
                }

            }
            return MatrixTab;

        }


        static void WriteMatrix(int[,] tab)
        {

            int i, j;

            for (i = 0; i < tab.GetLength(0); i++)
            {
                for (j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i, j] + "\t");

                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

    }
}