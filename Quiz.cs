
class Quiz : Space
{

    public Quiz (String name) : base(name)
    {
    }

    public override void Welcome()
    {

        Dictionary<string, string> quizData = new Dictionary<string, string>()
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

       
        var random = new Random();
        var randomizedQuiz = quizData.ToList()
                             .OrderBy(x => random.Next())
                             .ToList();
        
    


        Console.WriteLine("Welcome to the beach quiz! Test your knowledge about beach pollution! :)");
        int playerScore = 0;
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

