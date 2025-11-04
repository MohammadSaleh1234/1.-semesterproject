class CommandTake : BaseCommand, ICommand {
    public CommandTake() {
        description = "Pick up a tool and add it to your inventory";
    }

    public void Execute(Context context, string command, string[] parameters) {
        if (parameters.Length != 1) {
            Console.WriteLine("Take what?");
            return;
        }

        string toolName = parameters[0];
        Tool newTool = new Tool(toolName);
        Game.inventory.AddTool(newTool);
    }
}
