/* Context class to hold all context relevant to a session.
 */

class Context {
  Space current;
  bool done = false;
  
  public Context (Space node) {
    current = node;
  }
  
  public Space GetCurrent() {
    return current;
  }
  
  public void Transition (string direction) {
    Space next = current.FollowEdge(direction);
    if (next==null) {
      Console.WriteLine("You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩");
    } else {
      current.Goodbye();
      current = next;
      current.Welcome();
    }
  }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
  // Giv læse-adgang til nuværende rum
  public Space CurrentSpace => current;   // <- hvis dit felt hedder noget andet, brug det navn

  // (valgfrit – hvis du vil have både property og metode)
  public Space GetCurrentSpace() => CurrentSpace;

  // Gør inventory let tilgængelig via Context
  public Inventory Inventory => Game.inventory;
}

