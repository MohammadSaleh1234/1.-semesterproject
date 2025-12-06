using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation;

namespace Avalonia.Rooms
{
    public partial class Beach : UserControl
    {
        
        public Beach()
        {
            InitializeComponent();
            GoQuizButton.IsVisible = false;
            OutputTextQuiz.IsVisible = false;
            
            GoQuizButton.Click += OnQuizClick;
            TrashbagButton.Click += OnTrashbagClick;
            
            Plastic1Button.Click += OnPlasticClick;
            Plastic2Button.Click += OnPlasticClick;
            Plastic3Button.Click += OnPlasticClick;
            Plastic4Button.Click += OnPlasticClick;
            Plastic5Button.Click += OnPlasticClick;
            
            
			OutputTextFact.Text = "The beach needs cleaning!";
            
            string result = Game.player.ExecuteCommand("show inventory");
            OutputTextInventory.Text = result;
        }
		
        private void OnQuizClick(object? sender, RoutedEventArgs e) 
        {
            Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new BeachQuiz();
        }

        private void OnTrashbagClick(object? sender, RoutedEventArgs e)
        {
            Game.player.ExecuteCommand("take Trashbag");
            
            string result = Game.player.ExecuteCommand("show inventory");
            OutputTextInventory.Text = result;
			TrashbagButton.IsVisible = false;
        }
        
        private void OnPlasticClick(object? sender, RoutedEventArgs e)
        {
            
            string result = Game.player.ExecuteCommand("take plastic");

            if (result == "fail")
            {
                OutputTextFact.Text = "You need a trashbag to collect plastic. \n Search for one in this area";
                return;
            }
            OutputTextFact.Text = result;
            
            if (sender is Button button)
            {
                button.IsVisible = false;
            }

            if (!Game.context.GetCurrent().items.ContainsKey("plastic")) // or use HasTrash()
            {
                GoQuizButton.IsVisible = true;
                OutputTextQuiz.IsVisible = true;
               
            }
        }
    }
}
