/* World class for modeling the entire in-game world
 */

class World {
  Space beach;
  
  public World () {
    Space beach = new Space("beach");
    Space coralreef = new Space("coralreef");
    Space ocean = new Space("ocean");
    Space surface  = new Space("surface");



    beach.AddEdge("coralreef", coralreef);
    coralreef.AddEdge("beach", beach);
    coralreef.AddEdge("ocean", ocean);
    ocean.AddEdge("surface", surface);

    this.beach = beach;


    beach.AddItem("plastic", 5);
    coralreef.AddItem("algae covered corals", 5);
    ocean.AddItem("illegal fishing boats", 5);

    beach.AddItem("Affaldssæk", 1);
    beach.AddItem("Plastik", 3);


    coralreef.AddItem("Børste", 1);
    coralreef.SetDirty(true); //metoden laver vi om lidt i Space.cs

    // Lav dine tools (brug jeres Tool-konstruktør/GetName)
    var affaldssaek   = new Tool("Affaldssæk");
    var plastikflaske = new Tool("Plastikflaske");
  }
  
  public Space GetEntry () {
    return beach;
  }
}

