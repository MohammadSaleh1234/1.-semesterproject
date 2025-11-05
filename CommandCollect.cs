class CommandCollect : BaseCommand, ICommand {

    public CommandCollect () {
        description = "Collect an item you see in your current room";
    }

    public void Execute (Context context, string command, string[] parameters) {

        if (parameters.Length != 1) {
            Console.WriteLine($"Collect what?");
            return;
        }

        var items = context.GetCurrent().items;
        string itemName = parameters[0];

        if (!items.ContainsKey(itemName)){
            Console.WriteLine($"You couldn't seem to find '{itemName}'");
            return;
        }

        context.GetCurrent().RemoveItem(parameters[0]);

        if (items.Count >= 1) {
            Console.WriteLine("You see the following items on the floor: ");
            foreach (var pair in items){
                Console.WriteLine($"{pair.Value} {pair.Key}");
            }
        }

        else {
            Console.WriteLine("This area is empty now");
        }
    }
}


