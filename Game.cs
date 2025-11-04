/* Main class for launching the game
 */

class Game {
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

  static void Main (string[] args) {
    Console.WriteLine("Welcome to the World of Zuul!");

    InitRegistry();
    context.GetCurrent().Welcome();

    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine();
      if (line!=null) player.ExecuteCommand(line);
    }
    Console.WriteLine("Game Over 😥");
  }
}
