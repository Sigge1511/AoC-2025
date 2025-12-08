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
        public int FindPassword(List<string> batteryBankList, int password)
        {
            password = 0;

            foreach (string batteryBank in batteryBankList)
            {
                // Hitta de två högsta unika siffrorna
                List<int> allNumbersInString = new List<int>();
                foreach (char singleDigit in batteryBank)
                {
                    if (char.IsDigit(singleDigit))
                    {
                        allNumbersInString.Add((int)char.GetNumericValue(singleDigit));
                    }
                }

                // Kolla mha LINQ efter 2 högsta siffrorna
                List<int> strongestBatteriesList = allNumbersInString
                            .OrderByDescending(n => n)
                            .Take(2)
                            .ToList();

                // Kolla ordningen på siffrorna
                string highestNumbers = "";

                foreach (char number in batteryBank)
                {
                    int currentNumberChecked = (int)char.GetNumericValue(number);

                    if (strongestBatteriesList.Remove(currentNumberChecked))
                    {
                        highestNumbers += number;
                        if (highestNumbers.Length == 2)
                        {
                            break;
                        }
                    }
                }
                // 4. Konvertera och summera
                if (int.TryParse(highestNumbers, out int twoDigitNumber))
                {
                    password = password+ twoDigitNumber;
                }

                
            }
            return password;
        }
    }
}

        //public static bool IsInvalidId(long number)
        //{
        //    //Hitta alla möjliga mönsterlängder (patternLength) som kan ha skapat talet
        //    //patternLength måste gå att dela jämt med numberLength

//    // För varje möjlig patternLength, kolla om strängen består
//    // av ett visst tal upprepat ett visst antal ggr
//    // tex 1212 eller 123123 eller 999999 
//    //
//    // Så fort ett matchande mönster hittas är talet ogiltigt och loop bryts.


//    string numberString = number.ToString();
//    int numberLength = numberString.Length; 

//    // Vi loopar genom alla möjliga mönsterlängder (patternLength), från 1 upp till halva längden (N/2).
//    // Anledningen till att vi går upp till N/2 är att repetitionsOfPattern (antal upprepningar) måste vara >= 2.
//    for (int patternLength = 1; patternLength <= numberLength / 2; patternLength++)
//    {
//        // För att ett mönster av längd patternLength ska upprepas jämnt,
//        // måste numberLength vara jämnt delbar med patternLength
//        if (numberLength % patternLength == 0)
//        {
//            // Hitta det potentiella mönstret -> pattern
//            // Mönstret är de patternLength första tecknen.
//            string pattern = numberString.Substring(0, patternLength);

//            // Räkna ut hur många gånger pattern ska upprepas 
//            int repetitionsOfPattern = numberLength / patternLength;

//            // Bygg om strängen genom att upprepa mönstret repetitionsOfPattern gånger
//            string testBuiltNumber = "";
//            for (int i = 0; i < repetitionsOfPattern; i++)
//            {
//                testBuiltNumber += pattern;
//            }

//            // Jämför med originaltalet
//            if (testBuiltNumber.Equals(numberString))
//            {
//                // Om de matchar, har vi hittat en upprepning
//                // (pattern^repetitionsOfPattern) = talet är ogiltigt
//                return true;
//            }
//        }
//    }
//    // Annars är talet giltigt och bool "IsInvalidId" är false
//    return false;
//}



