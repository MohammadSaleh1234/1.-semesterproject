class CommandBrush : BaseCommand, ICommand {

    public CommandBrush () {
        description = "Use a brush to clean corals";
    }

    public void Execute (Context context, string command, string[] parameters) {

        if (parameters.Length != 1) {
            Console.WriteLine($"Maybe i should try brushing a coral?");
            return;
        }

        var items = context.GetCurrent().items;
        string itemName = parameters[0];

        if (!itemName.Equals("coral") || !items.ContainsKey("algae covered corals")) {

            Console.WriteLine($"You couldn't seem to find '{itemName}'. Maybe i should try brushing a coral?");
            return;

        }

        context.GetCurrent().RemoveItem("algae covered corals");

        if (items.Count >= 1) {
            Console.WriteLine("You see the following: ");
            foreach (var pair in items){

                Console.WriteLine($"{pair.Value} {pair.Key}");
            }
        }

        else {
            Console.WriteLine("All corals are clean!");
        }
    }
}


