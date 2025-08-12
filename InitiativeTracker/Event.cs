using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class InitEvent
    {
        public string name;
        public int rounds;
        public string charinit_name;
        public InitEvent(string name, int rounds, string charinit_name)
        {
            this.name = name;
            this.rounds = rounds;
            this.charinit_name = charinit_name;
        }
    }
}
