/* Space class for modeling spaces (rooms, caves, ...)
 */
namespace Domain {

public class Space : Node {
  public Space (String name) : base(name)
  {

  }
  
  public virtual string Welcome () {

    System.Text.StringBuilder sb = new
    System.Text.StringBuilder("You are now at "+name+"\n");
    sb.AppendLine("Current exits are:");
    HashSet<string> exits = edges.Keys.ToHashSet();


    foreach (String exit in exits) {
      sb.AppendLine(" - "+exit);
    }
    return sb.ToString();

  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }

  public List<string> GetExits()
  {
    return edges.Keys.ToList();
  }


}
}
