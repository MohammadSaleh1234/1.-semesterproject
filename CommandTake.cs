using System;
using System.Collections.Generic;

class CommandTake : BaseCommand, ICommand
{
    // De eneste tilladte værktøjer
    private static readonly HashSet<string> allowedTools = new HashSet<string> (StringComparer.OrdinalIgnoreCase) {
        "sæk", "saks", "affaldsopsamler",
        "Affaldssæk", "Plastik", "Plastikflaske", "Børste" // tilføj hvis du vil
    };

    public CommandTake() {
        description = "Pick up a specific tool (sæk, saks, affaldsopsamler)";
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
        var inventory = context.Inventory;

        // (valgfri whitelist – kan fjernes hvis I kun vil styre via rummet)
        if (!allowedTools.Contains(wanted)) {
             Console.WriteLine($"You cannot take '{wanted}'.");
             return;
         }

        // Trash kræver affaldssæk
        if (ToolRegistry.IsTrash(wanted) && !inventory.HasType(ToolType.Bag))
        {
            Console.WriteLine("Du har brug for en affaldssæk for at samle skrald.");
            return;
        }

        // Tingen SKAL ligge i rummet (case-insensitivt i Space.TryTakeItem)
        if (!space.TryTakeItem(wanted, out var actualName))
        {
            Console.WriteLine($"Du kan ikke se '{wanted}' her.");
            return;
        }

        // Lav Tool-objektet med korrekt type
        var newTool = ToolRegistry.CreateTool(actualName);

        if (newTool.Type == ToolType.Trash)
        {
            Console.WriteLine($"Du samler {actualName} op og smider det i affaldssækken.");

            // Efter skraldet er fjernet → tjek om der er mere tilbage i rummet
            if (!space.HasTrash())
            {
                Console.WriteLine("✨ Du har samlet alt skrald op i området! Du kan nu gå videre. ✨");
            }
        }
        else
        {
            inventory.AddTool(newTool);
            Console.WriteLine($"You take {newTool.GetName()}.");
        }
    }
}
