using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation;

namespace Avalonia.Rooms
{
    public partial class Titlescreen : UserControl
    {
     
        public Titlescreen()
        {
            InitializeComponent();
            QuitGameButton.Click += OnQuitClick;
            PlayAgainButton.Click += OnPlayAgainClick;

            //Highscore = beachQuiz.BeachScore();
            HighscoreText.Text = $"Highscore: {BeachQuiz.score + CoralQuiz.score + OceanQuiz.score } / 30 ";


        }

    

        private void OnQuitClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.ActiveWindow.Close();

        }

       private void OnPlayAgainClick(object? sender, RoutedEventArgs e)
        {
            Game.NewGame();
            MainWindow.ActiveWindow.Content = new Entry();
        }
    }
}