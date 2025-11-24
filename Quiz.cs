
public class Quiz : Space
{
    public static int playerScore = 0;
    public Quiz (string name, string description) : base(name, description) {}
  
    public override void Welcome()
    {

        Dictionary<string, string> quizData = new Dictionary<string, string>() //dictionary med spm og svar under
{
    { "How long does it take for a plastic-bottle to decompose?",
      "A. 10 Years \nB. 450 Years \nC. 100 Years" },

    { "What percentage of ocean-waste originates from the mainland?",
      "A. 25% \nB. 50% \nC. 80%" },

    { "What percentage of marine waste on beaches is plastic?",
      "A. 90% \nB. 75% \nC. 54%" },

    { "Why is plastic on the beach dangerous?",
      "A. You can trip over it \nB. It can enter the marine food chain \nC. It melts in sunlight" },

    { "What can children and young people do to help keep the beach clean?",
      "A. Let the tide take the waste away \nB. Throw waste in bins \nC. Ignore it" }
};

var answerKey = new Dictionary<string, int>
{
    { "How long does it take for a plastic-bottle to decompose?", 1 }, // B
    { "What percentage of ocean-waste originates from the mainland?", 2 }, // C
    { "What percentage of marine waste on beaches is plastic?", 0 }, // A
    { "Why is plastic on the beach dangerous?", 1 }, // B
    { "What can children and young people do to help keep the beach clean?", 1 } // B
};

       
        var random = new Random(); //tilfældiggører spørgsmålenes rækkefølge
        var randomizedQuiz = quizData.ToList()
                             .OrderBy(x => random.Next())
                             .ToList();
        
    
        Console.Clear();

        Console.WriteLine("Welcome to the beach quiz! Test your knowledge about beach pollution! :)");
    
        int questionNumber = 1;
        foreach (var entry in randomizedQuiz)
        {
            Console.WriteLine();
            Console.WriteLine("Question " + questionNumber);
            Console.WriteLine(entry.Key);
            Console.WriteLine(entry.Value);

            while (true)
            {
                Console.Write("Please enter your answer ('A','B', or 'C'): ");
                string playerAnswer = Console.ReadLine();

                if (playerAnswer == "exit"){
                    Game.player.ExecuteCommand(playerAnswer);
                    return;
                }

                if (string.IsNullOrWhiteSpace(playerAnswer))
                {
                    Console.WriteLine("Please enter A, B or C.");
                    continue;
                }

                char c = char.ToUpperInvariant(playerAnswer.Trim()[0]);
                int answerIndex;
                if (c == 'A') answerIndex = 0;
                else if (c == 'B') answerIndex = 1;
                else if (c == 'C') answerIndex = 2;
                else
                {
                    Console.WriteLine("Invalid input. Enter A, B or C.");
                    continue;
                }

                int originalIndex = quizData.Keys.ToList().IndexOf(entry.Key); //matcher spm til svar

                if (answerIndex == answerKey[entry.Key])
                {
                    Console.WriteLine("Correct! You gain 2 points!");
                    playerScore += 2;
                    break; // move to next question
                }
                else
                {

                    Console.WriteLine("Wrong answer, you lose 1 point");
                    playerScore--;
                    playerScore = Math.Max(0, playerScore);
                    break;
                    // loop repeats and asks the same question until correct
                }
            }
             questionNumber++;
            
        }

        Console.WriteLine();
        Console.WriteLine("You completed the quiz!");
        Console.WriteLine("Your score is: " + playerScore + " / " + quizData.Count * 2);

        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");
        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
    }
    

}




public class Quiz2 : Space
{
    public static int playerScore = 0;
    public Quiz2(String name, string description) : base(name, description) {}

    public override void Welcome()
    {

        Dictionary<string, string> quizData = new Dictionary<string, string>()
{
    { "Are corals plants?",
      "A. Yes \nB. No \nC. Maybe" },

    { "Coral reefs cover less than 1% of the ocean floor, but what percentage of marine life do they support?",
      "A. 50% \nB. 5% \nC. 25%" },

    { "How much of the world's oceans are protected as MPAs (Marine Protected Areas)?",
      "A. Only about 10% \nB. A full 90% \nC. 50%" },

    { "What percentage of the world's coral reefs could disappear by 2050 without intervention?",
      "A. 30 \nB. 54 \nC. 90" },

    { "What can we do to protect coral reefs?",
      "A. Throw more plastic into the sea so the fish have something to play with \nB. Reduce CO2 emissions and avoid pollution Avoid pollution and support sustainable fishing \nC. Catch more fish to stop them from destroying coral reefs" }
};

        var answerKey = new Dictionary<string, int>
{
    { "Are corals plants?", 1 }, // B
    { "Coral reefs cover less than 1% of the ocean floor, but what percentage of marine life do they support?", 2 }, // C
    { "How much of the world's oceans are protected as MPAs (Marine Protected Areas)?", 0 }, // A
    { "What percentage of the world's coral reefs could disappear by 2050 without intervention?", 2 }, // C
    { "What can we do to protect coral reefs?", 1 } // B
};


        var random = new Random();
        var randomizedQuiz = quizData.ToList()
                             .OrderBy(x => random.Next())
                             .ToList();



        Console.Clear();
        Console.WriteLine("Welcome to the coral quiz! Test your knowledge about coralreef pollution! :)");

        int questionNumber = 1;
        foreach (var entry in randomizedQuiz)
        {
            Console.WriteLine();
            Console.WriteLine("Question " + questionNumber);
            Console.WriteLine(entry.Key);
            Console.WriteLine(entry.Value);

            while (true)
            {
                Console.Write("Please enter your answer ('A','B', or 'C'): ");
                string playerAnswer = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerAnswer))
                {
                    Console.WriteLine("Please enter A, B or C.");
                    continue;
                }

                char c = char.ToUpperInvariant(playerAnswer.Trim()[0]);
                int answerIndex;
                if (c == 'A') answerIndex = 0;
                else if (c == 'B') answerIndex = 1;
                else if (c == 'C') answerIndex = 2;
                else
                {
                    Console.WriteLine("Invalid input. Enter A, B or C.");
                    continue;
                }

                int originalIndex = quizData.Keys.ToList().IndexOf(entry.Key); //matcher spm til svar

                if (answerIndex == answerKey[entry.Key])
                {
                    Console.WriteLine("Correct! You gain 2 points!");
                    playerScore += 2;
                    break; // move to next question
                }
                else
                {

                    Console.WriteLine("Wrong answer, you lose 1 point");
                    playerScore--;
                    playerScore = Math.Max(0, playerScore);
                    break;
                    // loop repeats and asks the same question until correct
                }
            }
            questionNumber++;

        }

        Console.WriteLine();
        Console.WriteLine("You completed the quiz!");
        Console.WriteLine("Your score is: " + playerScore + " / " + quizData.Count * 2);

        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");
        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
    }


}


