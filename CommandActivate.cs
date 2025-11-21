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

            Console.WriteLine($"You couldn't seem to activate '{itemName}'. Maybe i should try activating the sirens?");
            return;

        }
        context.GetCurrent().items.Remove("illegal fishing boats");
        context.GetCurrent().AddItem("fishing nets", 5);

        Console.WriteLine("You successfully scare away the fishermen, but they left behind their nets. ");

        if (items.Count >= 1) {
            Console.WriteLine("You see the following: ");
            foreach (var pair in items){
                string itemKey = pair.Key;
                string[] itemKeyArray = itemKey.Split("s");

                if (pair.Value == 1 && itemKeyArray.Length > 1){
                    Console.WriteLine($"{pair.Value} {itemKeyArray[0]}");
                    return;
                }
                Console.WriteLine($"{pair.Value} {pair.Key}");
            }
        }

        else {
            Console.WriteLine("This area is empty now");
        }


    }

}
