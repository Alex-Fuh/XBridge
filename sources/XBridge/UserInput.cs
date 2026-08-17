namespace XBridge;

public class UserInput
{

    public static String ReadLine()
    {
        var input = "";
        while (true)
        {
            Console.Write("> ");
            input = Console.ReadLine();
            if (input == "") break;
        }
        return input;
    }
    
}