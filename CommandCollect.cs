class CommandCollect : BaseCommand, ICommand {

    public CommandCollect () {
        description = "Collect an item you see in your current room";
    }

    public void Execute (Context context, string command, string[] parameters) {

        if (GuardEq(parameters, 1)) {

            Console.WriteLine("Please specify what to collect!");

        }
        else {

            context.GetCurrent().RemoveItem(parameters[0]);
            Console.WriteLine("You see the following items on the floor:");

            foreach (var pair in context.GetCurrent().items){
                Console.WriteLine($"{pair.Value} {pair.Key}");

            }

       }

   }
}
