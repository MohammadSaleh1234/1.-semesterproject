/* Tool class for representing player tools */
namespace Domain {

public class Tool {
    private string name;

    public Tool(string name) {
        this.name = name;
    }

    public string GetName() {
        return name;
    }
}
}
