using System;

class CommandCut : BaseCommand, ICommand
{
    public CommandCut()
    {
        description = "cut down fishing net.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {

        if (GuardEq(parameters, 1))
        {
            Console.WriteLine("Type 'cut net' to cut down fishing net.");
            return;
        }

        var wanted = parameters[0];
        var inventory = Player.inventory;

        if (ToolRegistry.IsTrash(wanted) && !inventory.HasType(ToolType.Scissors))
        {
            Console.WriteLine("You need scissors to cut the nets!");
            return;
        }


        var items = context.GetCurrent().items;

        if (!wanted.Equals("net") || !items.ContainsKey("fishing net")) {

            Console.WriteLine($"You couldn't seem to find '{wanted}'.");
            return;

        }

        context.GetCurrent().RemoveItem("fishing net");
        Console.WriteLine();
        Space current = context.GetCurrent();
        Game.trashManager.CollectTrash(current.GetName());

        if (!context.GetCurrent().HasTrash())
        {
            Console.WriteLine("✨You cut all the nets in the area! You may now move on to the quiz. Type 'go quiz' to continue. ✨");
            Console.WriteLine();
        }


    }
}
