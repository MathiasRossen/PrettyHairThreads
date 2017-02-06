using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrettyHairThreads
{
    class HairCutter
    {
        int sessions = 10;
        Random rand;
        int minSleep = 100;
        int maxSleep = 600;

        public string Name { get; set; }
        public Scissor LeftScissor { get; set; }
        public Scissor RightScissor { get; set; }

        public HairCutter(string name, Scissor left, Scissor right)
        {
            Name = name;
            LeftScissor = left;
            RightScissor = right;
            rand = new Random();
        }

        public void StartCutting()
        {
            Console.WriteLine("{0} was booted.", Name);

            while(sessions > 0)
            {
                TryToGetScissors();
            }

            Console.WriteLine("{0} has completed cutting. Going home!", Name);
        }

        private void TryToGetScissors()
        {
            if(!LeftScissor.BeingUsed && !RightScissor.BeingUsed)
            {
                LeftScissor.BeingUsed = true;
                RightScissor.BeingUsed = true;

                Console.WriteLine("{0} and {1} weren't in use and are occupied by {2}", LeftScissor.Name, RightScissor.Name, Name);
                CutSession();
            }
            else
            {
                Console.WriteLine("{0} or {1} were already occupied. Trying again soon..", LeftScissor.Name, RightScissor.Name);
                Thread.Sleep(rand.Next(minSleep, maxSleep));
                TryToGetScissors();
            }
        }

        private void CutSession()
        {
            sessions--;
            Console.WriteLine("{0} is cutting. Sessions left: {1}", Name, sessions);
            Thread.Sleep(rand.Next(minSleep, maxSleep));
            TakeBreak();
        }

        private void TakeBreak()
        {
            LeftScissor.BeingUsed = false;
            RightScissor.BeingUsed = false;

            Console.WriteLine("{0} is taking a break.. {1} and {2} were released.", Name, LeftScissor.Name, RightScissor.Name);
            Thread.Sleep(rand.Next(minSleep, maxSleep));
        }
    }
}
