using System;
using System.Collections.Generic;

public class Inventory {
    private List<Tool> tools = new List<Tool>();

    public void AddTool(Tool tool) {
        tools.Add(tool);
        Console.WriteLine("Added " + tool.GetName() + " to inventory 🧰");
    }

    public void ShowInventory() {
        Console.WriteLine("=== Inventory ===");
        if (tools.Count == 0) {
            Console.WriteLine("(empty)");
        } else {
            foreach (Tool tool in tools) {
                Console.WriteLine("- " + tool.GetName());
            }
        }
    }
}
