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
            "Plastikflaske",
            "Du finder en tom plastikflaske i sandet.",
            "💡 Plastik tager flere hundrede år at nedbryde! (400-500 år) Det er længere tid, end jeg kan bruge på at spise pomfritter! HaHa!"
        ),
        // Item/Fun Fact 2
        new Trash(
            "Slikpapir",
            "Et farverigt slikpapir flyver hen over stranden.",
            "💡 Vidste du, at over 80% af alt affald i havet kommer fra landjorden?"
        ),
        // Item/Fun Fact 3
        new Trash(
            "Plastiksugerør",
            "Et bøjet sugerør ligger halvt dækket i sandet.",
            "💡 90% af marine affald på strande er plastik"
        ),
        // Item/Fun Fact 4
        new Trash(
            "Cigaretfilter",
            "Et cigaretskod er halvt begravet i sandet.",
            "💡 Plastik på stranden kan optages i havets fødekæde"
        ),
        // Item/Fun Fact 5
        new Trash(
            "Plastikpose",
            "En plastikpose blafrer i vinden og sætter sig fast i tang.",
            "💡 Hjælp med at holde stranden ren ved at smide affald i skraldespande og genbruge plast"
        )
    };

    // =================================================================
    // LISTE 2: KORALREVET (5 FACTS)
    // =================================================================
    private List<Trash> coralReefTrashList = new List<Trash>()
    {
        // Item/Fun Fact 1
        new Trash(
            "Fiskenet-stykke",
            "Et stykke slidt fiskenet hænger fast i korallen.",
            "💡 Vidste du, at koralrevet ikke er en plante, men består af tusindvis af små levende dyr kaldet koralpolypper"
        ),
        // Item/Fun Fact 2
        new Trash(
            "Rusten dåse",
            "En rusten dåse ligger mellem anemoner.",
            "💡 Vidste du, at koralrev kun dækker mindre end 1 % af havbunden, men de huser over 25 % af alt havliv?"
        ),
        // Item/Fun Fact 3
        new Trash(
            "Plastikfragment",
            "Et lille, hvidt plastikfragment er svøbt om en koralgren.",
            "💡 Kun ca. 10% af verdenshavene er beskyttet som MPA (Marine Protected Areas) – resten er som at spille uden skjold, hvor havdyrene står helt ubeskyttede."
        ),
        // Item/Fun Fact 4
        new Trash(
            "Gammel line",
            "En lang nylonline svæver dovent over revet.",
            "💡 Halvdelen af verdens koralrev er allerede forsvundet, og op til 90% af koralrev kan forsvinde inden 2050 uden øjeblikkelig hjælp"
        ),
        // Item/Fun Fact 5
        new Trash(
            "Engangshandske",
            "En engangshandske ligger fanget i tangen.",
            "💡 For at beskytte koralrev kan vi reducere co2 udledning, undgå forurening og støtte bæredygtig fiskeri"
        )
    };

    // =================================================================
    // LISTE 3: DYBHAVET (5 FACTS)
    // =================================================================
    private List<Trash> deepSeaTrashList = new List<Trash>()
    {
        // Item/Fun Fact 1
        new Trash(
            "Tungt reb",
            "Et stykke tykt, tungt reb ligger på bunden.",
            "💡 Cirka 30% af fiskene i verden bliver overfisket – det er som hvis nogen spiser dine snacks hurtigere, end du kunne købe nye."
        ),
        // Item/Fun Fact 2
        new Trash(
            "Gammel støvle",
            "Du ser omridset af en gammel gummistøvle.",
            "💡 Hvert minut ryger der en hel lastbil af plast ud i havet - på en dag svarer det til 1.440 lastbiler."
        ),
        // Item/Fun Fact 3
        new Trash(
            "Flaske-hals",
            "En knækket flaske-hals stikker op af sedimentet.",
            "💡 Der er i gennemsnit 13.000 stykker plastikaffald pr. kvadratkilometer i havet – det er som at svømme i vand fyldt med plastikposer og flasker."
        ),
        // Item/Fun Fact 4
        new Trash(
            "Net-fragment",
            "Et lille, tungt net-fragment ligger på bunden.",
            "💡 Nogle fiskere bliver så fiske-glade, at de fanger alt for mange fisk! For at tjene penge. Men så løber havet tør for fiskevenner, og balancen vælter!"
        ),
        // Item/Fun Fact 5
        new Trash(
            "Plastikpose",
            "En hvid plastikpose er dalet ned fra overfladen.",
            "💡 Skildpadder forveksler ofte plastikposer med vandmænd, som er deres livret. Men når de spiser plastik i stedet for rigtig mad, kan de blive syge eller endda dø."
        )
    };

    // Hovedmetoden: Vælger den korrekte liste ud fra rummet
    public void CollectTrash(string currentRoomName)
    {
        currentRoomName = currentRoomName.ToLower();

        if (currentRoomName == "strand")
        {
            DisplaySequentialFact(beachTrashList, ref strandFunFactIndex);
        }
        else if (currentRoomName == "coralrevet")
        {
            DisplaySequentialFact(coralReefTrashList, ref coralReefFunFactIndex);
        }
        else if (currentRoomName == "dybhavet")
        {
            DisplaySequentialFact(deepSeaTrashList, ref deepSeaFunFactIndex);
        }
    }

    // Hjælpemetoden: Håndterer den sekventielle visning
    private void DisplaySequentialFact(List<Trash> trashList, ref int funFactIndex)
    {
        if (trashList.Count == 0) return;

        int indexToShow = funFactIndex % trashList.Count;

        Trash currentTrash = trashList[indexToShow];

        Console.WriteLine($"🗑️ Du samler en *{currentTrash.Name}* op!");
        Console.WriteLine(currentTrash.Description);
        Console.WriteLine("*Fun Fact:* " + currentTrash.FunFact);
        Console.WriteLine();

        funFactIndex++;
    }
}
