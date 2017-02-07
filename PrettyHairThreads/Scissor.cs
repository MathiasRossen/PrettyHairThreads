using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairThreads
{
    class Scissor
    {
        object padLock = new object();
        private bool beingUsed;
        public bool BeingUsed
        {
            get { return beingUsed; }
            set
            {
                lock (padLock)
                {
                    beingUsed = value;
                }
            }
        }
        public string Name { get; set; }

        public Scissor(string name)
        {
            Name = name;
            BeingUsed = false;
        }
    }
}
