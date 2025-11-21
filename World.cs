/* World class for modeling the entire in-game world
 */

class World {
  Space entry;

  public World () {
    Space entry = new Space("Entry");
    Space strand    = new Space("Beach");
    Space coralrevet = new Space("Coralreef");
    Space dybhavet     = new Space("Ocean");
    Space vandoverfladen      = new Space("Watersurface");
    Space outside  = new Space("Outside");

    Quiz beachquiz = new Quiz("Beachquiz");
    Quiz2 coralquiz = new Quiz2("Coralquiz");
    Quiz3 oceanquiz = new Quiz3("Oceanquiz");

    entry.AddEdge("Beach", strand);
    strand.AddEdge("Beachquiz", beachquiz);
    beachquiz.AddEdge("Coralreef", coralrevet);
    coralrevet.AddEdge("Coralquiz", coralquiz);
    coralquiz.AddEdge("Ocean", dybhavet);
    dybhavet.AddEdge("Oceanquiz", oceanquiz);

    this.entry = entry;

    // tilføj items til et rum
    strand.AddItem("trashbag", 1);
    strand.AddItem("plastic", 5);

    coralrevet.AddItem("Brush", 1);
    coralrevet.SetDirty(true); //metoden laver vi om lidt i Space.cs

    // Lav dine tools (brug jeres Tool-konstruktør/GetName)
    var affaldssaek   = new Tool("Trashbag");
    var plastikflaske = new Tool("Plastic bottle");
  }

  public Space GetEntry () {
    return entry;
  }
}
