/* Space class for modeling spaces (rooms, caves, ...)
 */

class Space : Node {
  public Space (String name) : base(name)
  {
  }
  
  public virtual void Welcome () {
    Console.WriteLine("You are now at "+name);
    HashSet<string> exits = edges.Keys.ToHashSet();
    Console.WriteLine("Current exits are:");
    foreach (String exit in exits) {
      Console.WriteLine(" - "+exit);
    }
  }
  
  public void Goodbye () {
  }
  
  public override Space FollowEdge (string direction) {
    return (Space) (base.FollowEdge(direction));
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

