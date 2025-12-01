using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2025
{
    internal class TurnTheWheel
    {
        //Metod returnerar en tuple två ints, där första int är den nya positionen på hjulet
        //efter att ha snurrat, andra är det uppdaterade antalet gånger hjulet har pekat på noll.
        public (int, int) SpinL(int pointingto, int turnSteps, int zeronumber)
        {
            foreach (var turns in Enumerable.Range(0, turnSteps))
            {
                pointingto--;
                if (pointingto == 100)
                {
                    pointingto = 0;
                }
                else if (pointingto == -1)
                {
                    pointingto = 99;
                }
                if (pointingto == 0)
                {
                    zeronumber = AddToZeroNumber(zeronumber);
                }

            }
            return (pointingto, zeronumber);
        }

        //Metod returnerar en tuple två ints, där första int är den nya positionen på hjulet
        //efter att ha snurrat, andra är det uppdaterade antalet gånger hjulet har pekat på noll.
        public (int, int) SpinR(int pointingto, int turnSteps, int zeronumber)
        {
            foreach (var turns in Enumerable.Range(0, turnSteps))
            {
                pointingto++;
                if (pointingto == 100)
                {
                    pointingto = 0;
                }
                else if (pointingto == -1)
                {
                    pointingto = 99;
                }
                if (pointingto == 0)
                {
                    zeronumber = AddToZeroNumber(zeronumber);
                }

            }
            return (pointingto, zeronumber);
        }

        public int AddToZeroNumber(int zeronumber)
        {
            return zeronumber++;
        }



    }
}
