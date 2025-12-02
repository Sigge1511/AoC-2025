
public class AoC2025 
{
    public static void Main()
    {
        int pointingTo = 50;
        int turnSteps = 0;
        int zeroNumber = 0;

        var wheelTurner = new AoC_2025.TurnTheWheel();

        string turnInstruction = "L50"; //Här vill jag läsa från min json-fil senare.
        string direction = turnInstruction[0].ToString(); //tar ut tex 'L' eller 'R'
        //Hämtar ut siffer-delen av strängen efter den första bokstaven
        string numericString = turnInstruction.Length > 1 ? turnInstruction.Substring(1).Trim() : "";
                
        //Provar att konvertera siffer-strängen till en int
        if (int.TryParse(numericString, out turnSteps))
        {
            Console.WriteLine($"'{turnInstruction}' var infon från filen\n" +
                $"--> '{numericString}' var siffrorna som plockades ut\n " +
                $"--> {turnSteps} blir slutvärdet");
        }
        // Output ska likna detta:
        // '   -10FFXXX' --> '   -10' --> -10

        //turnSteps = int.Parse(numericString);

        //Lägg detta in en loop sen när jag läser från filen.
        switch (direction)
        {
            case "L":
                Console.WriteLine("Turning Left");
                (pointingTo, zeroNumber) = wheelTurner.SpinL(pointingTo, turnSteps, zeroNumber);
                break;
            case "R":
                Console.WriteLine("Turning Right");
                (pointingTo, zeroNumber) = wheelTurner.SpinR(pointingTo, turnSteps, zeroNumber);
                break;
            default:
                Console.WriteLine("Invalid direction");
                break;
        }


        Console.WriteLine($"The new password is: {zeroNumber}, since the value 0 appeared {zeroNumber} times. \nGood luck!");










    }
}