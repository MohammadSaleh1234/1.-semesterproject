/* Command for transitioning between spaces
 */

class CommandShowInventory : BaseCommand, ICommand {


    public CommandShowInventory () {
        description = "Follow an exit";
    }

    public void Execute (Context context, string command, string[] parameters) {
            if (parameters.Length != 1) {
                Console.WriteLine("Take what?");
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



