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
            pointingto = ((pointingto - turnSteps) % 100 + 100) % 100;
            // Blir tex: ((1 - 3) % 100 + 100) % 100
            //             = (-2 % 100 + 100) % 100
            //             = (-2 + 100) % 100
            //             = 98 % 100 = 98

            if (pointingto == 0)
            {
                zeronumber++;
            }
            return (pointingto, zeronumber);
        }

        //Metod returnerar en tuple två ints, där första int är den nya positionen på hjulet
        //efter att ha snurrat, andra är det uppdaterade antalet gånger hjulet har pekat på noll.
        public (int, int) SpinR(int pointingto, int turnSteps, int zeronumber)
        {
            pointingto = (pointingto + turnSteps) % 100;
            //Använder % 100 på slutet för att snurra "runt" på hjulet

            if (pointingto == 0)
            {
                zeronumber++;
            }
            return (pointingto, zeronumber);
        }

        //public int AddToZeroNumber(int zeronumber)
        //{
        //    return zeronumber = (zeronumber+1);
        //}



    }
}
