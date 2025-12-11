/* Context class to hold all context relevant to a session.
 */
namespace Domain {

public class Context {
  Space current;
  bool done = false;
  
  public Context (Space node) {
    current = node;
  }
  
  public Space GetCurrent() {
    return current;
  }
  
  public string Transition (string direction) {
    Space next = current.FollowEdge(direction);
    if (next==null) {
      return "You are confused, and walk in a circle looking for '"+direction+"'. In the end you give up 😩";
    } else {
      current = next;
      return current.Welcome();
    }
  }
  
  public void MakeDone () {
    done = true;
  }
  
  public bool IsDone () {
    return done;
  }
 
}
}
