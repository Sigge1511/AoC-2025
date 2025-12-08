using AoC_2025;
using System.Text.Json;
using System.Text.Json.Nodes;

public class AoC2025 
{
    public static void Main()
    {
        int password = 0;        
        List<string> batteryBankNumbers = new List<string>();

        string jsonAoCInfo = File.ReadAllText("C:\\Users\\msigf\\source\\repos\\AoC-2025\\IntructionsDoc.json");

        //Går igenom varje rad i json-filen
        //och lägger till värdet i listan
        foreach (JsonNode batteryBank in JsonNode.Parse(jsonAoCInfo).ToString())
        {
            batteryBankNumbers.Add(batteryBank.ToString());
        }

        
        ElfHelper elfHelper = new ElfHelper();
        password = elfHelper.FindPassword(batteryBankNumbers, password);

        Console.WriteLine($"The new password is: {password}. \nGood luck!");
    }
}




//switch (currentNumberCheck)
//    {
//        case "L":

//            //Console.WriteLine("Turning Left"); Hade först info med CW för att felsöka
//            break;
//        case "R":

//            //Console.WriteLine("Turning Right");
//            break;
//        default:
//            Console.WriteLine("Invalid direction"); //Behövs inte efter felsök eg?
//            break;
//    }