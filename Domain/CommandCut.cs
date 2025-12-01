namespace Domain
{
    
        class CommandCut : BaseCommand, ICommand
        {
            public CommandCut()
            {
                description = "cut down fishing net.";
            }

            public string Execute(Context context, string command, string[] parameters)
            {

                if (GuardEq(parameters, 1))
                {
                    return "Type 'cut net' to cut down fishing net.";
                }

                var wanted = parameters[0];
                var inventory = Game.player.inventory;

                if (ToolRegistry.IsTrash(wanted) && !inventory.HasType(ToolType.Scissors))
                {
                    return "You need scissors to cut the nets!";
                }


                var items = context.GetCurrent().items;

                if (!wanted.Equals("net") || !items.ContainsKey("fishing net"))
                {

                    return "You couldn't seem to find '{wanted}'.";


                }

                context.GetCurrent().RemoveItem("fishing net");
                Space current = context.GetCurrent();
                Game.trashManager.CollectTrash(current.GetName());

                if (!context.GetCurrent().HasTrash())
                {
                    return
                        "✨You cut all the nets in the area! You may now move on to the quiz. Type 'go quiz' to continue. ✨";
                }

                return "sucess";


            }
        }
}