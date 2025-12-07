/* World class for modeling the entire in-game world
 */

class World {
  Space entry;

  public World () {
    
    
    StartRoom entry = new StartRoom("Entry", "ændre beskrivelsen her");
    Space beach    = new Space("Beach", "The beach is littered with trash - use the trashbag to collect plastic");
    Space coralreef = new Space("Coralreef", "The coralreef is dirty – use the brush to clean the corals.");
    Space ocean    = new Space("Ocean", "The boats are not allowed to fish here - use your sirens to scare them away");

    Quiz beachquiz = new Quiz("Quiz", "");
    Quiz2 coralquiz = new Quiz2("Quiz", "");
    Quiz3 oceanquiz = new Quiz3("Quiz", "");

    entry.AddEdge("Beach", beach);
    beach.AddEdge("Quiz", beachquiz);
    beachquiz.AddEdge("Coralreef", coralreef);
    coralreef.AddEdge("Quiz", coralquiz);
    coralquiz.AddEdge("Ocean", ocean);
    ocean.AddEdge("Quiz", oceanquiz);
    
    beach.AddItem("Trashbag", 1);
    beach.AddItem("Plastic", 5);
    beach.SetDirty(true);

    coralreef.AddItem("Brush", 1);
    coralreef.AddItem("Algae covered corals", 5);
    coralreef.SetDirty(true);

    ocean.AddItem("Illegal fishing boats", 5);
    ocean.SetDirty(true);
    
    this.entry = entry;
  }

  public Space GetEntry () {
    return entry;
  }
}
