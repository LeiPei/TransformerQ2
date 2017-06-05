using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerQ2
{
    class Autobot : Transformer
    {
        public Autobot(int strength, int intelligence, int speed, int endurance, int rank, int courage, int firepower, int skill, string name, char code) 
            : base(strength, intelligence, speed, endurance, rank, courage, firepower, skill, name, code)
        {
                
        }
    }
}
