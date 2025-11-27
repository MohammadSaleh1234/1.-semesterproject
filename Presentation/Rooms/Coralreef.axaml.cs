using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation;

namespace Avalonia.Rooms
{
    public partial class Coralreef : UserControl
    {
        public Coralreef()
        {
            InitializeComponent();
            GoQuizButton.Click += OnQuizClick;
        }
		
        private void OnQuizClick (object? sender, RoutedEventArgs e) {

            Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new CoralreefQuiz();
		
        }
    }
}