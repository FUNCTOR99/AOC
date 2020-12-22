using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day22Part2 : AOCProblem
    {

        public AOC2020Day22Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

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

            int winningPlayer = CombatRound(ref player1, ref player2);

            int[] winner;

            if (winningPlayer == 1)
            {
                winner = player1.ToArray();
            }
            else
            {
                winner = player2.ToArray();
            }


            for (int i = 1; i <= winner.Length; i++)
            {
                result = result + (i * winner[winner.Length - i]);
            }

            return $"Result { result }.";
        }

        private int CombatRound(ref Queue<int> player1, ref Queue<int> player2)
        {
            List<string> previousConfigs = new List<string>();

            while ((player1.Count != 0) && (player2.Count != 0))
            {
                string currentConfig = CombatRoundToString(player1, player2);

                if (previousConfigs.Contains(currentConfig))
                {
                    return 1;
                }
                else
                {
                    previousConfigs.Add(currentConfig);

                    int player1Card = player1.Dequeue();
                    int player2Card = player2.Dequeue();
                    int winner = 0;

                    if ((player1.Count() >= player1Card) && (player2.Count() >= player2Card))
                    {
                        Queue<int> newPlayer1 = new Queue<int>();
                        Queue<int> newPlayer2 = new Queue<int>();

                        int[] player1Cards = player1.ToArray();
                        int[] player2Cards = player2.ToArray();

                        for (int i = 0; i < player1Card; i++)
                        {
                            newPlayer1.Enqueue(player1.ToArray()[i]);
                        }

                        for (int j = 0; j < player2Card; j++)
                        {
                            newPlayer2.Enqueue(player2.ToArray()[j]);
                        }

                        winner = CombatRound(ref newPlayer1, ref newPlayer2);
                    }
                    else
                    {
                        if (player1Card > player2Card)
                        {
                            winner = 1;
                        }
                        else if (player2Card > player1Card)
                        {
                            winner = 2;
                        }
                    }

                    if (winner == 1)
                    {
                        player1.Enqueue(player1Card);
                        player1.Enqueue(player2Card);
                    }
                    else
                    {
                        player2.Enqueue(player2Card);
                        player2.Enqueue(player1Card);
                    }
                }
            }

            if (player1.Count > 0)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private string CombatRoundToString(Queue<int> player1, Queue<int> player2)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("player1:");
            foreach (int card in player1)
            {
                sb.Append(card);
                sb.Append(",");
            }

            sb.Append(" ");

            sb.Append("player2:");
            foreach (int card in player2)
            {
                sb.Append(card);
                sb.Append(",");
            }

            return sb.ToString();
        }
    }
}
