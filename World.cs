/* World class for modeling the entire in-game world
 */

class World {
  Space strand;

  public World () {
    Space strand    = new Space("Strand");
    Space coralrevet = new Space("Coralrevet");
    Space dybhavet     = new Space("Dybhavet");
    Space vandoverfladen      = new Space("Vandoverfladen");
    Space outside  = new Space("Outside");


    strand.AddEdge("Coralrevet", coralrevet);
    coralrevet.AddEdge("Strand", strand);
    coralrevet.AddEdge("Dybhavet", dybhavet);
    dybhavet.AddEdge("Vandoverfladen", vandoverfladen);

    this.strand = strand;

    // tilføj items til et rum
    strand.AddItem("affaldssæk", 1);
    strand.AddItem("plastik", 5);

    coralrevet.AddItem("Børste", 1);
    coralrevet.SetDirty(true); //metoden laver vi om lidt i Space.cs

    // Lav dine tools (brug jeres Tool-konstruktør/GetName)
    var affaldssaek   = new Tool("Affaldssæk");
    var plastikflaske = new Tool("Plastikflaske");
  }

  public Space GetEntry () {
    return strand;
  }
}
