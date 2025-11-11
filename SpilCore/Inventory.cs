using System;
using System.Collections.Generic;

namespace Spil {

public class Inventory {


    public List<Tool> tools = new List<Tool>();

    public void AddTool(Tool tool) {
        tools.Add(tool);

    }

}
}
