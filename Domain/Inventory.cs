using System;
using System.Collections.Generic;

namespace Domain
{

    public class Inventory
    {
        public List<string> tools = new List<string>();

        public string AddTool(string newTool)
        {
          
            if (tools.Contains(newTool))
            {
                return "You already have that";
            }
            
                tools.Add(newTool);

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
                foreach (string tool in tools)
                    Console.WriteLine($"- {tool}");
            }
        }

        // NY metode for at tjekke om et værktøj er i inventaret
        public bool HasTool(string toolName)
        {
            return tools.Contains(toolName);
        }
  
        
    }
}
