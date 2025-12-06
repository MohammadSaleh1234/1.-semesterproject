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
            GoQuizButton.IsVisible = false;
            OutputTextQuiz.IsVisible = false;
            
            GoQuizButton.Click += OnQuizClick;
            ToolButton.Click += OnToolClick;
            
            Trash1Button.Click += OnTrashClick;
            Trash2Button.Click += OnTrashClick;
            Trash3Button.Click += OnTrashClick;
            Trash4Button.Click += OnTrashClick;
            Trash5Button.Click += OnTrashClick;
            
            BackgroundAfter.IsVisible = false;
            
			OutputTextFact.Text = "The coralreef needs cleaning!";
            
            string result = Game.player.ExecuteCommand("show inventory");
            OutputTextInventory.Text = result;
        }
		
        private void OnQuizClick(object? sender, RoutedEventArgs e) 
        {
            Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new CoralreefQuiz();
        }

        private void OnToolClick(object? sender, RoutedEventArgs e)
        {
            Game.player.ExecuteCommand("take Brush");
            
            string result = Game.player.ExecuteCommand("show inventory");
            OutputTextInventory.Text = result;
			ToolButton.IsVisible = false;
        }
        
        private void OnTrashClick(object? sender, RoutedEventArgs e)
        {
   			string result = Game.player.ExecuteCommand("clean coral");

    		if (result == "fail")
    		{
        		OutputTextFact.Text = "\nYou need a brush to clean the corals.\nSearch for one in this area";
        		return;
    		}
    		OutputTextFact.Text = result;

    		if (sender is Button button)
   			{
        		button.IsVisible = false;
    		}

   			if (!Game.context.GetCurrent().items.ContainsKey("coral"))
    		{
        		GoQuizButton.IsVisible = true;
        		OutputTextQuiz.IsVisible = true;
        		BackgroundBefore.IsVisible = false;
        		BackgroundAfter.IsVisible = true;
    		}
        }
    }
}
