using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskHW
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            int number = 6;

            Task task1 = new Task(() =>
            {
                for (int i = 1; i <= number; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Операция прервана");
                        return;
                    }
                    Thread.Sleep(5000);
                }
            });
            task1.Start();

            Console.WriteLine("Введите Z для отмены операции:");
            string s = Console.ReadLine();
            if (s == "Z")
                cancelTokenSource.Cancel();

            Console.Read();
        }
    }
}
