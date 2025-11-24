using System;
using System.Collections.Generic;

class CommandTake : BaseCommand, ICommand
{
    // De eneste tilladte værktøjer
    private static readonly HashSet<string> allowedTools = new HashSet<string> (StringComparer.OrdinalIgnoreCase) {
        "Sack", "Scissors", "Wastecollector",
        "Trashbag", "Plastic", "Plasticbottle", "Brush" // tilføj hvis du vil
    };

    public CommandTake() {
        description = "Pick up a specific tool (sack, scissors, wastecollector)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 1))
        {
            Console.WriteLine("Take what?");
            return;
        }

        var wanted = parameters[0];
        var space = context.CurrentSpace;
        var inventory = Player.inventory;

        // (valgfri whitelist – kan fjernes hvis I kun vil styre via rummet)
        if (!allowedTools.Contains(wanted)) {
             Console.WriteLine($"You cannot take '{wanted}'.");
             return;
         }

        // Trash kræver affaldssæk
        if (ToolRegistry.IsTrash(wanted) && !inventory.HasType(ToolType.Bag))
        {
            Console.WriteLine("You need a trashbag to collect waste!");
            return;
        }

        // Tingen SKAL ligge i rummet (case-insensitivt i Space.TryTakeItem)
        if (!space.TryTakeItem(wanted, out var actualName))
        {
            Console.WriteLine($"You cant seem to find '{wanted}' here.");
            return;
        }

        // Lav Tool-objektet med korrekt type
        var newTool = ToolRegistry.CreateTool(actualName);

        if (newTool.Type == ToolType.Trash)
        {



            Space current = context.GetCurrent();
            Game.trashManager.CollectTrash(current.GetName());
            // Efter skraldet er fjernet → tjek om der er mere tilbage i rummet
            if (!space.HasTrash())
            {
                Console.WriteLine("✨You picked up all the waste in the area! You may now move on to the quiz. Type 'go quiz' to continue. ✨");
                Console.WriteLine();
            }
        }
        else
        {
            inventory.AddTool(newTool);
        }
    }
}
