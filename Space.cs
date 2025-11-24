using System;
using System.Collections.Generic;
using System.Linq;


public class Space : Node
{
  public Dictionary<string,int> items = new Dictionary<string,int>();
  private string description;

  public Space(string name, string description) : base(name) { this.description = description; }

  public string GetDescription() {

    return description;

  }

  public virtual void Welcome()
  {
    Console.Clear();
    string line = "You are now at the "+name;

    int windowWidth = Console.WindowWidth;
    int x = ((Console.WindowWidth - line.Length) / 2);
    Console.SetCursorPosition(x, Console.CursorTop);
    Console.WriteLine(line);



    /*var exits = edges.Keys.ToHashSet();
    Console.SetCursorPosition(x, Console.CursorTop);
    Console.WriteLine("You can continue to: ");
    foreach (var exit in exits) {
      Console.SetCursorPosition(x, Console.CursorTop);
      Console.WriteLine(" - " + exit);}
    Console.WriteLine();*/



    // Items på gulvet
    if (items.Count == 0)
    {
      Console.WriteLine();
    }
    else
    {
      Console.WriteLine("You see the following:");
      foreach (var pair in items) Console.WriteLine($" - {pair.Value} {pair.Key}");
    }
    Console.WriteLine();

    //Koden for Koralrevet og dets egenskab. Altså først "Dirty", dermed "cleaner" man, det ville resultere i nogle forskellige Console.WriteLine, outputs.


    switch (name)
    {
      case "Coralreef":
      {
        if (IsDirty && items.Count > 0)
        {
          Console.WriteLine(Game.context.GetCurrent().GetDescription());
        }
        Console.WriteLine();
        break;
      }

      case "Beach":
      {
        if (IsDirty && items.Count > 0)
        {
          Console.WriteLine(Game.context.GetCurrent().GetDescription());
        }

        Console.WriteLine();
        break;
      }

      case "Ocean":
      {
        if (IsDirty && items.ContainsKey("illegal fishing boats"))
        {
          Console.WriteLine(Game.context.GetCurrent().GetDescription());
        }
        else if (items.ContainsKey("fishing net"))
        {
          Console.WriteLine("Use a pair of scissors to cut the net");
        }

        Console.WriteLine();
        break;
      }

      default:
      {
        Console.WriteLine("Nothing to be found here");
        break;
      }
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
