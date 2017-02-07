using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrettyHairThreads
{
    class Program
    {
        Random rand;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        private void Run()
        {
            rand = new Random();

            Scissor scissor1 = new Scissor("Scissor1");
            Scissor scissor2 = new Scissor("Scissor2");
            Scissor scissor3 = new Scissor("Scissor3");
            Scissor scissor4 = new Scissor("Scissor4");
            Scissor scissor5 = new Scissor("Scissor5");
            Scissor scissor6 = new Scissor("Scissor6");

            HairCutter hc1 = new HairCutter("HC1", scissor1, scissor2);
            HairCutter hc2 = new HairCutter("HC2", scissor2, scissor3);
            HairCutter hc3 = new HairCutter("HC3", scissor3, scissor4);
            HairCutter hc4 = new HairCutter("HC4", scissor4, scissor5);
            HairCutter hc5 = new HairCutter("HC5", scissor5, scissor6);
            HairCutter hc6 = new HairCutter("HC6", scissor6, scissor1);

            Thread task1 = new Thread(hc1.StartCutting);
            Thread task2 = new Thread(hc2.StartCutting);
            Thread task3 = new Thread(hc3.StartCutting);
            Thread task4 = new Thread(hc4.StartCutting);
            Thread task5 = new Thread(hc5.StartCutting);
            Thread task6 = new Thread(hc6.StartCutting);

            task1.Start();
            Thread.Sleep(10);
            task2.Start();
            Thread.Sleep(10);
            task3.Start();
            Thread.Sleep(10);
            task4.Start();
            Thread.Sleep(10);
            task5.Start();
            Thread.Sleep(10);
            task6.Start();

            Console.Read();
        }
    }
}
