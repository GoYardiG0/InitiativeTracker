using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeTracker
{
    internal class CharInit
    {
        public string name;
        public int initiative;
        public int modifier;

        public CharInit(string name, int initive)
        {
            this.name = name;
            this.initiative = initive;
        }
        public override string ToString()
        {
            return $"{name}: {initiative}";
        }
    }
}
