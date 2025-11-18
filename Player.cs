/* Player class for executing commands */

class Player
{

    Context context;
    Registry registry;

    public Player(Context context, Registry registry)
    {

        this.context = context;
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
