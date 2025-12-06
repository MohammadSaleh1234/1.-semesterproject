namespace Domain
{
    
        public class CommandCut : BaseCommand, ICommand
        {
            public CommandCut()
            {
                description = "cut down fishing net.";
            }

            public string Execute(Context context, string command, string[] parameters)
            {

                if (GuardEq(parameters, 1))
                {
                    return "Type 'cut net' to cut down fishing net.";
                }

                var wanted = parameters[0];

                if (!Game.player.inventory.tools.Contains("Scissors"))
                {
                    return "fail";
                }


                var items = context.GetCurrent().items;

                if (!wanted.Equals("net") || !items.ContainsKey("Fishing net"))
                {

                    return "You couldn't seem to find '{wanted}'.";


                }

                context.GetCurrent().RemoveItem("Fishing net");
                Space current = context.GetCurrent();
                Game.trashManager.CollectTrash(current.GetName());
                
                string roomName = "Ocean";
                string line = Game.trashManager.CollectTrash(roomName);
                return line;


            }
        }
}