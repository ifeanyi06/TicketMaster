using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketMaster.Utility
{
    public class Range
    {
        public static List<int> GetRange(string rng)
        {

            int[] intRange = new int[2];
            intRange = getIntArray(rng);
            int firstInt = intRange[0];
            int secondInt = intRange[1];

            IEnumerable<int> range = Enumerable.Range(firstInt, (secondInt - firstInt) + 1);

            return range.ToList();

        }

        private static int[] getIntArray(string range)
        {
            int[] intRange = new int[2];

            string[] stringRange = range.Split('-').ToArray();
            int count = 0;
            foreach (var str in stringRange)
            {
                int number;
                if (int.TryParse(str, out number))
                {
                    intRange[count] = number;
                    count++;
                }
                else
                {
                    return null;
                }
            }

            int firstInteger = intRange[0];
            int secondInteger = intRange[1];

            return intRange;

        }

        public static bool isValidRange(string range)
        {
            int[] intRange = new int[2];
            if (!range.Contains("-") || range.Count() < 3)
            {
                return false;
            }

            intRange = getIntArray(range);

            if (intRange == null)
            {
                return false;
            }

            int firstInteger = intRange[0];
            int secondInteger = intRange[1];
            if (firstInteger > secondInteger)
            {
                return false;
            }

            return true;
        }


    }
}
