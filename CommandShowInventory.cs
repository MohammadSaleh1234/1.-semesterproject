
// Klassen skal have et meningsfuldt navn, f.eks. CommandInventory
class CommandInventory : BaseCommand, ICommand {
    public CommandInventory() {
        description = "Show the contents of your inventory";
    }

    public void Execute(Context context, string command, string[] parameters) {
        // Tjekker for overflødige parametre, selvom det ikke er strengt nødvendigt for "inventory"
        if (parameters.Length > 0) {
            Console.WriteLine("The 'inventory' command takes no parameters.");
            return;
        }

        Game.inventory.ShowInventory();
    }
}


class CommandShowInventory : BaseCommand, ICommand {


    public CommandShowInventory () {
        description = "Follow an exit";
    }

    public void Execute (Context context, string command, string[] parameters) {
        if (parameters.Length != 1) {
            Console.WriteLine("Show what?");
            return;
        }

        if (parameters[0] != "inventory"){
            Console.WriteLine($"You typed '{parameters[0]}', did you mean 'inventory'?");
            return;
        }


        Console.WriteLine("=== Inventory ===");
        if (Game.inventory.tools.Count == 0) {
            Console.WriteLine("(empty)");
        } else {
            foreach (Tool tool in Game.inventory.tools) {
                Console.WriteLine("- " + tool.GetName());
            }
        }
    }

}

