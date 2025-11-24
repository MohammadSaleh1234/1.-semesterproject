namespace Domain {

public class CommandTake : BaseCommand, ICommand {
    public CommandTake() {
        description = "Pick up a tool and add it to your inventory";
    }

    public string Execute(Context context, string command, string[] parameters) {
        if (parameters.Length != 1) {
            return "Take what?";
        }
        string toolName = parameters[0];
        Tool newTool = new Tool(toolName);
        Game.inventory.AddTool(newTool);

        return $"You picked up: {toolName}";
    }
}
}
