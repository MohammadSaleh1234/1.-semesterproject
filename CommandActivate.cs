class CommandActivate : BaseCommand, ICommand {

    public CommandActivate() {
        description = "activates the sirens on your boat";
    }

    public void Execute(Context context, string command, string[] parameters){

        if (parameters.Length < 1) {
            Console.WriteLine("Activate what?");
            return;
        }

        var items = context.GetCurrent().items;
        string itemName = parameters[0];

        if (!itemName.Equals("sirens") || !items.ContainsKey("illegal fishing boats")) {

            Console.WriteLine($"You couldn't seem to activate '{itemName}'. Make sure you are out on the oceans and try to 'activate sirens");
            return;

        }
        context.GetCurrent().items.Remove("illegal fishing boats");
        context.GetCurrent().AddItem("fishing net", 5);
        context.GetCurrent().AddItem("Scissors", 1);
        Console.Clear();

        Console.WriteLine("You successfully scare away the fishermen, but they left behind their fishing nets. You need to cut them down. ");
        Console.WriteLine();
        Console.WriteLine("Use a pair of scissors to cut the net");
        Console.WriteLine();

        if (items.Count >= 1) {
            Console.WriteLine("You see the following: ");
            foreach (var pair in items){
                string itemKey = pair.Key;
                Console.WriteLine($"{pair.Value} {pair.Key}");
            }
        }

        else {
            Console.WriteLine("This area is empty now");
        }


    }

}
