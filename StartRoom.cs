public class StartRoom : Space
{


    public StartRoom(string name, string description) : base(name, description) { }

    public override void Welcome()
    { 
        string line = "Go to the beach and see what tasks the Ocean code brings you today!";

        int windowWidth = Console.WindowWidth;
        int x = ((Console.WindowWidth - line.Length) / 2);
        Console.SetCursorPosition(x, Console.CursorTop);
        Console.WriteLine(line);
        
        var exits = edges.Keys.ToHashSet();
        Console.SetCursorPosition(x, Console.CursorTop);
        Console.WriteLine("Type 'help' if you need a little assistance moving around");
        Console.SetCursorPosition(x, Console.CursorTop);
        Console.WriteLine("if you need furthur instructions on your current tasks then you can type type 'logbook', your curent exist are:");
        
        foreach (var exit in exits) {
            
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine(" - " + exit);}
            Console.WriteLine();
        }
}
