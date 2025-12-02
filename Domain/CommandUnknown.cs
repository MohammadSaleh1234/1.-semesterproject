/* Fallback for when a command is not implemented
 */
namespace Domain {

public class CommandUnknown : BaseCommand, ICommand {
  public string Execute (Context context, string command, string[] parameters) {
    return "Woopsie, I don't understand '"+command+"' 😕";
  }
}
}
