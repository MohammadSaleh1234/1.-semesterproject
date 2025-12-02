using System;

namespace Domain
{
  public class Game
  {
    public static TrashManager trashManager = new TrashManager();
    static World world = new World();
    public static Context context = new Context(world.GetEntry());
    static ICommand fallback = new CommandUnknown();
    static Registry registry = new Registry(context, fallback);
    public static Player player = new Player(registry);

    static Game()
    {
      InitRegistry();
    }

    private static void InitRegistry()
    {
      ICommand cmdExit = new CommandExit();
      registry.Register("exit", cmdExit);
      registry.Register("go", new CommandGo());
      registry.Register("help", new CommandHelp(registry));
      registry.Register("take", new CommandTake());
      registry.Register("show", new CommandShowInventory());
      registry.Register("activate", new CommandActivate());
      registry.Register("cut", new CommandCut());
      registry.Register("clean", new CommandClean());
    }
  }
}  