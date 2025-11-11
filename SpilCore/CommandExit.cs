/* Command for exiting program
 */
namespace Spil {

class CommandExit : BaseCommand, ICommand {
  public string  Execute (Context context, string command, string[] parameters) {
    return "Game exit";
  }
}
}
