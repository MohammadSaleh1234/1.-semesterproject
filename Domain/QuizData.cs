using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class QuizQuestion
    {
        public string Question { get; set; }
        public string[] Answers { get; set; }   // A,B,C
        public int CorrectIndex { get; set; }   // 0,1,2
    }

    public static class QuizData
    {
        // ------------------- BEACH QUIZ -------------------
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


        // ------------------- CORAL QUIZ -------------------
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
            new QuizQuestion {
                Question = "How much of the world's oceans are protected as MPAs (Marine Protected Areas)?",
                Answers = new[]{ "Only about 10%", "A full 90%", "50%" },
                CorrectIndex = 0
                
            },
            new QuizQuestion {
                Question = "What percentage of coral reefs could disappear by 2050?",
                Answers = new[]{ "30%", "54%", "90%" },
                CorrectIndex = 2
            },
            new QuizQuestion {

                Question = "How can we protect coral reefs?",
                Answers = new[]{ "Throw more plastic", "Reduce CO2 & avoid pollution", "Catch more fish" },
                CorrectIndex = 1
            }
        };


        // ------------------- OCEAN QUIZ -------------------
        public static List<QuizQuestion> OceanQuiz = new()
        {
            new QuizQuestion {
                Question = "What percentage of fish in the sea are overfished?",
                Answers = new[]{ "10% - almost none", "30% - almost every third fish", "70% almost all fish" },
                CorrectIndex = 1
            },
            new QuizQuestion {
                Question = "How much waste ends up in the sea every day?",
                Answers = new[]{ "A handful of plastic bags", "1,440 trucks filled with waste", "50 swimming pools of trash" },
                CorrectIndex = 1
            },
            new QuizQuestion {
                Question = "Average of 13,000 plastic pieces per km² in ocean. What is it like?",
                Answers = new[]{ "Swimming in trash", "Crystal clear water", "Pool of gold coins" },
                CorrectIndex = 0
            },
            new QuizQuestion {
                Question = "Why do some people fish illegally?",
                Answers = new[]{ "Earn extra money", "Extra fish as pets", "Zoos want shark food" },
                CorrectIndex = 0
            },
            new QuizQuestion {
                Question = "What happens when turtles eat plastic bags?",
                Answers = new[]{ "Grow stronger", "Get sick and may die", "Use it as shield" },
                CorrectIndex = 1
            }
        };
    }
}

 