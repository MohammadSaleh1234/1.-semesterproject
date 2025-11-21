public class StartRoom : Space
{


    public StartRoom(string name) : base(name) { }

    public override void Welcome()
    {
        var spaceName = GetName();

        Console.WriteLine("You are now at " + name);

        var exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");
        foreach (var exit in exits) Console.WriteLine(" - " + exit);
        Console.WriteLine();
    }
}
