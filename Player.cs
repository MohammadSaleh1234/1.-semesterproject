/* Player class for executing commands */

class Player
{
    public static Inventory inventory = new Inventory();

    Registry registry;

    public Player( Registry registry)
    {


        this.registry = registry;

    }


    public void ExecuteCommand(string inputLine)
    {
        registry.Dispatch(inputLine);
    }


   public int highscore(int beachScore, int coralScore, int oceanScore)
    {
    int highscore = 0;

        highscore = beachScore + coralScore + oceanScore;

        return highscore;
    }


}
