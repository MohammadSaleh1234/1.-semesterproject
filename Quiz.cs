
class Quiz : Space
{

    public Quiz (String name) : base(name)
    {
    }

    public override void Welcome () {

        string[] questions =
        {
            "How long does it take for a plastic-bottle to decompose on the beach?",
            "What percentage of ocean-waste originates from the mainland?",
            "What percentage of marine waste on beaches is plastic?",
            "Why is plastic on the beach dangerous?",
            "What can children and young people do to help keep the beach clean?",
        };

        string[] answers =
        {
            "A. 10 Years \nB. 450 Years \nC. 100 Years",
            "A. 25% \nB. 50% \nC. 80%",
            "A. 90% \nB. 75% \nC. 54%",
            "A. You can trip over it \nB. It can enter the marine food chain \nC. It makes the sand less soft",
            "A. Let the tide take the waste away \nB. Throw waste in the trash can and recycle plastic \nC. Put waste in small piles on the beach",
        };

        int[] correctAnswers = { 1, 2, 0, 1, 1 }; // 0=A, 1=B, 2=C
        int playerScore = 0;

        Console.WriteLine("Welcome to the beach quiz! Test your knowledge about beach pollution! :)");

        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine();
            Console.WriteLine("Question " + (i + 1));
            Console.WriteLine(questions[i]);
            Console.WriteLine(answers[i]);

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

                if (answerIndex == correctAnswers[i])
                {
                    Console.WriteLine("Correct!");
                    playerScore++;
                    break; // move to next question
                }
                else
                {
                    Console.WriteLine("Wrong answer — try again.");
                    // loop repeats and asks the same question until correct
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("You completed the quiz!");
        Console.WriteLine("Your score is: " + playerScore + " / " + questions.Length);

        HashSet<string> exits = edges.Keys.ToHashSet();
        Console.WriteLine("Current exits are:");
        foreach (String exit in exits) {
            Console.WriteLine(" - "+exit);
        }
    }

    }

