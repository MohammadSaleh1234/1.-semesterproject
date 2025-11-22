class CommandCut : BaseCommand, ICommand {

    public CommandCut () {
        description = "Use scissors to cut open fishing nets";
    }

    public void Execute (Context context, string command, string[] parameters) {

        if (parameters.Length < 1) {
            Console.WriteLine($"Cut what?");
            return;
        }

        var items = context.GetCurrent().items;
        string itemName = parameters[0];

        if (!itemName.Contains("net") || !items.ContainsKey("fishing nets")) {

            Console.WriteLine($"Do you want to cut '{itemName}'. Maybe you should try cutting a net.");
            return;

        }

        context.GetCurrent().RemoveItem("fishing nets");

        if (items.Count >= 1) {
            Console.WriteLine("You see the following: ");
            foreach (var pair in items){
                string itemKey = pair.Key;
                string[] itemKeyArray = itemKey.Split("s");

                if (pair.Value == 1 && itemKeyArray.Length > 1){
                    Console.WriteLine($"{pair.Value} {itemKeyArray[0]}s{itemKeyArray[1]}");
                    return;
                }
                Console.WriteLine($"{pair.Value} {pair.Key}");
            }
        }

        else {
            Console.WriteLine("All fishing nets are gone!");
        }
    }
}


