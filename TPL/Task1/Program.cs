using System;
using System.Diagnostics;
using System.Linq;
//Создайте массив чисел размерностью в 1 000 000 или более.
//Используя генератор случайных чисел, проинициализируйте 
//этот массив значениями. Создайте PLINQ запрос, который 
//позволит получить все нечетные числа из исходного массива.

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] massiv = new int[1000000];
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = random.Next(0, 1000);
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[] ms = massiv.AsParallel().Where((i) => i % 2 != 0).Select((i) => i).ToArray();
            //var mass = from item in massiv.AsParallel()
            //           where item % 2 != 0
            //           select item;
            //int[] ms = mass.ToArray();
            stopwatch.Stop();

            for (int i = 0; i < ms.Length; i++)
            {
                Console.WriteLine(ms[i]);

            }
            Console.WriteLine("Время получения только нечетных чисел: " + stopwatch.Elapsed.TotalSeconds);
            Console.WriteLine("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
