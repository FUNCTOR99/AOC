using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2015
{
    public class AOC2020Day16Part1 : AOCProblem
    {
        public AOC2020Day16Part1(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<ITicketParameter> parameters = new List<ITicketParameter>();
            List<string> myTicket = new List<string>();
            List<List<string>> nearbyTickets = new List<List<string>>();

            bool parameterZone = true;
            bool myTicketZone = false;
            bool nearbyTicketZone = false;

            foreach (String line in input)
            {
                if (line.Trim().Length == 0)
                {
                    if (parameterZone)
                    {
                        parameterZone = false;
                        myTicketZone = true;
                    }
                    else if (myTicketZone)
                    {
                        myTicketZone = false;
                        nearbyTicketZone = true;
                    }
                }

                if (parameterZone)
                {
                    parameters.Add(Factory.CreateTicketParameter(line));
                }
                else if (myTicketZone)
                {
                    if (line.Equals("your ticket:") == false)
                    {
                        myTicket = line.Split(',').ToList<string>();
                    }
                }
                else if (nearbyTicketZone)
                {
                    if (line.Equals("nearby tickets:") == false)
                    {
                        if (line.Trim().Length > 0)
                            nearbyTickets.Add( line.Split(',').ToList<string>());
                    }
                }               
            }

            int invalidSum = 0;
            int invalidCount = 0;

            foreach (List<string> ticket in nearbyTickets)
            {
                foreach (string value in ticket)
                {
                    bool valid = false;

                    foreach (ITicketParameter param in parameters)
                    {
                        if (param.IsValid(Convert.ToInt32(value)))
                        {
                            valid = true;
                            break;
                        }
                    }

                    if (valid == false)
                    {
                        invalidSum = invalidSum + Convert.ToInt32(value);
                        invalidCount++;
                    }
                }
            }

            return $"Result { invalidSum }, Invalid Tix: {invalidCount}.";            
        }
    }
}
