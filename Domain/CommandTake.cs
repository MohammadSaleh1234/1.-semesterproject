using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Domain
{

    public class CommandTake : BaseCommand, ICommand
    {
        // De eneste tilladte værktøjer
        private static readonly HashSet<string> allowedTools = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Sack", "Scissors", "Wastecollector",
            "Trashbag", "Plastic", "Plasticbottle", "Brush" // tilføj hvis du vil
        };

        public CommandTake()
        {
            description = "Pick up a specific tool (trashbag, brush, scissors)";
        }

        public string Execute(Context context, string command, string[] parameters)
        {
            if (GuardEq(parameters, 1))
            {
                return "Take what";
            }

            var wanted = parameters[0];
            var space = context.CurrentSpace;
            var inventory = Player.inventory;

            // (valgfri whitelist – kan fjernes hvis I kun vil styre via rummet)
            if (!allowedTools.Contains(wanted))
            {
                return "You cannot take" + wanted;
            }

            // Trash kræver affaldssæk
            if (ToolRegistry.IsTrash(wanted) && !inventory.HasType(ToolType.Bag))
            {
                return "You need a trashbag to collect waste!";
            }

            // Tingen SKAL ligge i rummet (case-insensitivt i Space.TryTakeItem)
            if (!space.TryTakeItem(wanted, out var actualName))
            {
                return "You cant seem to find '" + wanted + " here.";
            }

            // Lav Tool-objektet med korrekt type
            var newTool = ToolRegistry.CreateTool(actualName);

            if (newTool.Type == ToolType.Trash)
            {



                Space current = context.GetCurrent();
                Game.trashManager.CollectTrash(current.GetName());

                if (string.Equals(actualName, "plastic", StringComparison.OrdinalIgnoreCase))
                {
                    Random rng = new Random();
                    int chance = rng.Next(1, 101);

                    if (chance <= 20)
                    {
                        space.AddItem("plastic", 1);
                        return "🌊 A bird steals a piece of your trash and throws it back on the beach";
                    }
                }

                // Efter skraldet er fjernet → tjek om der er mere tilbage i rummet
                if (!space.HasTrash())
                {
                    return "✨You picked up all the waste in the area! You may now move on to the quiz. Type 'go quiz' to continue. ✨";
                }
            }
            else
            {
                inventory.AddTool(newTool);
            }

            return "sucess";
        }
    }
}    
