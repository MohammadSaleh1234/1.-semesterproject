class CommandCollect : BaseCommand, ICommand {

    public CommandCollect () {
        description = "Collect an item you see in your current room";
    }

    public void Execute (Context context, string command, string[] parameters) {

        if (parameters.Length != 1) {
            Console.WriteLine($"Collect what?");
            return;
        }

        Space current = context.GetCurrent();
        var items = current.items;
        string itemName = parameters[0];

        if (!items.ContainsKey(itemName)){
            Console.WriteLine($"You couldn't seem to find '{itemName}'");
            return;
        }

        // Spilleren samler skrald op -> fjern det fra rummet
        current.RemoveItem(itemName);

        // 🔹 NYT: vis et tilfældigt fun fact, hvis vi er på stranden
        Game.trashManager.CollectTrash(current.GetName());

        if (items.Count >= 1) {
            Console.WriteLine("You see the following: ");
            foreach (var pair in items){
                Console.WriteLine($"{pair.Value} {pair.Key}");
            }
        } else {
            Console.WriteLine("This area is empty now");
        }
    }
}
