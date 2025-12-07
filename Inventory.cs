using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory {


    public List<Tool> tools = new List<Tool>();

    public void AddTool(Tool tool) {

        if (tools.Any(t => t.GetName().Equals(tool.GetName(), StringComparison.OrdinalIgnoreCase))) {
            Console.WriteLine($"You already have a {tool.GetName()}!");
            return;
        }

        tools.Add(tool);
        Console.WriteLine($"Added {tool.GetName()} to inventory 🧰");
    }

    public void ShowInventory() {
        Console.WriteLine("=== Inventory ===");
        if (tools.Count == 0) {
            Console.WriteLine("(empty)");
        } else {
            foreach (Tool tool in tools)
                Console.WriteLine($"- {tool.GetName()}");
        }
    }
    
    public bool HasTool(string toolName) {
        return tools.Any(t => t.GetName().Equals(toolName, StringComparison.OrdinalIgnoreCase));
    }

    public bool HasType(ToolType type)
    {
        return tools.Any(t => t.Type == type);
    }
}
