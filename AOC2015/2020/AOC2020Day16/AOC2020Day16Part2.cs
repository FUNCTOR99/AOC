using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOC2015
{
    public class AOC2020Day16Part2 : AOCProblem
    {

        public AOC2020Day16Part2(String[] input, IStandardMessages standardMessages) : base(input, standardMessages) { }

        protected override String DoSolve(String[] input)
        {
            List<ITicketParameter> parameters = new List<ITicketParameter>();
            List<string> myTicket = new List<string>();
            List<List<string>> nearbyTickets = new List<List<string>>();

            bool parameterZone = true;
            bool myTicketZone = false;
            bool nearbyTicketZone = false;

            //load the input
            foreach (String line in input)
            {
                //check which zone we are in in the input file
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
                            nearbyTickets.Add(line.Split(',').ToList<string>());
                    }
                }

            }

            //find all the valid tickets.
            List<List<string>> validTickets = new List<List<string>>();

            foreach (List<string> ticket in nearbyTickets)
            {
                bool ticketValid = true;

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
                        ticketValid = false;
                    }
                }

                if (ticketValid)
                {
                    validTickets.Add(ticket);
                }
            }

            //map parameters to value columns
            Dictionary<string, int> parameterMap = new Dictionary<string, int>();

            //cycle through looking for parameters that match only one column.  Stop once all the parameters are mapped.
            while (parameterMap.Count() != parameters.Count())
            {
                foreach (ITicketParameter param in parameters)
                {
                    int currentIndex = 0;
                    bool paramValid = false;
                    List<int> validMappings = new List<int>();

                    while (currentIndex < validTickets[0].Count())
                    {
                        //check to see if this column has already been mapped to another parameter
                        if (parameterMap.ContainsValue(currentIndex) == false)
                        {
                            paramValid = true;

                            foreach (List<string> ticket in validTickets)
                            {
                                if (param.IsValid(Convert.ToInt32(ticket[currentIndex])) == false)
                                {
                                    paramValid = false;
                                    break;
                                }
                            }

                            if (paramValid)
                            {
                                validMappings.Add(currentIndex);
                                paramValid = true;
                            }
                        }

                        currentIndex++;
                    }

                    //only map the column to the parameter if there is only one valid remaining column for this parameter
                    if (validMappings.Count() == 1) 
                    {
                        parameterMap.Add(param.Name, validMappings[0]);
                    }
                }
            }

            long product = 1;

            //check myticket
            foreach (ITicketParameter param in parameters.Where(x => x.Name.Contains("departure")))
            {
                product = product * Convert.ToInt64(myTicket[parameterMap[param.Name]]);
            }


            return $"Result { product }.";

        }

    }
}
