/* Tool class for representing player tools */
public enum ToolType {Generic, Bag, Trash, Brush, Scissors};

public class Tool {
    private string name;
    public ToolType Type {get; private set;}

    public Tool(string name) : this(name, ToolType.Generic){}

    public Tool(string name, ToolType type){
        this.name = name;
        this.Type = type;
    }

    public string GetName() {
        return name;
    }
}
