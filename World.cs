/* World class for modeling the entire in-game world
 */

class World {
  Space entry;

  public World () {
    StartRoom entry = new StartRoom("Entry");
    Space strand    = new Space("Beach");
    Space coralrevet = new Space("Coralreef");
    Space dybhavet     = new Space("Ocean");
    Space vandoverfladen      = new Space("Watersurface");
    Space outside  = new Space("Outside");

    Quiz beachquiz = new Quiz("Quiz");
    Quiz2 coralquiz = new Quiz2("Quiz");
    Quiz3 oceanquiz = new Quiz3("Quiz");

    entry.AddEdge("Beach", strand);
    strand.AddEdge("Quiz", beachquiz);
    beachquiz.AddEdge("Coralreef", coralrevet);
    coralrevet.AddEdge("Quiz", coralquiz);
    coralquiz.AddEdge("Ocean", dybhavet);
    dybhavet.AddEdge("Quiz", oceanquiz);

    this.entry = entry;

    // tilføj items til et rum
    strand.AddItem("trashbag", 1);
    strand.AddItem("plastic", 5);

    coralrevet.AddItem("Brush", 1);
    coralrevet.AddItem("Algae covered corals", 5);
    coralrevet.SetDirty(true); //metoden laver vi om lidt i Space.cs

    // Lav dine tools (brug jeres Tool-konstruktør/GetName)
    var affaldssaek   = new Tool("Trashbag");
    var plastikflaske = new Tool("Plastic bottle");
  }

  public Space GetEntry () {
    return entry;
  }
}
