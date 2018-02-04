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
            string text;
            text = "5 6 9;4 5 6;1 -5 -200";
            //text = "1 2 3;4 5 6;7 8 9";

            MatrixList.Add(new Matrix());
            int index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

            MatrixList[index].Rows = 3;
            MatrixList[index].Columns = 3   ;
            MatrixList[index].MatrixName = "3x3";
            MatrixList[index].MatrixTab = EnterStringToIntMatrix(text, 3, 3);

            MatrixList.Add(new Matrix());
            index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

            text = "2 2 2;2 2 2;2 2 2";
            MatrixList[index].Rows = 3;
            MatrixList[index].Columns = 3;
            MatrixList[index].MatrixName = "3x3 222";
            MatrixList[index].MatrixTab = EnterStringToIntMatrix(text, 3, 3);


            MatrixList.Add(new Matrix());
            index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

            text = "-5 8 4 31;13 54 -8 74;1 0 2 -3;-4 5 46 6";
            MatrixList[index].Rows = 4;
            MatrixList[index].Columns = 4;
            MatrixList[index].MatrixName = "4x4 DET!=0";
            MatrixList[index].MatrixTab = EnterStringToIntMatrix(text, 4, 4);


            int n;
            n = 0;
            while (n != 99)
            {

                Console.WriteLine(
                    "1. Enter New Matrix\n" +
                    "2. List of Matrixs\n" +
                    "3. Matrix Addidtion\n" +
                    "4. Matrix Subbtraction\n" +
                    "5. Matrix Multiplication by number\n" +
                    "6. Matrix Multiplication Matrix by Matrix\n" +
                    "7. Transpose Matrix\n" +
                    "8. Det Matrix\n"+
                    "9. Matrix Invers\n"
                    );
             


                Console.WriteLine("Select number:");
                text = Console.ReadLine();
                Int32.TryParse(text, out n);

                switch (n)
                {
                    case 1:

                        int columns;
                        int rows;
                        int a, b;
                        a = 0;
                        b = 0;
                        string MatrixName;

                        Console.WriteLine("Write number od rows, columns and Matrix like in Example\n4\n4\n1 2 3 4; 5 6 7 8; 9 10 11 12; 13 14 15 16\n");

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
                        index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

                        MatrixList[index].Rows = rows;
                        MatrixList[index].Columns = columns;
                        MatrixList[index].MatrixName = MatrixName;
                        MatrixList[index].MatrixTab = EnterStringToIntMatrix(text, rows, columns);

                        WriteMatrix(MatrixList[index].MatrixTab);

                        Console.ReadKey();
                        break;

                    case 2:

                        ShowMatrixList(MatrixList);

                        Console.ReadKey();

                        break;

                    case 3:

                        Console.WriteLine("Choose Matrix from list to addition\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose first Matrix:");
                        b = ReadNumb("Choose second Matrix:");

                        WriteMatrix(MatrixAddition(MatrixList[a].MatrixTab, MatrixList[b].MatrixTab));

                        Console.ReadKey();

                        break;


                    case 4:

                        Console.WriteLine("Choose Matrix from list to subtract\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose first Matrix:");
                        b = ReadNumb("Choose second Matrix:");

                        WriteMatrix(MatrixSubbtraction(MatrixList[a].MatrixTab, MatrixList[b].MatrixTab));

                        Console.ReadKey();

                        break;

                    case 5:

                        Console.WriteLine("Choose Matrix from list and enter number to Multiply\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose first Matrix:");
                        b = ReadNumb("Enter number:");

                        WriteMatrix(MatrixMultiplicationByNumber(MatrixList[a].MatrixTab, b));

                        Console.ReadKey();

                        break;

                    case 6:

                        Console.WriteLine("Choose Matrix from list to Multiply\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose first Matrix:");
                        b = ReadNumb("Choose second Matrix:");

                        WriteMatrix(MatrixMultiplication(MatrixList[a].MatrixTab, MatrixList[b].MatrixTab));

                        Console.ReadKey();

                        break;
                    case 7:

                        Console.WriteLine("Choose Matrix from list to Transpose\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose first Matrix:");

                        WriteMatrix(MatrixTranspose(MatrixList[a].MatrixTab));

                        Console.ReadKey();

                        break;
                    case 8:

                        Console.WriteLine("Choose Matrix from list to calculate Determinant\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose Matrix:");

                        Console.WriteLine(MatrixDeterminant(MatrixList[a].MatrixTab));

                        Console.ReadKey();

                        break;

                    case 9:

                        Console.WriteLine("Choose Matrix from list to Invers\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose Matrix:");

                        WriteMatrix(MatrixInverse(MatrixList[a].MatrixTab));

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

        static int ReadNumb(string text) {
            int Numb;
            Console.WriteLine(text);
            text = Console.ReadLine();
            Int32.TryParse(text, out Numb );
            return Numb;

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

        static int[,] MatrixAddition(int[,] Tab1, int[,] Tab2)
        {
            int i, j;
            int[,] Tab3 = new int[Tab1.GetLength(0), Tab1.GetLength(0)];
            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLength(1); j++)
                {
                    Tab3[i, j] = Tab1[i, j] + Tab2[i, j];
                };

            }
            return Tab3;


        }

        static int[,] MatrixSubbtraction(int[,] Tab1, int[,] Tab2)
        {
            int i, j;
            int[,] Tab3 = new int[Tab1.GetLength(0), Tab1.GetLength(0)];
            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLength(1); j++)
                {
                    Tab3[i, j] = Tab1[i, j] - Tab2[i, j];
                };

            }
            return Tab3;

        }

        static int[,] MatrixMultiplication(int[,] Tab1, int[,] Tab2)
        {
            int i, j, k, MultipCache;

            int[,] FinnalTab = new int[Tab1.GetLength(0), Tab1.GetLength(0)];
            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab2.GetLength(1); j++)
                {
                    k = 0;
                    MultipCache = 0;
                    for (k = 0; k < Tab1.GetLength(1); k++)
                    {
                        MultipCache += Tab1[i, k] * Tab2[k, j];
                    }
                    FinnalTab[i, j] = MultipCache;
                };

            }
            return FinnalTab;

        }

        static int[,] MatrixMultiplicationByNumber(int[,] Tab1, int k)
        {
            int i, j;

            int[,] FinnalTab = new int[Tab1.GetLength(0), Tab1.GetLength(0)];
            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLength(1); j++)
                {
                    FinnalTab[i, j] = Tab1[i, j] * k;
                };

            }
            return FinnalTab;

        }

        static int[,] MatrixExponentiation(int[,] Tab1, int n)
        { int i;
            int[,] FinnalTab = new int[Tab1.GetLength(0), Tab1.GetLength(0)];
            FinnalTab = Tab1;

            for (i = 0; i < n; i++)
                FinnalTab = MatrixMultiplication(FinnalTab, Tab1);

            return FinnalTab;

        }

        static int MatrixDeterminant(int[,] Tab1)
        {
            int i;

           if (Tab1.GetLength(0) == Tab1.GetLength(1))
            {
                if (Tab1.GetLength(0) == 1)
                    return Tab1[0, 0];
                else if (Tab1.GetLength(1) == 2)
                {

                    return (Tab1[0, 0] * Tab1[1, 1] - Tab1[0, 1] * Tab1[1, 0]);
                }
                else {
                    double det;
                    det = 0;
                    int Size = Tab1.GetLength(0);
                    int[,] Temp = new int[Size -1,Size-1];

                    for (i = 0; i < Size; i++)
                    {
                        det += Tab1[0, i] * Math.Pow(-1, 1 + i + 1) * MatrixDeterminant(MatrixComplements(Tab1,0,i));
                    }
                    int det2;
                    det2 = Convert.ToInt32(det);               
                    return det2;
                }
                  
            }
                return 0;
        }

        static int[,] MatrixComplements(int[,] Tab1, int a, int b)
        {

            int k, l, Size, check, check2;
            check2 = 0;
            check = 0;
            Size = Tab1.GetLength(0);
            int[,] Temp = new int[Size - 1, Size - 1];


            for (k = 0; k < Size - 1; k++)
            {
                if ((k == a) || (check > 0))
                {
                    check++;
                    for (l = 0; l < Size - 1; l++)
                    {

                        if ((l == b) || (check2 > 0))
                        {
                            Temp[k, l] = Tab1[k + 1, l + 1];
                            check2++;
                        }
                        else
                        {
                            Temp[k, l] = Tab1[k + 1, l];
                        }
                    }
                    check2 = 0;
                }
                else
                {
                    for (l = 0; l < Size - 1; l++)
                    {

                        if ((l == b) || (check2 > 0))
                        {
                            Temp[k, l] = Tab1[k, l + 1];
                            check2++;
                        }
                        else
                        {
                            Temp[k, l] = Tab1[k, l];
                        }
                    }
                    check2 = 0;
                }
            }

            return Temp;

        }

        static int[,] MatrixTranspose(int[,] Tab1)
        {

            int[,] FinnalTab = new int[Tab1.GetLength(1), Tab1.GetLength(0)];

            int i, j;

            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLength(1); j++)
                {
                    FinnalTab[i, j] = Tab1[j, i];
                }
            }
            return FinnalTab;
        }

        static double[,] MatrixTranspose(double[,] Tab1)
        {

            double[,] FinnalTab = new double[Tab1.GetLength(1), Tab1.GetLength(0)];

            int i, j;

            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLength(1); j++)
                {
                    FinnalTab[i, j] = Tab1[j, i];
                }
            }
            return FinnalTab;
        }

        static double[,] MatrixInverse(int[,] Tab1) {

            int i, j;

            double[,] Inverse = new double[Tab1.GetLongLength(0), Tab1.GetLongLength(0)];

            for (i = 0; i < Tab1.GetLongLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLongLength(0); j++)
                {
                    Inverse[i, j] = ((1/Convert.ToDouble(MatrixDeterminant(Tab1)))*(Convert.ToDouble(MatrixDeterminant(MatrixComplements(Tab1,i,j)))));
                    
                }

            }
            return MatrixTranspose(Inverse);
        }
        
        static void ShowMatrixList(List<Matrix> MatrixList) {
            int i = 0;
            foreach (Matrix show in MatrixList)
            {
                Console.WriteLine(i+". " + show.MatrixName);
                WriteMatrix(show.MatrixTab);
                i++;
            }

            Console.WriteLine();

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

        static void WriteMatrix(double[,] tab)
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