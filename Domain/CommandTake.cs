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
			
			if (toolName == "plastic")
			{
                if (Game.player.inventory.tools.Contains("Trashbag")) {
                    Game.context.GetCurrent().RemoveItem(toolName);
                    string line = Game.trashManager.CollectTrash("Beach");
                    return line;; 
                }
                return "fail";
			}
            Game.player.inventory.AddTool(toolName);
            return null;

        }
    }
}