public class Quiz3 : Space
{
    public static int playerScore = 0;
    public Quiz3 (String name, string description) : base(name, description) {}

    public override void Welcome()
    {

        Dictionary<string, string> quizData = new Dictionary<string, string>()
{
    { "What percentage of fish in the sea are overfished?",
      "A. 10% - almost none  \nB. 30% - almost every third fish  \nC. 70% almost all fish" },

    { "How much waste ends up in the sea every day?",
      "A. A handful of plastic bags  \nB. 1,440 trucks filled with waste  \nC. Enough plastic to fill 50 swimming pools in one day" },

    { "There is an average of 13,000 pieces of plastic waste per square kilometer in the ocean what can this be compared to?",
      "A. Like swimming in water filled with bags, bottles, and straws. \nB. Like bathing in crystal clear water without a single flaw. \nC. Like diving in a swimming pool filled with gold coins." },

    { "Why do some people fish illegally?",
      "A. Some become a little too enthusiastic about fishing to earn extra money \nB. Because some people want extra fish as pets \nC. Because illegal zoos want extra fish for their sharks" },

    { "What often happens when a turtle mistakes a plastic bag for a jellyfish and eats it?",
      "A. It gets extra energy and becomes stronger \nB.  It gets plastic in its stomach and can become sick or die \nC. It uses the bag as a shield against sharks" }
};

var answerKey = new Dictionary<string, int>
{
    { "What percentage of fish in the sea are overfished?", 1 }, // B
    { "How much waste ends up in the sea every day?", 1 }, // B
    { "There is an average of 13,000 pieces of plastic waste per square kilometer in the ocean what can this be compared to?", 0 }, // A
    { "Why do some people fish illegally?", 0 }, // A
    { "What often happens when a turtle mistakes a plastic bag for a jellyfish and eats it?", 1 } // B
};

       
        var random = new Random();
        var randomizedQuiz = quizData.ToList()
                             .OrderBy(x => random.Next())
                             .ToList();
        
    

        Console.Clear();
        Console.WriteLine("Welcome to the ocean quiz! Test your knowledge about ocean pollution! :)");
        int questionNumber = 1;
        foreach (var entry in randomizedQuiz)
        {
            Console.WriteLine();
            Console.WriteLine("Question " + questionNumber);
            Console.WriteLine(entry.Key);
            Console.WriteLine(entry.Value);

            while (true)
            {
                Console.Write("Please enter your answer ('A','B', or 'C'): ");
                string playerAnswer = Console.ReadLine();
                if (playerAnswer == "exit"){
                    Game.player.ExecuteCommand(playerAnswer);
                    return;
                }
                if (string.IsNullOrWhiteSpace(playerAnswer))
                {
                    Console.WriteLine("Please enter A, B or C.");
                    continue;
                }

                char c = char.ToUpperInvariant(playerAnswer.Trim()[0]);
                int answerIndex;
                if (c == 'A') answerIndex = 0;
                else if (c == 'B') answerIndex = 1;
                else if (c == 'C') answerIndex = 2;
                else
                {
                    Console.WriteLine("Invalid input. Enter A, B or C.");
                    continue;
                }

                int originalIndex = quizData.Keys.ToList().IndexOf(entry.Key); //matcher spm til svar

                if (answerIndex == answerKey[entry.Key])
                {
                    Console.WriteLine("Correct! You gain 2 points!");
                    playerScore += 2;
                    break; // move to next question
                }
                else
                {

                    Console.WriteLine("Wrong answer, you lose 1 point");
                    playerScore--;
                    playerScore = Math.Max(0, playerScore);
                    break;
                    // loop repeats and asks the same question until correct
                }
            }
            questionNumber++;

        }

        

        Console.WriteLine();
        Console.WriteLine("You completed the quiz!");
        Console.WriteLine("Your score is: " + playerScore + " / " + quizData.Count * 2);
       Console.WriteLine("Your overall highscore is: " + Game.player.highscore(Quiz.playerScore, Quiz2.playerScore, Quiz3.playerScore) + " / 30");

        HashSet<string> exits = edges.Keys.ToHashSet();
    
        foreach (String exit in exits)
        {
            Console.WriteLine(" - " + exit);
        }
    }
    

}
