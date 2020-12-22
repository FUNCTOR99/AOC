using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day22Part1 : AOCProblem
    {
        public AOC2020Day22Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            long result = 0;

            Queue<int> player1 = new Queue<int>();
            Queue<int> player2 = new Queue<int>();

            bool player1input = true;

            foreach (String line in input)
            {
                if (line.Trim().Length == 0)
                {
                    player1input = false;
                }
                else
                {
                    if (player1input)
                    {
                        if (line.Contains("Player") == false)
                        {
                            player1.Enqueue(Convert.ToInt32(line));
                        }
                    }
                    else
                    {
                        if (line.Contains("Player") == false)
                        {
                            player2.Enqueue(Convert.ToInt32(line));
                        }
                    }
                }
            }

            int rounds = 0;

            while ((player1.Count != 0 ) && (player2.Count != 0))
            {
                int player1Card = player1.Dequeue();
                int player2Card = player2.Dequeue();

                if (player1Card > player2Card)
                {
                    player1.Enqueue(player1Card);
                    player1.Enqueue(player2Card);

                }
                else if (player2Card > player1Card)
                {
                    player2.Enqueue(player2Card);
                    player2.Enqueue(player1Card);
                }

                rounds++;
            }

            int[] winner;

            if (player1.Count > 0)
            {
                winner = player1.ToArray();
            }
            else
            {
                winner = player2.ToArray();
            }

            
            for (int i = 1; i<= winner.Length; i++)
            {
                result = result + (i * winner[winner.Length - i]);
            }

            return $"Result { result }.";        
        }          
    }
}
