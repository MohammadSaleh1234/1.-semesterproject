/* World class for modeling the entire in-game world
 */
namespace Domain {

public class World {
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
    strand.AddEdge("Strand", strand);

    this.strand = strand;

  }
  
  public Space GetEntry () {
    return strand;
  }
}
}
