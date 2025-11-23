using System;
using System.Collections.Generic;

static class ToolRegistry
{
    private static readonly Dictionary<string, ToolType> toolCatalog =
    new(StringComparer.OrdinalIgnoreCase)  // ← korrekt stavning
    {
        ["Trashbag"]    = ToolType.Bag,
        ["Plastic"]       = ToolType.Trash,
        ["Plasticbottle"] = ToolType.Trash,
        ["Cigarette"]   = ToolType.Trash,
        ["Algae covered corals"] = ToolType.Trash,
        ["Coral"] = ToolType.Trash,
        ["Brush"] = ToolType.Brush,
        ["Scissors"] = ToolType.Scissors,
        ["fishing nets"] = ToolType.Trash,
    };

    public static Tool CreateTool(string name)
    {
        if (toolCatalog.TryGetValue(name, out var t))
            return new Tool(name, t);
        return new Tool(name, ToolType.Generic);
    }

    public static bool IsTrash(string name) =>
    toolCatalog.TryGetValue(name, out var t) && t == ToolType.Trash;

    public static bool IsBag(string name) =>
    toolCatalog.TryGetValue(name, out var t) && t == ToolType.Bag;
}
