using System;
using System.Collections.Generic;

static class ToolRegistry
{
    private static readonly Dictionary<string, ToolType> toolCatalog =
    new(StringComparer.OrdinalIgnoreCase)  // ← korrekt stavning
    {
        ["Affaldssæk"]    = ToolType.Bag,
        ["Plastik"]       = ToolType.Trash,
        ["Plastikflaske"] = ToolType.Trash,
        ["Cigaretskod"]   = ToolType.Trash,

        ["Børste"] = ToolType.Brush,
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
