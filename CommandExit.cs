/* Command for exiting program
 */

class CommandExit : BaseCommand, ICommand {

  public CommandExit() {
    description = "Exit the game";
  }

  public void Execute (Context context, string command, string[] parameters) {
    context.MakeDone();
  }
}
