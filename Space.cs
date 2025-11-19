using System;
using System.Collections.Generic;
using System.Linq;


public class Space : Node
{
  public Dictionary<string,int> items = new Dictionary<string,int>();


  public Space(string name) : base(name) { }

  public virtual void Welcome()
  {
    var spaceName = GetName();

    Console.WriteLine("You are now at " + name);

    var exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (var exit in exits) Console.WriteLine(" - " + exit);
    Console.WriteLine();



    // Items på gulvet
    if (items.Count == 0)
    {
      Console.WriteLine("You see nothing particular on the ground.");
    }
    else if (items.Count == 1)
    {
      var kv = items.First();
      Console.WriteLine("You see the following item on the ground:");
      Console.WriteLine($" - {kv.Value} {kv.Key}");
    }
    else
    {
      Console.WriteLine("You see the following items on the ground:");
      foreach (var pair in items) Console.WriteLine($" - {pair.Value} {pair.Key}");
    }
    Console.WriteLine();

    //Koden for Koralrevet og dets egenskab. Altså først "Dirty", dermed "cleaner" man, det ville resultere i nogle forskellige Console.WriteLine, outputs.
    if (string.Equals(spaceName, "Coralreef", StringComparison.OrdinalIgnoreCase))
    {
      if (IsDirty)
        Console.WriteLine("The Coralreef is dirty – use the brush to clean the corals.");
      else
        Console.WriteLine("The Coralreef is now clean and shiny.");

      Console.WriteLine();
    }
  }

  public void Goodbye() { }

  // go-case-insensitivt
  public override Space FollowEdge(string direction)
  {
    var exact = (Space)base.FollowEdge(direction);
    if (exact != null) return exact;

    foreach (var key in edges.Keys)
      if (string.Equals(key, direction, StringComparison.OrdinalIgnoreCase))
        return (Space)base.FollowEdge(key);

    return null;
  }

  // ---- items (case-insensitivt) ----
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
