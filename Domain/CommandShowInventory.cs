/* Command for transitioning between spaces
 */
namespace Domain {

    public class CommandShowInventory : BaseCommand, ICommand {


        public CommandShowInventory () {
            description = "Follow an exit";
        }

        public string Execute (Context context, string command, string[] parameters)
        {

            System.Text.StringBuilder sb = new
                System.Text.StringBuilder();

            if (Game.player.inventory.tools.Count == 0) {
                sb.AppendLine("Empty");
            }
            else
            {
                foreach (string tool in Game.player.inventory.tools) {
                    sb.AppendLine(string.Format(tool));
                }
            }

            return sb.ToString();
            
        }

    }
}