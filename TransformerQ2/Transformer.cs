using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerQ2
{
    /// <summary>
    /// This is a Transformer class with 8 properties
    /// </summary>
    class Transformer : IComparable
    {
        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Speed { get; set; }

        public int Endurance { get; set; }

        public int Rank { get; set; }

        public int Courage { get; set; }

        public int Firepower { get; set; }

        public int Skill { get; set; }

        public string Name { get; set; }

        public char Code { get; set; }

        public Transformer(int strength, int intelligence, int speed, int endurance, int rank, int courage, int firepower, int skill, string name, char code)
        {
            this.Strength = strength;
            this.Intelligence = intelligence;
            this.Speed = speed;
            this.Endurance = endurance;
            this.Rank = rank;
            this.Courage = courage;
            this.Firepower = firepower;
            this.Skill = skill;
            this.Name = name;
            this.Code = code;
        }

        public int getOverallRating()
        {
            return this.Strength + this.Intelligence + this.Speed + this.Endurance + this.Firepower;
        }

        /// <summary>
        /// Sorted by rank descending
        /// </summary>
        /// <param name="obj">the transformer to be compared</param>
        /// <returns>the result of comparison</returns>
        public int CompareTo(object obj)
        {
            Transformer t = obj as Transformer;
            if(t != null)
            {
                return t.Rank - this.Rank;
            }
            return 0;
        }
    }
}
