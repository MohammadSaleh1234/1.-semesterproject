/* Command for transitioning between spaces
 */

namespace Domain {

public class CommandGo : BaseCommand, ICommand {
  public CommandGo () {
    description = "Follow an exit";
  }
  
  public string Execute (Context context, string command, string[] parameters) {
    if (GuardEq(parameters, 1)) {
      return "I don't seem to know where that is 🤔";
    }
    return context.Transition(parameters[0]);
  }
}
}
