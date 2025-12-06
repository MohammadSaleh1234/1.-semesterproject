namespace Domain
{

class CommandClean : BaseCommand, ICommand
{

public CommandClean()
{
    description = "Clean the coral reef using a brush";

}

public string Execute(Context context, string command, string[] parameters)
{
    
       if (GuardEq(parameters, 1))
                {
                    return "Type 'clean coral' to clean the coralreef.";
                }

                var wanted = parameters[0];
				if (!Game.player.inventory.tools.Contains("Brush"))
                {
					return "fail";
				}
                var items = context.GetCurrent().items;

                if (!wanted.Equals("coral") && !items.ContainsKey("coral"))
                {

                    return "You couldn't seem to find a brush in your inventory'.";

                }

                context.GetCurrent().RemoveItem("coral");
				string roomName = "Coralreef";
                string line = Game.trashManager.CollectTrash(roomName);
                return line;

}
}
}