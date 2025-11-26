namespace Domain;

class CommandClean : BaseCommand, ICommand
{
public CommandClean()
{
    description = "Clean the coral reef using a brush";
}

public string Execute(Context context, string command, string[] parameters)
{
    
    var wanted = parameters[0];
    var inventory = Player.inventory;

    if (ToolRegistry.IsTrash(wanted) && !inventory.HasType(ToolType.Brush))
    {
        return "You need a brush to clean the corals!";
    }


    var items = context.GetCurrent().items;
    
    context.GetCurrent().RemoveItem("Algae covered corals");
    Space current = context.GetCurrent();
    Game.trashManager.CollectTrash(current.GetName());

    if (!context.GetCurrent().HasTrash())
    {
        return "You may now move on to the quiz!";
    }

    return "Not Empty";


}
}
