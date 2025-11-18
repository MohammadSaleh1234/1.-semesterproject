using System;

class Game {
  public static Inventory inventory = new Inventory();
  public static TrashManager trashManager = new TrashManager();
  static World world = new World();
  static Context context = new Context(world.GetEntry());
  static ICommand fallback = new CommandUnknown();
  static Registry registry = new Registry(context, fallback);
  public static Player player = new Player(context, registry);



  private static void InitRegistry() {



    ICommand cmdExit = new CommandExit();
    registry.Register("exit", cmdExit);
    registry.Register("go", new CommandGo());
    registry.Register("help", new CommandHelp(registry));
    registry.Register("take", new CommandTake());
    registry.Register("show", new CommandShowInventory());
    registry.Register("activate", new CommandActivate());
    registry.Register("cut", new CommandCut());
    registry.Register("collect", new CommandCollect());
    registry.Register("clean", new CommandClean());

  }

  static void Main(string[] args) {
    Console.WriteLine("Welcome to The Ocean Code!");

    InitRegistry();
    context.GetCurrent().Welcome();

    while (context.IsDone()==false) {
      Console.Write("> ");
      string? line = Console.ReadLine().ToLower();
      if (line!=null) player.ExecuteCommand(line);
    }
    Console.WriteLine("Game Over 😥");
  }

}



