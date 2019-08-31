using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Создайте два метода, которые будут выполняться в рамках параллельных задач.
//Организуйте вызов этих методов при помощи Invoke таким образом, чтобы основной 
//поток программы(метод Main) не остановил свое выполнение.
namespace Task2
{
    class Program
    {
        /// <summary>
        /// 5 секунд деятельности
        /// </summary>
        static void Method1()
        {
            Console.WriteLine("Method1 start");
            Thread.Sleep(5000);
            Console.WriteLine("Method1 end");
        }
        /// <summary>
        /// 8 секунд деятельности
        /// </summary>
        static void Method2()
        {
            Console.WriteLine("Method2 start");
            Thread.Sleep(8000);
            Console.WriteLine("Method2 end");
        }
        /// <summary>
        /// 4 секунд деятельности
        /// </summary>
        static void Method3(Task task)
        {
            Console.WriteLine("Method3 start");
            Thread.Sleep(4000);
            Console.WriteLine("Method3 end");
        }

        static void Main(string[] args)
        {
            //1 способ
            Task task1 = new Task(new Action(Method1));
            Task task2 = new Task(Method2);
            task1.Start();
            task2.Start();
            task1.Wait();
            task2.Wait();
            Console.WriteLine(new string('_', 25));
            //2 способ
            Task task = Task.Factory.StartNew(() => Parallel.Invoke(Method2, Method1));
            task.Wait();
            Console.WriteLine(new string('_', 25));
            //3 способ
            task1 = new Task(new Action(Method1));
            Task task3 = task1.ContinueWith(Method3);
            task1.Start();
            Task.WaitAll(task3, task1);

            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}

