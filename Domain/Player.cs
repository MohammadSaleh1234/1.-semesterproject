/* Player class for executing commands */
namespace Domain
{

    public class Player
    {
        public Inventory inventory = new Inventory();

        Registry registry;

        public Player(Registry registry)
        {


            this.registry = registry;

        }


        public string ExecuteCommand(string inputLine)
        {
            return registry.Dispatch(inputLine);
        }


        public int highscore(int beachScore, int coralScore, int oceanScore)
        {
            int highscore = 0;

            highscore = beachScore + coralScore + oceanScore;

            return highscore;
        }


    }
}