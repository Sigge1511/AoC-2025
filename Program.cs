
using System.Text.Json;
using System.Text.Json.Nodes;

public class AoC2025 
{
    public static void Main()
    {
        //Skapar variabler för senare och instans av TurnTheWheel
        int zeroNumber = 0;
        int turnSteps = 0;
        var wheelTurner = new AoC_2025.TurnTheWheel();
        //Setup för hjulet
        int[] numbersOnWheelArray = Enumerable.Range(0, 100).ToArray();        
        int pointingTo = 50; //STARTVÄRDE - Kan också användas för visa indexplatsen i arrayen

//********************************************************************************************

        //Hämtar jag in instruktionerna från json-filen
        string jsonInfo = File.ReadAllText(@"C:\Users\msigf\source\repos\AoC-2025\IntructionsDoc.json");
        //Sparar sedan i lista av strängar mha Deserializer
        List<string> instructionsFromAoC = JsonSerializer.Deserialize<List<string>>(jsonInfo);

        //Loopar igenom varje rad med instruktioner i listan
        foreach (var turnInstruction in instructionsFromAoC)
        {
            string direction = turnInstruction[0].ToString(); //tar ut tex 'L' eller 'R'
            //Hämtar ut siffer-delen av strängen efter den första bokstaven
            string numberStringFromInstruction = turnInstruction.Length > 1 ? turnInstruction.Substring(1).Trim() : "";
            //Konvertera siffer-strängen till int
            turnSteps = int.Parse(numberStringFromInstruction);

            //Mha switch-case bestämmer jag åt vilket håll
            //hjulet ska snurra och skickar in värden
            switch (direction)
            {
                case "L":
                    //Console.WriteLine("Turning Left"); Hade först info med CW för att felsöka
                    (pointingTo, zeroNumber) = wheelTurner.SpinL(pointingTo, turnSteps, zeroNumber);
                    break;
                case "R":
                    //Console.WriteLine("Turning Right");
                    (pointingTo, zeroNumber) = wheelTurner.SpinR(pointingTo, turnSteps, zeroNumber);
                    break;
                default:
                    Console.WriteLine("Invalid direction"); //Behövs inte efter felsök eg?
                    break;
            }
        }



        //Loopen slut och nu kan vi printa svaret

        Console.WriteLine($"The new password is: {zeroNumber}, since the value 0 appeared {zeroNumber} times. \nGood luck!");
    }
}