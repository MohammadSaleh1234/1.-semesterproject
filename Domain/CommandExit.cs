/* Command for exiting program
 */
namespace Domain {

class CommandExit : BaseCommand, ICommand {
  public string  Execute (Context context, string command, string[] parameters) {
    return "Game exit";
  }
}
}
