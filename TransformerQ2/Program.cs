using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransformerQ2
{
    class Program
    {
        // the flag to destroy the whole universal is false
        static bool flag = false;
        static string OptimusPrime = "Optimus Prime";
        static string Predaking = "Predaking";

        static void Main(string[] args)
        {
            Transformer t1 = new Decepticon(8, 9, 2, 6, 7, 5, 6, 10, "Soundwave", 'D');
            Transformer t2 = new Autobot(6, 6, 7, 9, 5, 2, 9, 7, "Bluestreak", 'A');
            Transformer t3 = new Autobot(4, 4, 4, 4, 4, 4, 4, 4, "Hubcap", 'A');

            Battle(new Transformer[] { t1, t2, t3 });
        }

        /// <summary>
        /// This is a function to start the battle
        /// </summary>
        /// <param name="transformers">the array of transformers going to battle</param>
        static void Battle(Transformer[] transformers)
        {
            ArrayList autobots = new ArrayList();
            ArrayList deceptions = new ArrayList();

            foreach (var t in transformers)
            {
                if(t.Code == 'D')
                {
                    deceptions.Add((Decepticon)t);
                } 

                if(t.Code == 'A')
                {
                    autobots.Add((Autobot)t);
                }
            }

            // sort each team
            autobots.Sort();
            deceptions.Sort();

            // initialize the recrod
            Record Arecord = new Record(0, 0);
            Record Drecord = new Record(1, 0);
            int length = autobots.Count < deceptions.Count ? autobots.Count : deceptions.Count;

            // face off each other
            int i = 0;
            for (; i < length; i++)
            {
                if(((Autobot)autobots[i]).Name.Equals(OptimusPrime) && ((Decepticon)deceptions[i]).Name.Equals(Predaking))
                {
                    flag = true;  // the end of the world
                } else
                {
                    compete((Autobot)autobots[i], (Decepticon)deceptions[i], Arecord, Drecord);
                }
            }

            // if there are more autobots than deceptions
            if(i < autobots.Count && !flag)
            {
                for(; i < autobots.Count; i++)
                {
                    Arecord.Survivor.Add(autobots[i]);
                }
            }

            // if there are more deceptions than autobots
            if(i < deceptions.Count && !flag)
            {
                for (; i < deceptions.Count; i++)
                {
                    Drecord.Survivor.Add(deceptions[i]);
                }
            }

            // conclusion
            if(flag)
            {
                Console.WriteLine("the end of the world!");
            }

            string outputBattle = length > 1 ? "battles" : "battle";

            // autobot won
            if (Arecord.NumOfDestroiedEnemies > Drecord.NumOfDestroiedEnemies && !flag)
            {
               
                Console.WriteLine(length + " " + outputBattle);
                Console.Write("Winning team(Autobots): ");
                foreach(var s in Arecord.Survivor)
                {
                    Console.Write(((Autobot)s).Name + " ");
                }
                Console.WriteLine();
                Console.Write("Survivors from the losing team (Deceptions): ");
                foreach (var s in Drecord.Survivor)
                {
                    Console.Write(((Decepticon)s).Name + " ");
                }
                Console.WriteLine();
            }

            // deception won
            if (Drecord.NumOfDestroiedEnemies > Arecord.NumOfDestroiedEnemies && !flag)
            {
               
                Console.WriteLine(length + " " + outputBattle);
                Console.Write("Winning team(Deceptions): ");
                foreach (var s in Drecord.Survivor)
                {
                    Console.Write(((Decepticon)s).Name + " ");
                }
                Console.WriteLine();
                Console.Write("Survivors from the losing team (Autobots): ");
                foreach (var s in Arecord.Survivor)
                {
                    Console.Write(((Autobot)s).Name + " ");
                }
                Console.WriteLine();
            }

            // tie
            if (Drecord.NumOfDestroiedEnemies == Arecord.NumOfDestroiedEnemies && !flag)
            {

                Console.WriteLine(length + " " + outputBattle);
                Console.WriteLine("No winning team, it is a tie ");
                Console.Write("Survivors from the team (Deceptions): ");
                foreach (var s in Drecord.Survivor)
                {
                    Console.Write(((Decepticon)s).Name + " ");
                }
                Console.WriteLine();
                Console.Write("Survivors from the team (Autobots): ");
                foreach (var s in Arecord.Survivor)
                {
                    Console.Write(((Autobot)s).Name + " ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// This is a function to let transformers fight and record the results
        /// </summary>
        /// <param name="autobot">autobot</param>
        /// <param name="deception">deception</param>
        /// <param name="rA">record for aubobot</param>
        /// <param name="rD">record for deception</param>
        static void compete(Autobot autobot, Decepticon deception, Record rA, Record rD)
        {
            if(autobot.Name.Equals(OptimusPrime) && !deception.Name.Equals(Predaking))
            {
                rA.NumOfDestroiedEnemies++;
                rA.Survivor.Add(autobot);
            } else if(!autobot.Name.Equals(OptimusPrime) && deception.Name.Equals(Predaking))
            {
                rD.NumOfDestroiedEnemies++;
                rD.Survivor.Add(deception);
            } else if(autobot.Courage - deception.Courage >= 4 && autobot.Strength - deception.Strength >=3)
            {
                rA.NumOfDestroiedEnemies++;
                rA.Survivor.Add(autobot);
            } else if(deception.Courage - autobot.Courage >= 4 && deception.Strength - autobot.Strength >= 3)
            {
                rD.NumOfDestroiedEnemies++;
                rD.Survivor.Add(deception);
            } else if(autobot.Skill - deception.Skill >= 3)
            {
                rA.NumOfDestroiedEnemies++;
                rA.Survivor.Add(autobot);
            } else if(deception.Skill - autobot.Skill >= 3)
            {
                rD.NumOfDestroiedEnemies++;
                rD.Survivor.Add(deception);
            } else if(autobot.getOverallRating() > deception.getOverallRating())
            {
                rA.NumOfDestroiedEnemies++;
                rA.Survivor.Add(autobot);
            } else if(deception.getOverallRating() > autobot.getOverallRating())
            {
                rD.NumOfDestroiedEnemies++;
                rD.Survivor.Add(deception);
            } else
            {
                // then it is a tie
                rA.NumOfDestroiedEnemies++;
                rD.NumOfDestroiedEnemies++;
            }
        }
       
    }
}
 