/* Command for transitioning between spaces
 */
namespace Domain {

public class CommandShowInventory : BaseCommand, ICommand {


    public CommandShowInventory () {
        description = "Follow an exit";
    }

    public string Execute (Context context, string command, string[] parameters) {

            System.Text.StringBuilder sb = new
            System.Text.StringBuilder("=== Inventory ==="+"\n");

            if (Player.inventory.tools.Count == 0) {
                sb.AppendLine("Empty");
            }
            else
            {
                foreach (Tool tool in Player.inventory.tools) {
                    sb.AppendLine(string.Format(" - "+tool.GetName()));
                 }
            }

            return sb.ToString();



    }

}
}


