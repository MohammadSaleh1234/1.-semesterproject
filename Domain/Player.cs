/* Player class for executing commands */
namespace Domain {

class Player {

    Context context;
    Registry registry;

    public Player (Context context, Registry registry){

        this.context = context;
        this.registry = registry;

    }


    public void ExecuteCommand(string inputLine) {
        registry.Dispatch(inputLine);
    }

}
}
