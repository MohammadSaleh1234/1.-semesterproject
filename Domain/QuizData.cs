using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }   // A, B, C
        public int CorrectIndex { get; set; }   // 0,1,2
    }

    public static class QuizData
    {
        public static List<QuizQuestion> BeachQuiz = new()
        {
            new QuizQuestion {
                Question = "How long does it take for a plastic-bottle to decompose?",
                Answers = new[]{ "10 Years", "450 Years", "100 Years" },
                CorrectIndex = 1
            },
            new QuizQuestion {
                Question ="What percentage of ocean-waste originates from the mainland?",
                Answers = new[]{ "25%", "50%", "80%" },
                CorrectIndex = 2
            },
            new QuizQuestion {
                Question = "What percentage of marine waste on beaches is plastic?",
                Answers = new[]{ "90%", "75%", "54%" },
                CorrectIndex = 0
            },
            new QuizQuestion {
                Question = "Why is plastic on the beach dangerous?",
                Answers = new[]{ "You can trip over it", "It can enter the marine food chain", "It melts in sunlight" },
                CorrectIndex = 1
            },
            new QuizQuestion {
                Question = "What can children and young people do to keep the beach clean?",
                Answers = new[]{ "Let the tide take the waste", "Throw waste in bins", "Ignore it" },
                CorrectIndex = 1
            }
        };

        public static List<QuizQuestion> CoralQuiz = new()
        {
            new QuizQuestion {
                Question = "Are corals plants?",
                Answers = new[]{ "Yes", "No", "Maybe" },
                CorrectIndex = 1
            },
            new QuizQuestion {
                Question = "Coral reefs cover less than 1% of the ocean floor. What % of marine life do they support?",
                Answers = new[]{ "50%", "5%", "25%" },
                CorrectIndex = 2
            },
            // ... osv. (du ved at jeg kan overføre ALLE dine spørgsmål 1:1)
        };

        public static List<QuizQuestion> OceanQuiz = new()
        {
            new QuizQuestion {
                Question = "What percentage of fish in the sea are overfished?",
                Answers = new[]{ "10%", "30%", "70%" },
                CorrectIndex = 1
            },
            // ... resten af dine ocean-spørgsmål
        };
    }
}
