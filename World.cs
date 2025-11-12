/* World class for modeling the entire in-game world
 */

class World {
  Space strand;
  
  public World () {
    Space strand = new Space("beach");
    Space coralrevet = new Space("coralreef");
    Space dybhavet = new Space("ocean");
    Space vandoverfladen  = new Space("surface");



    strand.AddEdge("coralreef", coralrevet);
    coralrevet.AddEdge("beach", strand);
    coralrevet.AddEdge("ocean", dybhavet);
    dybhavet.AddEdge("surface", vandoverfladen);

    this.strand = strand;

    // tilføj items til et rum
    strand.AddItem("plastic", 5);
    coralrevet.AddItem("algae covered corals", 5);

  }
  
  public Space GetEntry () {
    return strand;
  }
}

