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
    registry.Register("clean", new CommandClean());

  }

  static void Main(string[] args) {

    Console.Clear();

    string welcomeArt = @"
      _       __     __                             __           __  __            ____                                          __     __
     | |     / /__  / /________  ____ ___  ___     / /_____     / /_/ /_  ___     / __ \________  ____ _____     _________  ____/ /__  / /
    | | /| / / _ \/ / ___/ __ \/ __ `__ \/ _ \   / __/ __ \   / __/ __ \/ _ \   / / / / ___/ _ \/ __ `/ __ \   / ___/ __ \/ __  / _ \/ /
    | |/ |/ /  __/ / /__/ /_/ / / / / / /  __/  / /_/ /_/ /  / /_/ / / /  __/  / /_/ / /__/  __/ /_/ / / / /  / /__/ /_/ / /_/ /  __/_/
   |__/|__/\___/_/\___/\____/_/ /_/ /_/\___/   \__/\____/   \__/_/ /_/\___/   \____/\___/\___/\__,_/_/ /_/   \___/\____/\__,_/\___(_)
    ";

    string[] lines = welcomeArt.Split("\n");
    int windowWidth = Console.WindowWidth;

    foreach (var line in lines)
    {
      int x = ((Console.WindowWidth - line.Length) / 2);
      Console.SetCursorPosition(x, Console.CursorTop);
      Console.WriteLine(line);
    }

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



