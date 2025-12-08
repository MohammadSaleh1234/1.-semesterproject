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

            //Highscore = beachQuiz.BeachScore();
            HighscoreText.Text = $"Highscore: {BeachQuiz.score + CoralQuiz.score + OceanQuiz.score } / 30 ";


        }

    

        private void OnQuitClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.ActiveWindow.Close();

        }

    }
}