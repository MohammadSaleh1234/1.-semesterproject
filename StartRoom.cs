public class StartRoom : Space
{


    public StartRoom(string name) : base(name) { }

    public override void Welcome()
    {
        var spaceName = GetName();
        string line = "You are now at the "+name;

        int windowWidth = Console.WindowWidth;
        int x = ((Console.WindowWidth - line.Length) / 2);
        Console.SetCursorPosition(x, Console.CursorTop);
        Console.WriteLine(line);



        var exits = edges.Keys.ToHashSet();
        Console.SetCursorPosition(x, Console.CursorTop);
        Console.WriteLine("You can continue to: ");
        foreach (var exit in exits) {
            Console.SetCursorPosition(x, Console.CursorTop);
            Console.WriteLine(" - " + exit);}
            Console.WriteLine();
    }
}
