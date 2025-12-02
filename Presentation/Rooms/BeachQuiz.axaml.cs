using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation; // if you need access to MainWindow

namespace Avalonia.Rooms
{
    public partial class BeachQuiz : UserControl
    {
        public BeachQuiz()
        {
            InitializeComponent();
            GoCoralButton.Click += OnCoralClick;
            
        }

        private void OnCoralClick(object? sender, RoutedEventArgs e)
        {   
			Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new Coralreef();
        }
    }
}