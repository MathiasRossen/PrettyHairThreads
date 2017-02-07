using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairThreads
{
    class Scissor
    {
        public bool BeingUsed
        {
            get; set;
        }
        public string Name { get; set; }

        public Scissor(string name)
        {
            Name = name;
            BeingUsed = false;
        }
    }
}
