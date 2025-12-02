using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            int pointingStart = pointingto;
            int pointingEnd = pointingto - turnSteps;
            int zerohits = 0; //Räkna nollträffar under denna rotation
            int currentZeroHit = 0; // Den första vi kan dyka på i denna metod är 0.

            // Räkna alla multiplar av 100 i intervallet
            // mellan startpos och slutpos.
            while (currentZeroHit >= pointingEnd) //Current ändras i varje loop
            {
                if (currentZeroHit < pointingStart && currentZeroHit >= pointingEnd)
                {
                    // Om pointingStart var 0, ska vi inte räkna 0 som träff.
                    if (pointingStart != 0 || currentZeroHit != 0)
                    {
                        zerohits++;
                    }
                }
                // Hoppa till nästa nollposition
                // och kolla villkor igen i nästa loop
                currentZeroHit -= 100;
            }
            // Räkna upp värdet som ska ge lösenkoden
            zeronumber = zeronumber + zerohits;
            // Nya positionen på hjulet, mha modulo
            pointingto = ((pointingto - turnSteps) % 100 + 100) % 100;

            return (pointingto, zeronumber);


            ////************************* BERÄKNAR ANTAL PASSERINGAR AV 0/99 ***********************//            
            ////Fixat så jag castar till double för pointingto på passeringar
            //double turningWheelTo = (double)pointingto - turnSteps;
            ////Avrunda åt rätt håll för negativa tal
            //int roundingCorrectNumberOfPasses = (int)Math.Floor(turningWheelTo/100.0);
            //// Om man landar på 0 efter en snurr, har Math.Floor räknat in den sista passeringen,
            //if (turningWheelTo % 100 == 0 && turningWheelTo <= 0)
            //{
            //    // Ångra den sista passeringen som Math.Floor räknade,
            //    // om vi landade på 0, för den kommer separat nedan 
            //    roundingCorrectNumberOfPasses++;
            //}

            //zeronumber = (zeronumber + Math.Abs(roundingCorrectNumberOfPasses));

            ////************************* ÖKA VÄRDET OM MAN SLUTAR PÅ 0 ***********************//            
            //pointingto = ((pointingto - turnSteps) % 100 + 100) % 100;
            //if (pointingto == 0)
            //{
            //    zeronumber++;
            //}
            //return (pointingto, zeronumber);
        }

        //Metod returnerar en tuple två ints, där första int är den nya positionen på hjulet
        //efter att ha snurrat, andra är det uppdaterade antalet gånger hjulet har pekat på noll.
        public (int, int) SpinR(int pointingto, int turnSteps, int zeronumber)
        {
            int pointingStart = pointingto; // var jag startar
            int pointingEnd = pointingto+turnSteps; //var jag hamnar

            int firstZeroClick = 100 * ((pointingStart / 100) + 1);

            int zeroHitsDuringRotation = 0;
            // Loopa genom alla 0-positioner upp till och med slutpositionen.
            for (int currentHit = firstZeroClick; currentHit <= pointingEnd; currentHit += 100)
            {
                zeroHitsDuringRotation++;
            }
            //Räkna upp värdet som ska ge lösenkoden
            zeronumber = zeronumber + zeroHitsDuringRotation;
            //Nya positionen på hjulet
            pointingto = (pointingto + turnSteps) % 100;
            return (pointingto, zeronumber);



            ////************************* BERÄKNAR ANTAL PASSERINGAR AV 0/99 ***********************//            

            ////Räkna först ut hur många ggr man passerat 0/99
            ////Tex   110/100 = 1.1 ---- 110/100 = 1 (OK!)            
            //double passingThroughZero = (pointingto + turnSteps) / 100.0;
            ////Avrunda neråt till närmsta heltal
            //int roundingCorrectNumberOfPasses = (int)Math.Floor(passingThroughZero);

            //// Om summan är jämnt delbar med 100, har vi landat på 0.
            //// I det fallet har Math.Floor räknat IN den sista passeringen, men den ska
            //// räknas av den separata 'if (pointingto == 0)'
            //// så då behöver vi skippa att räkna nollan den sista gången.
            //if ((pointingto + turnSteps) % 100 == 0 && pointingto + turnSteps > 0)
            //{
            //    // Räkna bort en passering om man stannat på 0
            //    roundingCorrectNumberOfPasses--;
            //}

            ////Räkna upp värdet med antalet passeringar
            ////över 0/99 som vi räknat fram ovan
            //zeronumber = zeronumber + (int)roundingCorrectNumberOfPasses;

            ////************************* ÖKA VÄRDET OM MAN SLUTAR PÅ 0 ***********************//            
            ////Var stannar hjulet efter snurren
            //pointingto = (pointingto + turnSteps) % 100;
            ////Använder % 100 på slutet för att snurra "runt" på hjulet

            //if (pointingto == 0) //Om vi landar på 0, lägg till en extra passering            
            //{
            //    zeronumber++;
            //}




        }


    }
}
