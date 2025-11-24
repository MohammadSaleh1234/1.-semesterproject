/* Space class for modeling spaces (rooms, caves, ...)
 */
namespace Domain {

public class Space : Node {
  
  public Dictionary<string,int> items = new Dictionary<string,int>();
  private string description;
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
  public void AddItem(string name, int value = 1)
  {
    var existing = items.Keys.FirstOrDefault(k =>
      string.Equals(k, name, StringComparison.OrdinalIgnoreCase));
    if (existing != null) items[existing] += value;
    else items[name] = value;
  }

  public void RemoveItem(string name)
  {
    var key = items.Keys.FirstOrDefault(k =>
      string.Equals(k, name, StringComparison.OrdinalIgnoreCase));
    if (key == null) return;
    items[key]--;
    if (items[key] <= 0) items.Remove(key);
  }

  public bool TryTakeItem(string requestedName, out string actualName)
  {
    var key = items.Keys.FirstOrDefault(k =>
      string.Equals(k, requestedName, StringComparison.OrdinalIgnoreCase));
    if (key == null) { actualName = null; return false; }
    items[key]--;
    if (items[key] <= 0) items.Remove(key);
    actualName = key;
    return true;
  }

}
}
