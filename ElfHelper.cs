using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2025
{
    internal class ElfHelper
    {
        public long FindPassword(List<RangeOfNumbers> numberRangeList, long password)
        {
            password = 0;
            foreach (RangeOfNumbers range in numberRangeList)
            {
                for (long numberChecked = range.Start; numberChecked <= range.End; numberChecked++)
                {
                    if (IsInvalidId(numberChecked))
                    {
                        password = password+numberChecked;
                    }
                }
            }
            return password;
        }


        public static bool IsInvalidId(long number)
        {
            // Gör till sträng för att enkelt kunna dela på halva
            string stringNumber = number.ToString();
            int numberLength = stringNumber.Length;

            if (numberLength % 2 != 0)
            {
                return false;
            }

            // Dela upp strängen
            int halfLength = numberLength / 2;

            // Första halvan börjar vid index 0, längd halfLength.
            string firstHalf = stringNumber.Substring(0, halfLength);

            // Andra halvan börjar vid halfLength
            string secondHalf = stringNumber.Substring(halfLength, halfLength);
                       
            // Om de är identiska (X = X), är ID:t ogiltigt.
            return firstHalf == secondHalf;
        }


    }
}
