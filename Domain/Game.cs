/* Main class for launching the game
 */
namespace Domain {

public class Game {
  public static Inventory inventory = new Inventory();
  static World    world    = new World();
  static Context  context  = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  static Player player = new Player(context, registry);

  private static void InitRegistry () {
    ICommand cmdExit = new CommandExit();
    registry.Register("take", new CommandTake());
    registry.Register("exit", cmdExit);
    registry.Register("quit", cmdExit);
    registry.Register("bye", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("show", new CommandShowInventory());
  }


}
}
