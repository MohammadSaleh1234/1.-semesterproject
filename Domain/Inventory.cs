using System;
using System.Collections.Generic;

namespace Domain
{

    public class Inventory
    {


        public List<Tool> tools = new List<Tool>();

        public string AddTool(Tool tool)
        {
            // Tjekker om værktøjet allerede er i inventaret baseret på navn
            if (tools.Any(t => t.GetName().Equals(tool.GetName(), StringComparison.OrdinalIgnoreCase)))
            {
                return "You already have a that";
            }

            return "added";
        }

        public void ShowInventory()
        {
            Console.WriteLine("=== Inventory ===");
            if (tools.Count == 0)
            {
                Console.WriteLine("(empty)");
            }
            else
            {
                foreach (Tool tool in tools)
                    Console.WriteLine($"- {tool.GetName()}");
            }
        }

        // NY metode for at tjekke om et værktøj er i inventaret
        public bool HasTool(string toolName)
        {
            return tools.Any(t => t.GetName().Equals(toolName, StringComparison.OrdinalIgnoreCase));
        }
        
        public bool HasType(ToolType type)
        {
            return tools.Any(t => t.Type == type);
        }
        
    }
}
