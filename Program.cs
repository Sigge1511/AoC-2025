
public class AoC2025 
{
    public static void Main()
    {
        int pointingto = 50;
        int turnSteps = 0;
        int zeronumber = 0;

        var wheelTurner = new AoC_2025.TurnTheWheel();

        string turnInstruction = "L5";
        string direction = turnInstruction[0].ToString();

        switch (direction)
        {
            case "L":
                (pointingto, zeronumber) = wheelTurner.SpinL(pointingto, turnSteps, zeronumber);
                break;
            case "R":
                (pointingto, zeronumber) = wheelTurner.SpinR(pointingto, turnSteps, zeronumber);
                break;
            default:
                Console.WriteLine("Invalid direction");
                break;
        }


        Console.WriteLine($"The new password is: {zeronumber}, since the value 0 appeared {zeronumber} times. \nGood luck!");
    }
}