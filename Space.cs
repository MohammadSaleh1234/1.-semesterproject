/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {

  public Dictionary<string, int> items = new Dictionary<string, int>();

  public Space (String name) : base(name)
  {
  }
  
  public virtual void Welcome () {
    Console.Clear();
    Console.WriteLine("You are now at the "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();

    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }


    if (items.Count < 1){
      return;
    }

    Console.WriteLine("You see the following:");
    foreach (var pair in items){
      Console.WriteLine($"- {pair.Value} {pair.Key}");
    }

    Console.WriteLine();

  }

  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
  }

  public void AddItem(string name, int value){

    items.Add(name, value);

  }

  public void RemoveItem(string name){

    if (items.ContainsKey(name))
    {
      items[name]--;

      if (items[name] <= 0) {
        items.Remove(name);
      }
    }
  }


  // Opret en ny fil: DescribedSpace.cs (eller i Space.cs under klassens slutning)
  class DescribedSpace : Space
  {
    private readonly string description;

    public DescribedSpace(string name, string description) : base(name)
    {
      this.description = description;
    }

    public override void Welcome()
    {
      base.Welcome();                 // bevar standard-udgange-listen
      Console.WriteLine(description); // ekstra tekst til dette rum
    }
  }
}

