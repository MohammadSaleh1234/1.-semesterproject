/* Space class for modeling spaces (rooms, caves, ...)
 */
namespace Domain {

public class Space : Node {
  
  public readonly Dictionary<string,int> Items = new Dictionary<string,int>();
  
  public Space (string name) : base(name)
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
  public void AddItem(string itemName, int value = 1)
  {
    var existing = Items.Keys.FirstOrDefault(k =>
      string.Equals(k, itemName, StringComparison.OrdinalIgnoreCase));
    if (existing != null) Items[existing] += value;
    else Items[itemName] = value;
  }

  public void RemoveItem(string itemName)
  {
    var key = Items.Keys.FirstOrDefault(k =>
      string.Equals(k, itemName, StringComparison.OrdinalIgnoreCase));
    if (key == null) return;
    Items[key]--;
    if (Items[key] <= 0) Items.Remove(key);
  }

  public bool TryTakeItem(string requestedName, out string actualName)
  {
    var key = Items.Keys.FirstOrDefault(k =>
      string.Equals(k, requestedName, StringComparison.OrdinalIgnoreCase));
    if (key == null) { actualName = ""; return false; }
    Items[key]--;
    if (Items[key] <= 0) Items.Remove(key);
    actualName = key;
    return true;
  }

}
}
