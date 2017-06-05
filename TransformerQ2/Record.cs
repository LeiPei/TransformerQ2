using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerQ2
{
    class Record
    {
        // team code: 0 is autobot, 1 is deception
        public int TeamCode { get; set; }

        public int NumOfDestroiedEnemies { get; set; }

        public ArrayList Survivor { get; set; }

        public Record(int TeamCode, int NumOfDestroiedEnemies)
        {
            this.TeamCode = TeamCode;
            this.NumOfDestroiedEnemies = NumOfDestroiedEnemies;
            Survivor = new ArrayList();
        }
    }
}
