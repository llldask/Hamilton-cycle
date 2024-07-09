using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiRgr
{
    internal class ZeroNowledge
    {
        public static int[,] fileToArray()
        {
            StreamReader f = new StreamReader("1.txt");
            string s;
            int i = 0;
            int[,] graph=null;
            int n= 0;
            while ((s = f.ReadLine()) != null)
            {
                if(i == 0)
                {
                    string[] subs = s.Split(' ');
                    n = int.Parse(subs[0]);
                    graph = new int[n, n];
                    i++;
                }
                else
                {
                    string[] subs = s.Split(' ');
                    int a= int.Parse(subs[0])-1;
                    int b= int.Parse(subs[1])-1;
                    graph[a,b] = 1;
                    graph[b, a] = 1;
                }
            }
            return graph;
        }
        public static int[] fileToHArray()
        {
            StreamReader f = new StreamReader("2.txt");
            string s;
            string[] subs = null;
            while ((s = f.ReadLine()) != null)
            {
                subs = s.Split(' ');
            }
            var res = new int[subs.Length];
            for (int i = 0;i<subs.Length;i++)
            {
                res[i]= int.Parse(subs[i]);
            }

            return res;
        }

       

        private static int MaxElem(int[,] A, int j)
        {
            int max = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (NumCount(A[i, j]) > max)
                    max = NumCount(A[i, j]);
            }
            return max;
        }
        private static int NumCount(int a)
        {
            return a.ToString().Length;
        }
        private static int MaxElem(long[,] A, int j)
        {
            int max = 0;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                if (NumCount(A[i, j]) > max)
                    max = NumCount(A[i, j]);
            }
            return max;
        }
        private static int NumCount(long a)
        {
            return a.ToString().Length;
        }
        private static int indent = 2;
        public static void Print(int[,] matrix)
        {
            Console.WriteLine();
            int I=matrix.GetLength(0);
            int J = I;
            int x = 0;

           
            int maxAd = NumCount(I);
            Console.WriteLine();
           // Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            for (int j = 0; j < J; j++)
            {
                
                int current = NumCount(j+1);
                Console.SetCursorPosition(x + (maxAd - current), Console.CursorTop);
                Console.WriteLine(j+1);
                //yline++;
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - I-1);
            x += maxAd + indent;

            for (int j = 0; j < J; j++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int max = MaxElem(matrix,j);
               // Console.SetCursorPosition(x + (max - NumCount(j + 1)), Console.CursorTop);
                int currentLine = NumCount(j + 1);
                Console.SetCursorPosition(x + (max - currentLine), Console.CursorTop);
                Console.WriteLine(j + 1);
               // Console.WriteLine(" ");
                for (int i = 0; i < I; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    int current = NumCount(matrix[i, j]);
    
                    Console.SetCursorPosition(x + (max - current), Console.CursorTop);

                    Console.WriteLine(matrix[i, j]);

                }
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - I-1);
                x += max + indent;


            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + I);
            Console.WriteLine();
            Console.WriteLine();

        }

        public static void Print(long[,] matrix)
        {
            Console.WriteLine();
            int I = matrix.GetLength(0);
            int J = I;
            int x = 0;


            int maxAd = NumCount(I);
            Console.WriteLine();
            // Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            for (int j = 0; j < J; j++)
            {

                int current = NumCount(j + 1);
                Console.SetCursorPosition(x + (maxAd - current), Console.CursorTop);
                Console.WriteLine(j + 1);
                //yline++;
            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - I - 1);
            x += maxAd + indent;

            for (int j = 0; j < J; j++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var max =  MaxElem(matrix, j);
                // Console.SetCursorPosition(x + (max - NumCount(j + 1)), Console.CursorTop);
                int currentLine = NumCount(j + 1);
                Console.SetCursorPosition(x + (max - currentLine), Console.CursorTop);
                Console.WriteLine(j + 1);
                // Console.WriteLine(" ");
                for (int i = 0; i < I; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    int current = NumCount(matrix[i, j]);

                    Console.SetCursorPosition(x + (max - current), Console.CursorTop);

                    Console.WriteLine(matrix[i, j]);

                }
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - I - 1);
                x += max + indent;


            }
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + I);
            Console.WriteLine();
            Console.WriteLine();

        }


        public static void Print(int[] ar)
        {
            foreach (int i in ar)
                Console.Write(i+" ");
            Console.WriteLine();
        }

    }

}
