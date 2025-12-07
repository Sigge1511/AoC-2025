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
            //Hitta alla möjliga mönsterlängder (patternLength) som kan ha skapat talet
            //patternLength måste gå att dela jämt med numberLength

            // För varje möjlig patternLength, kolla om strängen består
            // av ett visst tal upprepat ett visst antal ggr
            // tex 1212 eller 123123 eller 999999 
            //
            // Så fort ett matchande mönster hittas är talet ogiltigt och loop bryts.


            string numberString = number.ToString();
            int numberLength = numberString.Length; 

            // Vi loopar genom alla möjliga mönsterlängder (patternLength), från 1 upp till halva längden (N/2).
            // Anledningen till att vi går upp till N/2 är att repetitionsOfPattern (antal upprepningar) måste vara >= 2.
            for (int patternLength = 1; patternLength <= numberLength / 2; patternLength++)
            {
                // För att ett mönster av längd patternLength ska upprepas jämnt,
                // måste numberLength vara jämnt delbar med patternLength
                if (numberLength % patternLength == 0)
                {
                    // Hitta det potentiella mönstret -> pattern
                    // Mönstret är de patternLength första tecknen.
                    string pattern = numberString.Substring(0, patternLength);

                    // Räkna ut hur många gånger pattern ska upprepas 
                    int repetitionsOfPattern = numberLength / patternLength;

                    // Bygg om strängen genom att upprepa mönstret repetitionsOfPattern gånger
                    string testBuiltNumber = "";
                    for (int i = 0; i < repetitionsOfPattern; i++)
                    {
                        testBuiltNumber += pattern;
                    }

                    // Jämför med originaltalet
                    if (testBuiltNumber.Equals(numberString))
                    {
                        // Om de matchar, har vi hittat en upprepning
                        // (pattern^repetitionsOfPattern) = talet är ogiltigt
                        return true;
                    }
                }
            }
            // Annars är talet giltigt och bool "IsInvalidId" är false
            return false;
        }


    }
}
