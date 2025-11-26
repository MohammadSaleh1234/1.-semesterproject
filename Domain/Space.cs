/* Space class for modeling spaces (rooms, caves, ...)
 */
namespace Domain {

  public class Space : Node
  {
    public Dictionary<string,int> items = new Dictionary<string,int>();
    private string description;

    public Space(string name, string description) : base(name) { this.description = description; }

    public string GetDescription() {

      return description;

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
    var existing = items.Keys.FirstOrDefault(k =>
      string.Equals(k, itemName, StringComparison.OrdinalIgnoreCase));
    if (existing != null) items[existing] += value;
    else items[itemName] = value;
  }

  public void RemoveItem(string itemName)
  {
    var key = items.Keys.FirstOrDefault(k =>
      string.Equals(k, itemName, StringComparison.OrdinalIgnoreCase));
    if (key == null) return;
    items[key]--;
    if (items[key] <= 0) items.Remove(key);
  }

  public bool TryTakeItem(string requestedName, out string actualName)
  {
    var key = items.Keys.FirstOrDefault(k =>
      string.Equals(k, requestedName, StringComparison.OrdinalIgnoreCase));
    if (key == null) { actualName = ""; return false; }
    items[key]--;
    if (items[key] <= 0) items.Remove(key);
    actualName = key;
    return true;
  }
  public bool HasTrash()
  {
    // true hvis der findes et item-navn i rummet som ToolRegistry kalder Trash
    return items.Keys.Any(name => ToolRegistry.IsTrash(name));
  }

  //Kode som
  private bool isDirty = false;

  public void SetDirty(bool dirty) => isDirty = dirty;
  public bool IsDirty => isDirty;
}

}


