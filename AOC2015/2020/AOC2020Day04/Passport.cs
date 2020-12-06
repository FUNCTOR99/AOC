using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2015
{
    public class Passport
    {
        public String BYR { get; set; }
        public String IYR { get; set; }
        public String EYR { get; set; }
        public String HGT { get; set; }
        public String HCL { get; set; }
        public String ECL { get; set; }
        public String PID { get; set; }
        public String CID { get; set; }

        public bool IsValid { get; set; }
        public bool IsStrictValid { get; set; }

        public Passport(String[] inputLines)
        {
            ParseInput(inputLines);
        }

        private void ParseInput(String[] inputLines)
        {
            foreach (string line in inputLines)
            {
                string[] elements = line.Split(' ');
                foreach (string element in elements)
                {
                    string parameter = StringOps.SubStringPre(element, ":");
                    string value = StringOps.SubStringPost(element, ":");

                    switch (parameter)
                    {
                        case "byr":
                            BYR = value;
                            break;

                        case "iyr":
                            IYR = value;
                            break;

                        case "eyr":
                            EYR = value;
                            break;

                        case "hgt":
                            HGT = value;
                            break;

                        case "hcl":
                            HCL = value;
                            break;

                        case "ecl":
                            ECL = value;
                            break;

                        case "pid":
                            PID = value;
                            break;

                        case "cid":
                            CID = value;
                            break;

                        default:
                            throw new Exception($"Parameter is {parameter}, Value is {value}.");
                    }
                }
            }

            IsValid = CheckIsValid();
            IsStrictValid = CheckIsStrictValid();
        }

        public bool CheckIsValid()
        {
            //bool result = true;

            if ((BYR == null) || (BYR.Equals("")))
                return false;

            if ((IYR == null) || (IYR.Equals("")))
                return false;

            if ((EYR == null) || (EYR.Equals("")))
                return false;

            if ((HGT == null) || (HGT.Equals("")))
                return false;

            if ((HCL == null) || (HCL.Equals("")))
                return false;

            if ((ECL == null) || (ECL.Equals("")))
                return false;

            if ((PID == null) || (PID.Equals("")))
                return false;

            //if ((CID == null) || (CID.Equals("")))
            //    return false;
            return true;
        }

        public bool CheckIsStrictValid()
        {
            //bool result = true;

            if ((BYR == null) || (BYR.Equals("")))                 
                return false;
            else
            {
                try
                {
                    if (BYR.Length != 4)
                        return false;

                    if (Convert.ToInt32(BYR) < 1920)
                        return false;

                    if (Convert.ToInt32(BYR) > 2002)
                        return false;
                }
                catch {   return false;  }
            }

            if ((IYR == null) || (IYR.Equals("")))
                return false;
            else
            {
                try
                {
                    if (IYR.Length != 4)
                        return false;

                    if (Convert.ToInt32(IYR) < 2010)
                        return false;

                    if (Convert.ToInt32(IYR) > 2020)
                        return false;
                }
                catch { return false; }
            }

            if ((EYR == null) || (EYR.Equals("")))
                return false;
            else
            {
                try
                {
                    if (EYR.Length != 4)
                        return false;

                    if (Convert.ToInt32(EYR) < 2020)
                        return false;

                    if (Convert.ToInt32(EYR) > 2030)
                        return false;
                }
                catch { return false; }
            }


            if ((HGT == null) || (HGT.Equals("")))
                return false;
            else
            {
                try
                {
                    if (HGT.Contains("cm"))
                    {
                        int number = Convert.ToInt32(HGT.Replace("cm", "").Trim());

                        if (number < 150)
                            return false;

                        if (number > 193)
                            return false;
                    }
                    else if (HGT.Contains("in"))
                    {
                        int number = Convert.ToInt32(HGT.Replace("in", "").Trim());

                        if (number < 59)
                            return false;

                        if (number > 76)
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch { return false; }
            }

            if ((HCL == null) || (HCL.Equals("")))
                return false;
            else
            {
                try
                {
                    if (!HCL.Contains("#"))
                    {
                        return false;
                    }

                    if (HCL.Length != 7)
                    {
                        return false;
                    }

                    string working = HCL;
                    working = working.Replace("#", "");

                    foreach (char c in working)
                    {
                        if ((c != '0') &&
                            (c != '1') &&
                            (c != '2') &&
                            (c != '3') &&
                            (c != '4') &&
                            (c != '5') &&
                            (c != '6') &&
                            (c != '7') &&
                            (c != '8') &&
                            (c != '9') &&
                            (c != 'a') &&
                            (c != 'b') &&
                            (c != 'c') &&
                            (c != 'd') &&
                            (c != 'e') &&
                            (c != 'f'))
                        {
                            return false;
                        }
                    }
                }
                catch { return false; }
            }

            if ((ECL == null) || (ECL.Equals("")))
                return false;
            else
            {
                try
                {
                    if (!(ECL.Equals("amb")) &&
                        !(ECL.Equals("blu")) &&
                        !(ECL.Equals("brn")) &&
                        !(ECL.Equals("gry")) &&
                        !(ECL.Equals("grn")) &&
                        !(ECL.Equals("hzl")) &&
                        !(ECL.Equals("oth")))
                    {
                        return false;
                    }
                }
                catch { return false; }
            }

            if ((PID == null) || (PID.Equals("")))
                return false;
            else
            {
                try
                {
                    if (PID.Length != 9)
                        return false;

                    Convert.ToInt32(PID.Trim());                       

                }
                catch { return false; }
            }

            //if ((CID == null) || (CID.Equals("")))
            //    return false;
            return true;
        }


    }          
}              
               
               
               
               