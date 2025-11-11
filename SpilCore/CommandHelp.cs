/* Help command
 */
namespace Spil {

class CommandHelp : BaseCommand, ICommand {
  Registry registry;
  
  public CommandHelp (Registry registry) {
    this.registry = registry;
    this.description = "Display a help message";
  }
  
  public string Execute (Context context, string command, string[] parameters) {
    string[] commandNames = registry.GetCommandNames();
    Array.Sort(commandNames);
    
    // find max length of command name
    int max = 0;
    foreach (String commandName in commandNames) {
      int length = commandName.Length;
      if (length>max) max = length;
    }
    
    System.Text.StringBuilder sb = new
    System.Text.StringBuilder("Commands: ");
    foreach (string commandName in commandNames) {
      string description = registry.GetCommand(commandName).GetDescription();

    sb.AppendLine(string.Format(" - {0,-"+max+"} "+description, commandName));
    }

    return sb.ToString();

  }
}
}
