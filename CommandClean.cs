using System;

class CommandClean : BaseCommand, ICommand
{
    public CommandClean()
    {
        description = "Clean the coral reef using a brush";
    }

    public void Execute(Context context, string command, string[] parameters)
    {

        if (GuardEq(parameters, 1))
        {
            Console.WriteLine("Type 'clean coral' to clean the area.");
            return;
        }

        var wanted = parameters[0];
        var inventory = Player.inventory;

        if (ToolRegistry.IsTrash(wanted) && !inventory.HasType(ToolType.Brush))
        {
            Console.WriteLine("You need a brush to clean corals!");
            return;
        }


        var items = context.GetCurrent().items;

        if (!wanted.Equals("coral") || !items.ContainsKey("Algae covered corals")) {

            Console.WriteLine($"You couldn't seem to find '{wanted}'.");
            return;

        }

        context.GetCurrent().RemoveItem("Algae covered corals");
        Console.WriteLine();
        Space current = context.GetCurrent();
        Game.trashManager.CollectTrash(current.GetName());

        if (!context.GetCurrent().HasTrash())
        {
            Console.WriteLine("✨You cleaned all the corals in the area! You may now move on to the quiz. Type 'go quiz' to continue. ✨");
            Console.WriteLine();
        }


    }
}
