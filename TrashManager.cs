/* TrashManager.cs */

using System;
using System.Collections.Generic;

public class TrashManager
{
    // 🔥 Tællere for hvert område (sikrer sekventiel rækkefølge pr. rum)
    private int strandFunFactIndex = 0;
    private int coralReefFunFactIndex = 0;
    private int deepSeaFunFactIndex = 0;

    // =================================================================
    // LISTE 1: STRANDEN (5 FACTS)
    // =================================================================
    private List<Trash> beachTrashList = new List<Trash>()
    {
        // Item/Fun Fact 1
        new Trash(
            "Plastic bottle",
            "You find an empty plastic bottle in the sand.",
            "💡 Plastic takes hundreds of years to decompose! (400-500 years) That is even longer than i can spend eating french fries! Teehee"
        ),  
        // Item/Fun Fact 2
        new Trash(
            "Candywrapper",
            "A colorful candywrapper flies across the beach.",
            "💡 Did you know, that over 80% of all the waste in the ocean is from the surface?"
        ),
        // Item/Fun Fact 3
        new Trash(
            "Plastic straw",
            "A plastic straw lies half-covered in the sand." ,
            "💡 90% of marine waste on the beaches is plastic"
        ),
        // Item/Fun Fact 4
        new Trash(
            "Cigarette filter",
            "A cigarette lies half-buried in the sand.",
            "💡 Plastic on beaches can be absorbed into the oceans food chains"
        ),
        // Item/Fun Fact 5
        new Trash(
            "Plastic bag",
            "A plastic bag flutters in the wind, and gets stuck in some seaweed.",
            "💡 Help keeping the beaches clean by throwing waste into trash cans, and by recycling plastic"
        )
    };

    // =================================================================
    // LISTE 2: KORALREVET (5 FACTS)
    // =================================================================
    private List<Trash> coralReefTrashList = new List<Trash>()
    {
        // Item/Fun Fact 1
        new Trash(
            "Fishing net",
            "A piece of worn fishing net is stuck on a coral.",
            "💡 Did you know, that coral reefs are not made of plants, but rather consist of thousands of tiny living animals called coral polyps"
        ),
        // Item/Fun Fact 2
        new Trash(
            "Rusty can",
            "A rusty can lies among some sea anemones.",
            "💡 Did you know, that coral reefs only cover less than 1% of the sea floor, but they house over 25% of all sea life?"
        ),
        // Item/Fun Fact 3
        new Trash(
            "Plastic fragment",
            "A small white plastic fragment is wrapped around a coral branch.",
            "💡 Only about 10% of the worlds oceans, are protected as MPA (Marine Protected Areas) – the rest are vulnerable, and the sea life are completely unprotected."
        ),
        // Item/Fun Fact 4
        new Trash(
            "Old fishing line",
            "A long nylon line floats lazily above the reef.",
            "💡 Half of the worlds coral reefs have disappeared already, and up to 90% of coral reefs can disappear before 2050 without immediate help"
        ),
        // Item/Fun Fact 5
        new Trash(
            "Disposable glove",
            "A disposable glove lies trapped in the seaweed.",
            "💡 To protect the coral reefs, we can reduce our CO2 emission. Avoid polluting, and support sustainable fishing!"
        )
    };

    // =================================================================
    // LISTE 3: DYBHAVET (5 FACTS)
    // =================================================================
    private List<Trash> deepSeaTrashList = new List<Trash>()
    {
        // Item/Fun Fact 1
        new Trash(
            "Heavy rope",
            "A piece of thick, heavy rope lies at the bottom.",
            "💡 About 30% of fish in the world are overfished – that is like if someone is eating your snacks faster than you can buy new ones."
        ),
        // Item/Fun Fact 2
        new Trash(
            "Old boot",
            "You see the outline of an old boot.",
            "💡 Every minute, about a truckload of plastic ends up in the ocean - in a day, that is the equivalent of 1.440 trucks."
        ),
        // Item/Fun Fact 3
        new Trash(
            "Bottleneck",
            "A broken off bottleneck sticks out of the sediment.",
            "💡 There is on average 13.000 pieces of plastic waste per square kilometer in the ocean – it is like swimming in water filled with plastic bags and bottles."
        ),
        // Item/Fun Fact 4
        new Trash(
            "Net-fragment",
            "A heavy piece of net-fragment lies at the bottom.",
            "💡 Some fishermen get so excited about selling fishing that they catch way too many! But then the ocean will run out of fish friends, and the balance will fall!"
        ),
        // Item/Fun Fact 5
        new Trash(
            "Plastic bag",
            "A white plastic bag has descended from the surface.",
            "💡 Sea turtles often confuse plastic bags for jellyfish, which are their favorite food. But when they eat plastic, they can get sick and even die."
        )
    };

    // Hovedmetoden: Vælger den korrekte liste ud fra rummet
    public void CollectTrash(string currentRoomName)
    {
        currentRoomName = currentRoomName.ToLower();

        if (currentRoomName == "beach")
        {
            DisplaySequentialFact(beachTrashList, ref strandFunFactIndex);
        }
        else if (currentRoomName == "coralreef")
        {
            DisplaySequentialFact(coralReefTrashList, ref coralReefFunFactIndex);
        }
        else if (currentRoomName == "ocean")
        {
            DisplaySequentialFact(deepSeaTrashList, ref deepSeaFunFactIndex);
        }
    }

    // Hjælpemetoden: Håndterer den sekventielle visning
    private void DisplaySequentialFact(List<Trash> trashList, ref int funFactIndex)
    {

        Console.Clear();
        Game.context.GetCurrent().Welcome();
        if (trashList.Count == 0) return;

        int indexToShow = funFactIndex % trashList.Count;

        Trash currentTrash = trashList[indexToShow];

        Console.WriteLine();
        Console.WriteLine(currentTrash.Description);
        Console.WriteLine($"🗑️  You pick *{currentTrash.Name}* up!");
        Console.WriteLine();
        Console.WriteLine("*Fun Fact:* " + currentTrash.FunFact);
        Console.WriteLine();

        funFactIndex++;
    }
}
