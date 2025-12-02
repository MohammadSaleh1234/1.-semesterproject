namespace Domain;

public class CommandActivate : BaseCommand, ICommand
{
    public CommandActivate()
    {
        description = "activates the siren on your boat";
    }

    public string Execute (Context context, string command, string[] parameters)
    {
        var items = context.GetCurrent().items;
        string itemName = parameters[0];
        
        context.GetCurrent().items.Remove("Illegal fishing boats");
        context.GetCurrent().AddItem("Fishing net", 5);
        context.GetCurrent().AddItem("Scissors", 1);
        
        return "You successfully scare away the fishermen, but they left behind their fishing nets. You need to cut them down.";
        

    }
    
}
