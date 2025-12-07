/* Command for transitioning between spaces
 */

class CommandGo : BaseCommand, ICommand {
  public CommandGo () {
    description = "Follow an exit";
  }

  public void Execute (Context context, string command, string[] parameters) {
    if (GuardEq(parameters, 1)) {
      Console.WriteLine("I don't seem to know where that is 🤔");
      return;
    }
    

    // Hvis der stadig ligger skrald i rummet, må spilleren ikke gå videre
    if (context.GetCurrent().HasTrash()) {
      Console.WriteLine("You cannot leave the area until you have picked up all the trash.");
      return;
    }

    // Ellers må man godt gå
    context.Transition(parameters[0]);
  }
}
