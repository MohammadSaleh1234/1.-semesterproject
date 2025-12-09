using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Domain;
using Presentation;
using System.Collections.Generic;


namespace Avalonia.Rooms
{
    public partial class OceanQuiz : UserControl
    {
        private readonly List<QuizQuestion> _questions;
        private int _index = 0;
        public static int score = 0;

        private readonly SolidColorBrush _defaultAnswerBrush =
            new(Color.Parse("#004080"));

        public OceanQuiz()
        {
            score = 0;
            InitializeComponent();

            _questions = QuizData.OceanQuiz;

            AnswerAButton.Click += OnAnswerClick;
            AnswerBButton.Click += OnAnswerClick;
            AnswerCButton.Click += OnAnswerClick;

            LoadQuestion();
        }

        private void LoadQuestion()
        {
            var q = _questions[_index];

            ResetButtons();

            QuestionText.Text = q.Question;
            AnswerAButton.Content = $"A: {q.Answers[0]}";
            AnswerBButton.Content = $"B: {q.Answers[1]}";
            AnswerCButton.Content = $"C: {q.Answers[2]}";
        }

        private void ResetButtons()
        {
            foreach (var btn in new[] { AnswerAButton, AnswerBButton, AnswerCButton })
            {
                btn.IsEnabled = true;
                btn.Background = _defaultAnswerBrush;
            }
        }

        private void OnAnswerClick(object? sender, RoutedEventArgs e)
        {
            if (sender is not Button btn) return;

            int chosen =
                btn == AnswerAButton ? 0 :
                btn == AnswerBButton ? 1 : 2;

            var q = _questions[_index];

            AnswerAButton.IsEnabled = AnswerBButton.IsEnabled = AnswerCButton.IsEnabled = false;

            if (chosen == q.CorrectIndex)
            {
                btn.Background = Brushes.Green;
               	score += 2;
            }
            else
            {
                btn.Background = Brushes.DarkRed;
                score = System.Math.Max(0, score - 1);

            }

            _index++;

            if (_index >= _questions.Count)
            {
                QuestionText.Text = $"Quiz Complete! Score: {score}";
                AnswerAButton.IsVisible = AnswerBButton.IsVisible = AnswerCButton.IsVisible = false;
                NextButton.IsVisible = true;
            }
            else
            {
                LoadQuestion();
            }
        }

        private void OnNextClick(object? sender, RoutedEventArgs e)
        {
            // >>> Edit destination view her <<<
            Game.player.ExecuteCommand("go titlescreen");

            MainWindow.ActiveWindow.Content = new Titlescreen(); // <-- skift til dit næste view
        }
    }
}
