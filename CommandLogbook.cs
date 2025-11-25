using System;

class CommandLogbook : BaseCommand, ICommand
{
    public CommandLogbook()
    {
        description = "Viser logbogen for det level du står i.";
    }

    public void Execute(Context context, string command, string[] parameters)
    {
        if (parameters.Length > 0)
        {
            Console.WriteLine("Skriv blot 'logbog' uden ekstra ord.");
            return;
        }

        // Find det nuværende rum
        Space currentSpace = (Space)context.GetCurrent();
        string location = currentSpace.GetName();

        // Vis logbog afhængigt af level
        if (location == "Beach")
        {
            LevelIntro.ShowBeachIntro();
        }
        else if (location == "Coralreef")
        {
            LevelIntro.ShowCoralIntro();
        }
        else if (location == "Ocean")
        {
            LevelIntro.ShowDeepSeaIntro();
        }
        else
        {
            Console.WriteLine("Dette område har ingen logbog.");
        }
    }
}
