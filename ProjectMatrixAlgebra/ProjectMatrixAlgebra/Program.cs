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
            int a, b;
            int RandomCount;
            bool loop;
            loop = false;
            RandomCount = 0;
            a = 0;
            b = 0;

            MatrixList.Add(new Matrix());
            int index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);
           
            text = "9;9;9";
            MatrixList[index].Rows = 3;
            MatrixList[index].Columns = 1;
            MatrixList[index].MatrixName = "3x1 9;9;9";
            MatrixList[index].setMatrixTab(EnterStringToIntMatrix(text, 3, 1));

            MatrixList.Add(new Matrix());
            index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

            text = "5 6 9;4 5 6;1 -5 -200";
            MatrixList[index].Rows = 3;
            MatrixList[index].Columns = 3   ;
            MatrixList[index].MatrixName = "3x3";
            MatrixList[index].setMatrixTab(EnterStringToIntMatrix(text, 3, 3));

            MatrixList.Add(new Matrix());
            index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

            text = "2 2 2;2 2 2;2 2 2";
            MatrixList[index].Rows = 3;
            MatrixList[index].Columns = 3;
            MatrixList[index].MatrixName = "3x3 222 DET=0";
            MatrixList[index].setMatrixTab(EnterStringToIntMatrix(text, 3, 3));


            MatrixList.Add(new Matrix());
            index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

            text = "-5 8 4 31;13 54 -8 74;1 0 2 -3;-4 5 46 6";
            MatrixList[index].Rows = 4;
            MatrixList[index].Columns = 4;
            MatrixList[index].MatrixName = "4x4 DET!=0";
            MatrixList[index].setMatrixTab(EnterStringToIntMatrix(text, 4, 4));

            int n;
            n = 0;
            while (n != 99)
            {

                Console.WriteLine(
                    "1. Enter New Matrix\n"+
                    "2. Delete Matrix\n"+
                    "3. List of Matrixs\n" +
                    "4. Matrix Addidtion\n" +
                    "5. Matrix Subbtraction\n" +
                    "6. Matrix Multiplication by number\n" +
                    "7. Matrix Multiplication Matrix by Matrix\n" +
                    "8. Transpose Matrix\n" +
                    "9. Det Matrix\n"+
                    "10. Matrix Invers\n"+
                    "11. Matrix Division\n"
                    );

                Console.WriteLine("Select number:");
                text = Console.ReadLine();
                Int32.TryParse(text, out n);

                Console.WriteLine();

                switch (n)
                {
                    case 0:
                        Console.Clear();
                        break;
                    case 1:
                        string text2;
                        text2 = "";

                        Console.WriteLine("Create random square Matrix?\n\nif yes type:\ty Y  yes YES\nif no  type: whatever ");
                        text2=Console.ReadLine();

                        if ((text2 == "y") || (text2 == "Y") || (text2 == "YES") || (text2 == "yes")) {
                            a = ReadNumb("Enter size:");
                            
                            MatrixList.Add(new Matrix());
                            index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);
                            MatrixList[index].setMatrixTab(MatrixRandom(a));
                            MatrixList[index].Rows = a;
                            MatrixList[index].Columns = a;
                            MatrixList[index].MatrixName = "RandomMatrix "+RandomCount+" "+a+"x"+a;

                            Console.WriteLine(MatrixList[index].MatrixName);
                            WriteMatrix(MatrixList[index].MatrixTab);
                        }
                        else
                        {

                            int columns, rows;
                            rows = 6;
                            columns = 6;
                            string MatrixName;

                            Console.WriteLine("Write number od rows, columns and Matrix like in Example\n4\n4\n1 2 3 4; 5 6 7 8; 9 10 11 12; 13 14 15 16\nspace\t-> separate numbers in column\n;\t-> separate rows\n");

                            Console.WriteLine("Name of Matrix:");
                            MatrixName = Console.ReadLine();

                            while (rows > 5 || rows < 1)
                            {
                                rows = ReadNumb("Number of rows:");

                                if (rows > 5)
                                    Console.WriteLine("Max size is 5");
                                else if (rows < 1)
                                    Console.WriteLine("Wrong size");
                            }

                            while ((columns > 5) || (columns < 1))
                            {
                                columns = ReadNumb("Number of columns:");

                                if (columns > 5)
                                    Console.WriteLine("Max size is 5");
                                else if (columns < 1)
                                    Console.WriteLine("Wrong size");
                            }

                            Console.WriteLine("Enter The Matrix:");
                            text = Console.ReadLine();

                            MatrixList.Add(new Matrix());
                            index = (MatrixList.Count == 0 ? 0 : MatrixList.Count - 1);

                            MatrixList[index].Rows = rows;
                            MatrixList[index].Columns = columns;
                            MatrixList[index].MatrixName = MatrixName;
                            MatrixList[index].setMatrixTab(EnterStringToIntMatrix(text, rows, columns));

                            WriteMatrix(MatrixList[index].MatrixTab);
                        }
                        Console.ReadKey();
                        break;

                    case 2:

                        if (MatrixList.Count > 0)
                        {

                            ShowMatrixList(MatrixList);

                            try
                            {
                                MatrixList.Remove(MatrixList[ReadNumb("Choose matrix to delete:", MatrixList.Count)]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                Console.WriteLine("Index Out of Range\n");
                            };
                        }else
                            Console.WriteLine("Please Enter Matrix first\n");

                        break;


                    case 3:

                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        ShowMatrixList(MatrixList);

                        Console.ReadKey();

                        break;

                    case 4:

                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list to addition\n");

                        ShowMatrixList(MatrixList);
                        
                        loop = false;

                        while (!loop)
                        {
                            a = ReadNumb("Choose first Matrix:", MatrixList.Count);
                            b = ReadNumb("Choose second Matrix:", MatrixList.Count);

                            if ((MatrixList[a].Rows == MatrixList[b].Rows) && (MatrixList[a].Columns == MatrixList[b].Columns))
                            {
                                loop = true;
                                WriteMatrix(MatrixAddition(MatrixList[a].MatrixTab, MatrixList[b].MatrixTab));
                            }
                            else
                            {
                                Console.WriteLine("Choosen Matrices must have the same size\n");
                                Console.WriteLine("Do you want to break?\n\nif yes type:\ty Y  yes YES\nif no  type: whatever ");
                                text2 = Console.ReadLine();

                                if ((text2 == "y") || (text2 == "Y") || (text2 == "YES") || (text2 == "yes"))
                                {
                                    goto case 0;
                                }
                            }
                            Console.ReadKey();
                        }
                        break;


                    case 5:

                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list to subtract\n");

                        ShowMatrixList(MatrixList);

                        loop = false;

                        while (!loop)
                        {

                            a = ReadNumb("Choose first Matrix:",MatrixList.Count);
                            b = ReadNumb("Choose second Matrix:", MatrixList.Count);

                            if ((MatrixList[a].Rows == MatrixList[b].Rows) && (MatrixList[a].Columns == MatrixList[b].Columns))
                            {
                                loop = true;
                                WriteMatrix(MatrixSubbtraction(MatrixList[a].MatrixTab, MatrixList[b].MatrixTab));
                            }
                            else
                            {
                                Console.WriteLine("Choosen Matrices must have the same size");

                                Console.WriteLine("Do you want to break?\n\nif yes type:\ty Y  yes YES\nif no  type: whatever ");
                                text2 = Console.ReadLine();

                                if ((text2 == "y") || (text2 == "Y") || (text2 == "YES") || (text2 == "yes"))
                                {
                                    goto case 0;
                                }
                            }
                            Console.ReadKey();
                        }
                        break;

                    case 6:

                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list and enter number to Multiply\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose first Matrix:", MatrixList.Count);
                        b = ReadNumb("Enter number:");

                        WriteMatrix(MatrixMultiplicationByNumber(MatrixList[a].MatrixTab, b));

                        Console.ReadKey();

                        break;

                    case 7:

                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list to Multiply\n");

                        ShowMatrixList(MatrixList);

                        loop = false;

                        while (!loop)
                        {
                            a = ReadNumb("Choose first Matrix:", MatrixList.Count);
                            b = ReadNumb("Choose second Matrix:", MatrixList.Count);

                            if ((MatrixList[a].Columns == MatrixList[b].Rows))
                            {
                                loop = true;
                                WriteMatrix(MatrixMultiplication(MatrixList[a].MatrixTab, MatrixList[b].MatrixTab));
                            }
                            else
                            {
                                Console.WriteLine("Number Columns in first Matrix must be the same like number Rows in second Matrix");

                                Console.WriteLine("Do you want to break?\n\nif yes type:\ty Y  yes YES\nif no  type: whatever ");
                                text2 = Console.ReadLine();

                                if ((text2 == "y") || (text2 == "Y") || (text2 == "YES") || (text2 == "yes"))
                                {
                                    goto case 0;
                                }
                            }
                            Console.ReadKey();
                        }
                        break;
                    case 8:
                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list to Transpose\n");

                        ShowMatrixList(MatrixList);

                        a = ReadNumb("Choose Matrix:", MatrixList.Count);

                        WriteMatrix(MatrixTranspose(MatrixList[a].MatrixTab));

                        Console.ReadKey();

                        break;
                    case 9:
                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list to calculate Determinant\n");

                        ShowMatrixList(MatrixList);
                        loop = false;

                        while (!loop)
                        {
                            a = ReadNumb("Choose Matrix:", MatrixList.Count);

                            if ((MatrixList[a].Columns == MatrixList[a].Rows))
                            {
                                loop = true;
                                Console.WriteLine(MatrixDeterminant(MatrixList[a].MatrixTab));
                            }
                            else { 
                                Console.WriteLine("Matrix must be square");
                                Console.WriteLine("Do you want to break?\n\nif yes type:\ty Y  yes YES\nif no  type: whatever ");
                                text2 = Console.ReadLine();

                                if ((text2 == "y") || (text2 == "Y") || (text2 == "YES") || (text2 == "yes"))
                                {
                                    goto case 0;
                                }
                            }
                            Console.ReadKey();
                        }
                        break;

                    case 10:
                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list to Invers\n");

                        ShowMatrixList(MatrixList);
                        loop = false;

                        while (!loop)
                        {
                            a = ReadNumb("Choose Matrix:", MatrixList.Count);

                            if ((MatrixList[a].Rows == MatrixList[a].Columns) &&  (MatrixDeterminant(MatrixList[a].MatrixTab) != 0))
                            {
                                loop = true;
                                WriteMatrix(MatrixInverse(MatrixList[a].MatrixTab));
                            }
                            else
                            {
                                Console.WriteLine("Choosen Matrix must have the same number of rows and columns and determinant different than 0");

                                Console.WriteLine("Do you want to break?\n\nif yes type:\ty Y  yes YES\nif no  type: whatever ");
                                text2 = Console.ReadLine();

                                if ((text2 == "y") || (text2 == "Y") || (text2 == "YES") || (text2 == "yes"))
                                {
                                    goto case 0;
                                }
                            }
                            Console.ReadKey();
                        }
                        break;

                    case 11:
                        Console.WriteLine(MatrixList.Count);
                        if (MatrixList.Count < 1)
                        {
                            Console.WriteLine("Matrix list is empty\nPlease Enter Matrix first\n");
                            goto case 1;
                        }

                        Console.WriteLine("Choose Matrix from list to Division\n");

                        ShowMatrixList(MatrixList);
                        loop = false;

                        while (!loop)
                        {
                            a = ReadNumb("Choose first Matrix:", MatrixList.Count);
                           
                            b = ReadNumb("Choose second Matrix:", MatrixList.Count);

                            if (MatrixDeterminant(MatrixList[b].MatrixTab) != 0)
                            {

                                if ((MatrixList[a].Columns == MatrixList[a].Rows) && (MatrixList[b].Columns == MatrixList[b].Rows) && (MatrixList[a].Rows == MatrixList[b].Rows))
                                {
                                    loop = true;
                                    WriteMatrix(MatrixMultiplication(MatrixList[a].MatrixTab, MatrixInverse(MatrixList[b].MatrixTab)));
                                }
                                else

                                    Console.WriteLine("Choosen Matrix must have the same size");
                            }
                            else
                            {

                                Console.WriteLine("Second Matrix must have determinant different than 0");

                                Console.WriteLine("Do you want to break?\n\nif yes type:\ty Y  yes YES\nif no  type: whatever ");
                                text2 = Console.ReadLine();

                                if ((text2 == "y") || (text2 == "Y") || (text2 == "YES") || (text2 == "yes"))
                                {
                                    goto case 0;
                                }
                                Console.ReadKey();
                            }
                        }
                        break;

                }

            }


        }
        class Matrix
        {

            private String matrixName;
            private int rows, columns;
            protected double[,] matrixTab;
            

            public string MatrixName { get => matrixName; set => matrixName = value; }
            public int Rows { get => rows; set => rows = value; }
            public int Columns { get => columns; set => columns = value; }
            public double[,] MatrixTab { get => matrixTab;}

            public void setMatrixTab(double[,] Tab1) {

                matrixTab = Tab1;

            }
        }

        static int ReadNumb(string text, int max)
        {
            int Numb;
            Numb = 0;
            Console.WriteLine(text);
            bool check;
            check = false;
            while (!check)
            {
                text = Console.ReadLine();
                if (Int32.TryParse(text, out Numb))
                {
                    if ((Numb >= max) || (Numb < 0))
                        Console.WriteLine("Out of Range");
                    else
                        return Numb;
                }
                else
                    Console.WriteLine("It is not a Integer");
            }

            return Numb;
        }

        static int ReadNumb(string text)
        {
            int Numb;
            Numb = 0;
            Console.WriteLine(text);
            bool check;
            check = false;
            while (!check)
            {
                text = Console.ReadLine();
                if (Int32.TryParse(text, out Numb))
                    return Numb;
                else
                    Console.WriteLine("It is not a Integer");
            }

            return Numb;
        }

        static double[,] EnterStringToIntMatrix(string text, int rows, int columns)
        {

            double[,] MatrixTab = new double[rows, columns];
            int i, row, column, number;
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

        static double[,] MatrixAddition(double[,] Tab1, double[,] Tab2)
        {

                int i, j;
                double[,] Tab3 = new double[Tab1.GetLength(0), Tab1.GetLength(1)];
                for (i = 0; i < Tab1.GetLength(0); i++)
                {
                    for (j = 0; j < Tab1.GetLength(1); j++)
                    {
                        Tab3[i, j] = Tab1[i, j] + Tab2[i, j];
                    };

                }
                return Tab3;            
        }

        static double[,] MatrixSubbtraction(double[,] Tab1, double[,] Tab2)
        {
            int i, j;
            double[,] Tab3 = new double[Tab1.GetLength(0), Tab1.GetLength(0)];
            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLength(1); j++)
                {
                    Tab3[i, j] = Tab1[i, j] - Tab2[i, j];
                };

            }
            return Tab3;

        }

        static double[,] MatrixMultiplication(double[,] Tab1, double[,] Tab2)
        {
            int i, j, k;
            double MultipCache;

            double[,] FinnalTab = new double[Tab1.GetLength(0), Tab1.GetLength(0)];
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

        static double[,] MatrixMultiplicationByNumber(double[,] Tab1, int k)
        {
            int i, j;

            double[,] FinnalTab = new double[Tab1.GetLength(0), Tab1.GetLength(0)];
            for (i = 0; i < Tab1.GetLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLength(1); j++)
                {
                    FinnalTab[i, j] = Tab1[i, j] * k;
                };

            }
            return FinnalTab;

        }

        static double[,] MatrixExponentiation(double[,] Tab1, int n)
        { int i;
            double[,] FinnalTab = new double[Tab1.GetLength(0), Tab1.GetLength(0)];
            FinnalTab = Tab1;

            for (i = 0; i < n; i++)
                FinnalTab = MatrixMultiplication(FinnalTab, Tab1);

            return FinnalTab;

        }

        static double MatrixDeterminant(double[,] Tab1)
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
                    double[,] Temp = new double[Size -1,Size-1];

                    for (i = 0; i < Size; i++)
                    {
                        det += Tab1[0, i] *Math.Pow(-1,1+i+1)* MatrixDeterminant(MatrixComplements(Tab1,0,i));
                    }
             
                    return det;
                }
                  
            }
                return 0;
        }

        static double[,] MatrixComplements(double[,] Tab1, int a, int b)
        {

            int k, l, Size, check, check2;
            check2 = 0;
            check = 0;
            Size = Tab1.GetLength(0);
            double[,] Temp = new double[Size - 1, Size - 1];


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
            
            for (int i = 0; i < Temp.GetLength(0); i++) {
                for (int j = 0; j < Temp.GetLongLength(1); j++) {

                    Temp[i, j] = Math.Pow(-1, i+1 + j+1) * Temp[i, j];
                }
            }       

            return Temp;

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

        static double[,] MatrixInverse(double[,] Tab1) {

            int i, j;

            double[,] Inverse = new double[Tab1.GetLongLength(0), Tab1.GetLongLength(0)];

            for (i = 0; i < Tab1.GetLongLength(0); i++)
            {
                for (j = 0; j < Tab1.GetLongLength(0); j++)
                {
                    Inverse[i, j] = ((1/(MatrixDeterminant(Tab1)))*Math.Pow(-1,i+1+j+1)*((MatrixDeterminant(MatrixComplements(Tab1,i,j)))));
                    
                }

            }
            return MatrixTranspose(Inverse);
        }

        static double[,] MatrixRandom(int x) {

            double[,] Tab1 = new double[x,x];
            int i, j;
            Random rnd = new Random();
            for (i = 0; i < x; i++) {
                for (j = 0; j < x; j++) {
                    Tab1[i,j]= rnd.Next(-100,100);
                };
            };
            return Tab1;


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

        static void WriteMatrix(double[,] tab)
        {

            int i, j;

            for (i = 0; i < tab.GetLength(0); i++)
            {
                for (j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write("\t"+tab[i, j]);

                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

      

    }
}