using System;
using System.Collections.Generic;

public class Inventory {


    public List<Tool> tools = new List<Tool>();

    public void AddTool(Tool tool) {
        tools.Add(tool);
        Console.WriteLine("Added " + tool.GetName() + " to inventory 🧰");
    }

}
