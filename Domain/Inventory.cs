using System;
using System.Collections.Generic;

namespace Domain {

public class Inventory {


    public List<Tool> tools = new List<Tool>();

    public void AddTool(Tool tool) {
        tools.Add(tool);

    }

}
}
