using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task5
{
    class Program
    {
        static int Number(string n)
        {
            string n1 = n.Trim();
            return Convert.ToInt32(n1);
        }
        static double[] Array(string n, int num)
        {
            string n1 = n.Trim(' ');
            string[] arr = new string[num];
            int c = 0;
            for (int i = 0; i < num && c < n1.Length; i++)
            {
                try
                {
                    while (n1[c] != ' ')
                    {
                        arr[i] = arr[i] + n1[c];
                        c++;
                    }
                    n1 = n1.Remove(0, c);
                    n1 = n1.Trim();
                    c = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            double[] mas = new double[num];
            for (int i = 0; i < num; i++)
            {
                mas[i] = Convert.ToDouble(arr[i]);
            }
            return mas;
        }
        static void InsertionSort(double[] array)
        {
            FileStream f = new FileStream("output.txt", FileMode.OpenOrCreate);
            StreamWriter w = new StreamWriter(f);
            double[] A = array;
            for (int i = 0; i < A.Length-1; i++)
            {
                for (int j = i; j < A.Length; j++)
                {
                    if (A[i] > A[j])
                    {
                        double z = A[i];
                        A[i] = A[j];
                        A[j] = z;
                        w.WriteLine("Swap elements at indices {0} and {1}.",i+1,j+1);
                    }
                }
            }
            w.WriteLine("No more swaps needed.");
            foreach(double x in A)
            {
                w.Write(x + " ");
            }
            w.Close();
            f.Close();
        }
        static void Main(string[] args)
        {
            FileStream f = new FileStream("input.txt", FileMode.OpenOrCreate);
            StreamReader r = new StreamReader(f);
            string s1 = r.ReadLine();
            string s2 = r.ReadLine();
            f.Close();
            r.Close();
            int num = Number(s1);
            double[] mas = Array(s2, num);
            InsertionSort(mas);
        }
    }
}
