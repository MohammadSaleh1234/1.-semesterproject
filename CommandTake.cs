using System;
using System.Collections.Generic;

class CommandTake : BaseCommand, ICommand
{
    // De eneste tilladte værktøjer
    private static readonly HashSet<string> allowedTools = new HashSet<string> {
        "sæk", "saks", "affaldsopsamler"
    };

    public CommandTake() {
        description = "Pick up a specific tool (sæk, saks, affaldsopsamler)";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (GuardEq(parameters, 1)) // Bruger GuardEq fra BaseCommand
        {
            Console.WriteLine("Take what?");
            return;
        }

        string toolName = parameters[0].ToLower();

        // Tjekker om værktøjet er tilladt
        if (!allowedTools.Contains(toolName))
        {
            Console.WriteLine($"You cannot take '{toolName}'. Only sæk, saks, or affaldsopsamler are allowed.");
            return;
        }

        // Tjekker om spilleren allerede har værktøjet (Inventory-klassen håndterer allerede dette)
        Tool newTool = new Tool(toolName);
        Game.inventory.AddTool(newTool);
    }
}
