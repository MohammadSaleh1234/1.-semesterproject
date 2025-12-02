namespace Domain;

public class CommandActivate : BaseCommand, ICommand
{
    public CommandActivate()
    {
        description = "activates the siren on your boat";
    }

    public string Execute (Context context, string command, string[] parameters)
    {
        
        return "You successfully scare away the fishermen, but they left behind their fishing nets. You need to cut them down.";
        

    }
    
}
