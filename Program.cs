using AoC_2025;
using System.Text.Json;
using System.Text.Json.Nodes;

public class AoC2025 
{
    public static void Main()
    {
        long password = 0;        
        List<RangeOfNumbers> numberRange = new List<RangeOfNumbers>();

        string jsonAoCInfo = File.ReadAllText("C:\\Users\\msigf\\source\\repos\\AoC-2025\\IntructionsDoc.json");
        JsonArray jsonArray = JsonSerializer.Deserialize<JsonArray>(jsonAoCInfo);

        foreach (JsonNode row in jsonArray)
        {
            string rangeString = row.GetValue<string>();
            
            // Dela strängen vid bindestrecket och lägg i array
            string[] parts = rangeString.Split('-');
            long.TryParse(parts[0], out long startNumber);//Första talet på plats 0
            long.TryParse(parts[1], out long endNumber);//Andra talet på plats 1
                        
            // Lägg till det parsa intervallet i listan    
            numberRange.Add(new RangeOfNumbers    
            {
                Start = startNumber,
                End = endNumber
            });   
        }
        
        ElfHelper elfHelper = new ElfHelper();
        password = elfHelper.FindPassword(numberRange, password);

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