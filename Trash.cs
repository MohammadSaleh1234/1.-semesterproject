using System;
using System.Collections.Generic;

public class Trash
{
    public string Name { get; }
    public string Description { get; }
    public string FunFact { get; }

    public Trash(string name, string description, string funFact)
    {
        Name = name;
        Description = description;
        FunFact = funFact;
    }
}

public class TrashManager
{
    private List<Trash> trashList = new List<Trash>()
    {
        new Trash(
            "Plastikflaske",
            "Du finder en tom plastikflaske i sandet.",
            "💡 Plastik tager flere hundrede år at nedbryde! (400-500 år) Det er længere tid, end jeg kan bruge på at spise pomfritter! HaHa!"
        ),
        new Trash(
            "Slikpapir",
            "Et farverigt slikpapir flyver hen over stranden.",
            "💡 Vidste du, at over 80% af alt affald i havet kommer fra landjorden?"
        ),
        new Trash(
            "Plastiksugerør",
            "Et bøjet sugerør ligger halvt dækket i sandet.",
            "💡 90% af alt affald på strande er lavet af plastik."
        ),
        new Trash(
            "Plastikpose",
            "En plastikpose blafrer i vinden og sætter sig fast i tang.",
            "💡 Plastik på stranden kan ende i havets fødekæde – dyr kan tro, det er mad."
        ),
        new Trash(
            "Cigaretfilter",
            "Et cigaretskod er halvt begravet i sandet.",
            "💡 Hjælp med at holde stranden ren ved at smide affald i skraldespande og genbruge plast."
        )
    };

    private Random random = new Random();

    public void CollectTrash(string currentRoom)
    {
        if (currentRoom.ToLower() == "stranden")
        {
            Trash randomTrash = trashList[random.Next(trashList.Count)];
            Console.WriteLine($"🗑️ Du samler en {randomTrash.Name} op!");
            Console.WriteLine($"{randomTrash.Description}");
            Console.WriteLine($"{randomTrash.FunFact}\n");
        }
        else
        {
            Console.WriteLine("Godt gået! Der er ikke mere skrald at samle op på stranden for i dag. ");
        }
    }
}
