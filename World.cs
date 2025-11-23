/* World class for modeling the entire in-game world
 */

class World {
  Space entry;

  public World () {
    StartRoom entry = new StartRoom("Entry", "ændre beskrivelsen her");
    Space strand    = new Space("Beach", "Use the trashbag to collect plastic");
    Space coralrevet = new Space("Coralreef", "The Coralreef is dirty – use the brush to clean the corals.");
    Space dybhavet     = new Space("Ocean", "ændre beskrivelsen her");

    Quiz beachquiz = new Quiz("Quiz", "");
    Quiz2 coralquiz = new Quiz2("Quiz", "");
    Quiz3 oceanquiz = new Quiz3("Quiz", "");

    entry.AddEdge("Beach", strand);
    strand.AddEdge("Quiz", beachquiz);
    beachquiz.AddEdge("Coralreef", coralrevet);
    coralrevet.AddEdge("Quiz", coralquiz);
    coralquiz.AddEdge("Ocean", dybhavet);
    dybhavet.AddEdge("Quiz", oceanquiz);

    entry.AddEdge("Ocean", dybhavet);

    this.entry = entry;

    // tilføj items til et rum
    strand.AddItem("trashbag", 1);
    strand.AddItem("plastic", 5);
    strand.SetDirty(true);

    coralrevet.AddItem("Brush", 1);
    coralrevet.AddItem("Algae covered corals", 5);
    coralrevet.SetDirty(true);

    dybhavet.AddItem("illegal fishing boats", 5);

    // Lav dine tools
    var affaldssaek   = new Tool("Trashbag");
    var plastikflaske = new Tool("Plastic bottle");
  }

  public Space GetEntry () {
    return entry;
  }
}
