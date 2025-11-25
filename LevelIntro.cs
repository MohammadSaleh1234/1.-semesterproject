using System;

public static class LevelIntro
{
    public static void ShowBeachIntro()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("                 LEVEL 1 – THE BEACH");
        Console.WriteLine("==================================================");
        Console.WriteLine("The beach is covered with trash. Use your tools to clean the area.");
        Console.WriteLine("Remember: After finishing this level, you will get a quiz.");
        Console.WriteLine("Pay attention to the fun facts you encounter along the way!");
        Console.WriteLine();
        Console.WriteLine("Tools available in this level:");
        Console.WriteLine(" • Sack");
        Console.WriteLine(" • Wastecollector");
        Console.WriteLine();
        Console.WriteLine("Commands available:");
        Console.WriteLine(" • take [tool]");
        Console.WriteLine(" • show inventory");
        Console.WriteLine(" • go [direction]");
        Console.WriteLine("==================================================");
    }

    public static void ShowCoralIntro()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("               LEVEL 2 – CORAL REEF");
        Console.WriteLine("==================================================");
        Console.WriteLine("The coral reef is covered in algae. Clean the area to help the corals survive.");
        Console.WriteLine("Remember: After finishing this level, you will get a quiz.");
        Console.WriteLine("Pay attention to the fun facts you encounter along the way!");
        Console.WriteLine();
        Console.WriteLine("Tools available in this level:");
        Console.WriteLine(" • Brush");
        Console.WriteLine();
        Console.WriteLine("Commands available:");
        Console.WriteLine(" • clean");
        Console.WriteLine(" • take [tool]");
        Console.WriteLine(" • show inventory");
        Console.WriteLine(" • go [direction]");
        Console.WriteLine("==================================================");
    }

    public static void ShowDeepSeaIntro()
    {
        Console.WriteLine("==================================================");
        Console.WriteLine("              LEVEL 3 – THE DEEP SEA");
        Console.WriteLine("==================================================");
        Console.WriteLine("Illegal fishing boats are disturbing marine life. Use your tools to secure the area.");
        Console.WriteLine("Remember: After finishing this level, you will get a quiz.");
        Console.WriteLine("Pay attention to the fun facts you encounter along the way!");
        Console.WriteLine();
        Console.WriteLine("Tools available in this level:");
        Console.WriteLine(" • Sirens");
        Console.WriteLine(" • Scissors");
        Console.WriteLine();
        Console.WriteLine("Commands available:");
        Console.WriteLine(" • activate sirens");
        Console.WriteLine(" • cut [net]");
        Console.WriteLine(" • take [tool]");
        Console.WriteLine(" • show inventory");
        Console.WriteLine(" • go [direction]");
        Console.WriteLine("==================================================");
    }
}
