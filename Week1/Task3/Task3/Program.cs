using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] arr = new int[N];
            string[] tokens = Console.ReadLine().Split();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(tokens[i]);
            for(int i=0; i< arr.Length; i++)
            {
                Console.Write(arr[i] + " "   + arr[i] + " ");
            }
        Console.ReadKey();
        }
    }
}
