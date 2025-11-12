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

    // tilføj items til et rum
    beach.AddItem("plastic", 5);
    coralreef.AddItem("algae covered corals", 5);
    ocean.AddItem("illegal fishing boats", 5);

  }
  
  public Space GetEntry () {
    return beach;
  }
}

