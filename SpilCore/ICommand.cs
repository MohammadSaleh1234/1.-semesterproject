/* Command interface
 */
namespace Spil {

interface ICommand {
  string Execute (Context context, string command, string[] parameters);
  string GetDescription ();
}

}
