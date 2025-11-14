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

    Quiz beachquiz = new Quiz("Beachquiz");
    Quiz2 coralquiz = new Quiz2("Coralquiz");
    Quiz3 oceanquiz = new Quiz3("Oceanquiz");


    strand.AddEdge("Beachquiz", beachquiz);
    beachquiz.AddEdge("Coralrevet", coralrevet);
    coralrevet.AddEdge("Coralquiz", coralquiz);
    coralquiz.AddEdge("Ocean", dybhavet);
    coralrevet.AddEdge("Strand", strand);
    coralrevet.AddEdge("Dybhavet", dybhavet);
    dybhavet.AddEdge("Oceanquiz", oceanquiz);
    dybhavet.AddEdge("Vandoverfladen", vandoverfladen);

    this.strand = strand;

    // tilføj items til et rum
    strand.AddItem("plastic", 5);
    coralrevet.AddItem("net", 5);

  }
  
  public Space GetEntry () {
    return strand;
  }
}

