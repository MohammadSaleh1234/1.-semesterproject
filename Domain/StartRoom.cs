namespace Domain {

public class StartRoom : Space
{


    public StartRoom(string name, string description) : base(name, description)
    {
    }

    public override string Welcome()
    {
        var spaceName = GetName();
        string line = "Go to the beach and see what tasks the Ocean code brings you today!";

        return line;
    }
}
}