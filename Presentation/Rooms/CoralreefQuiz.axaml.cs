using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Domain;
using Presentation;            // for MainWindow
using System.Collections.Generic;

namespace Avalonia.Rooms
{
    public partial class CoralQuiz : UserControl
    {
        private readonly List<QuizQuestion> _questions;
        private int _index = 0;
        public static int score = 0;
        public int coralreefScore = 0;

        // standard-farve til svar-knapper (samme som i XAML)
        private readonly SolidColorBrush _defaultAnswerBrush =
            new SolidColorBrush(Color.Parse("#004080"));

        public CoralQuiz()
        {

            score = 0;
            InitializeComponent();

            // hent dine beach-spørgsmål fra Domain.QuizData
            _questions = QuizData.CoralQuiz;

            // tilmeld klik-events
            AnswerAButton.Click += OnAnswerClick;
            AnswerBButton.Click += OnAnswerClick;
            AnswerCButton.Click += OnAnswerClick;

            // start med første spørgsmål
            LoadQuestion();
        }

        /// <summary>
        /// Loader det aktuelle spørgsmål og nulstiller knapperne.
        /// </summary>
        private void LoadQuestion()
        {
            var q = _questions[_index];

            ResetAnswerButtons();

            QuestionText.Text = q.Question;
            AnswerAButton.Content = $"A: {q.Answers[0]}";
            AnswerBButton.Content = $"B: {q.Answers[1]}";
            AnswerCButton.Content = $"C: {q.Answers[2]}";
        }

        /// <summary>
        /// Nulstiller farve og aktivering på alle svar-knapper.
        /// </summary>
        private void ResetAnswerButtons()
        {
            foreach (var btn in new[] { AnswerAButton, AnswerBButton, AnswerCButton })
            {
                btn.IsEnabled = true;
                btn.Background = _defaultAnswerBrush;
            }
        }

private void OnAnswerClick(object? sender, RoutedEventArgs e)
{
    if (sender is not Button btn)
        return;

    int chosenIndex =
        btn == AnswerAButton ? 0 :
        btn == AnswerBButton ? 1 : 2;

    var current = _questions[_index];

    // Lås knapper
    AnswerAButton.IsEnabled = AnswerBButton.IsEnabled = AnswerCButton.IsEnabled = false;

    // Farver + score
    if (chosenIndex == current.CorrectIndex)
    {
        btn.Background = Brushes.Green;
        score += 2;
    }
    else
    {
        btn.Background = Brushes.DarkRed;
        if (score > 0)
            score--;
    }

    // Gør klar til næste spørgsmål (men gør det først ved klik på Continue)
    _index++;

    // Hvis vi er færdige, så vis quiz-slut
    if (_index >= _questions.Count)
    {
             
                // quiz færdig
                QuestionText.Text =
                    $"Quiz completed! Your score: {score}";

                AnswerAButton.IsVisible =
                    AnswerBButton.IsVisible =
                    AnswerCButton.IsVisible = false;

                NextButton.IsVisible = true;   // nu kan spilleren videre
            }
            else
            {
                // næste spørgsmål
                LoadQuestion();
            }
}


        /// <summary>
        /// Kaldes når Continue-knappen trykkes efter quiz-slut.
        /// </summary>
       private void OnNextClick(object? sender, RoutedEventArgs e)
{
    // hvis der stadig er flere spørgsmål:
    if (_index < _questions.Count)
    {
        ResetAnswerButtons();
        LoadQuestion();
        NextButton.IsVisible = false;
        return;
    }

    // ellers er quiz helt slut → gå videre
    Game.player.ExecuteCommand("go ocean");
    MainWindow.ActiveWindow.Content = new Ocean();
}

       
    }
}