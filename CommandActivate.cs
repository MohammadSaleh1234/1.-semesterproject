class CommandActivate : BaseCommand, ICommand {

    public CommandActivate() {
        description = "activate sirens";
    }

    public void Execute(Context context, string command, string[] parameters){

        if (parameters.Length < 1) {
            Console.WriteLine("Activate the sirens by typing 'activate sirens");
            return;
        }

        var items = context.GetCurrent().items;
        string itemName = parameters[0];

        if (!itemName.Equals("sirens") || !items.ContainsKey("Illegal fishing boats")) {

            Console.WriteLine($"You couldn't seem to activate '{itemName}'. Make sure you are out on the oceans and try to 'activate sirens");
            return;

        }
        context.GetCurrent().items.Remove("Illegal fishing boats");
        context.GetCurrent().AddItem("Fishing net", 5);
        context.GetCurrent().AddItem("Scissors", 1);
        Console.Clear();

        context.GetCurrent().Welcome();
        Console.WriteLine("You successfully scare away the fishermen, but they left behind their fishing nets. You need to cut them down. ");

        Console.WriteLine();



    }

}
