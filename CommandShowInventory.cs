
class CommandShowInventory : BaseCommand, ICommand {


    public CommandShowInventory () {
        description = "Show the contents of your inventory";
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

        Console.Clear();
        context.GetCurrent().Welcome();

        Console.WriteLine("=== Inventory ===");
        if (Player.inventory.tools.Count == 0) {
            Console.WriteLine("(empty)");
        } else {
            foreach (Tool tool in Player.inventory.tools) {
                Console.WriteLine("- " + tool.GetName());
            }
        }
    }

}

