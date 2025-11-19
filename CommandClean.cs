using System;

class CommandClean : BaseCommand, ICommand
{
    public CommandClean()
    {
        description = "Clean the coral reef using a brush";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        // Vi forventer ingen parametre: bare 'clean'
        if (!GuardEq(parameters, 0))
        {
            Console.WriteLine("Just type 'clean' to clean the area.");
            return;
        }

        var space = context.CurrentSpace;
        var inventory = context.Inventory;

        // Tjek at vi står i Coralrevet
        if (!string.Equals(space.GetName(), "Coralrevet", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("There is nothing special to clean here.");
            return;
        }

        // Tjek om Coralrevet allerede er rent
        if (!space.IsDirty)
        {
            Console.WriteLine("The Coral Reef is already clean.");
            return;
        }

        // Tjek at spilleren har en børste
        if (!inventory.HasType(ToolType.Brush))
        {
            Console.WriteLine("You will need a brush to clean the coral reef.");
            return;
        }

        // Selve rengøringen
        space.SetDirty(false);
        Console.WriteLine("You use the brush to clean the coral reef. The coral reef is now clean! 🌊✨");
    }
}
