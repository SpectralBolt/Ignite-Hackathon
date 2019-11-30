using System;

namespace ML.NET_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string date = "5/05/2018";
            string[] splitted = date.Split('/');
            for (int i = 0; i < splitted.Length; i++)
            {
                Console.WriteLine(int.Parse(splitted[i]));
                Console.WriteLine(i);
            }
        }
    }
}
