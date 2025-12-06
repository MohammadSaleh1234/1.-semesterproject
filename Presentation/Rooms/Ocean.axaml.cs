using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation;

namespace Avalonia.Rooms
{
    public partial class Ocean : UserControl
    {
        private Context context;
        private Tool scissor;
        private int ClickCounter;
        
        public Ocean()
        {
            InitializeComponent();
            GoQuizButton.IsVisible = false;
			ScissorButton.IsVisible = false;
			OutputTextQuiz.IsVisible = false;
            
            GoQuizButton.Click += OnQuizClick;
            BoatButton.Click += OnBoatClick;
            ScissorButton.Click += OnScissorClick;
            
            Net1Button.Click += OnNetClick;
            Net2Button.Click += OnNetClick;
            Net3Button.Click += OnNetClick;
            Net4Button.Click += OnNetClick;
            Net5Button.Click += OnNetClick;

            HideNet();
            
            scissor = new Tool("Scissors");
            ClickCounter = 0;
            
            string result = Game.player.ExecuteCommand("show inventory");
            OutputTextInventory.Text = result;

            OutputTextFact.Text = "Activate your sirens to scare away the rogue vessels!";
            
        }
		
        private void OnQuizClick (object? sender, RoutedEventArgs e) {
            
			Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new OceanQuiz();
		
        }

        private void OnBoatClick(object? sender, RoutedEventArgs e)
        {

            if (ClickCounter < 1)
            {
                Game.player.ExecuteCommand("activate sirens");
                //BoatButton.IsVisible = false;
                ShowNet();
                ScissorButton.IsVisible = true;
                OutputTextFact.Text =
                    "The rogue vessels sail away but leave behind their fishing nets \n Cut the fishing nets using a pair of scissors";
                
                ClickCounter++;
				RogueBoatLeft.IsVisible = false;
				RogueBoatRight.IsVisible = false;
            }
            
        }

         void OnScissorClick(object? sender, RoutedEventArgs e)
         { 
             Game.player.ExecuteCommand("take Scissors");
             ScissorButton.IsVisible = false;
		     
             
             string result = Game.player.ExecuteCommand("show inventory");
             OutputTextInventory.Text = result;       
        }

        private void OnNetClick(object? sender, RoutedEventArgs e)
        {
            
            string result = Game.player.ExecuteCommand("cut net");
			if (result == "fail")
            {
                OutputTextFact.Text = "You need scissors to cut the fishing net. \n Search for them in this area";
                return;
            }

            OutputTextFact.Text = result;
            
            if (sender is Button button)
            {
                button.IsVisible = false;
            }

            if (!Game.context.GetCurrent().items.ContainsKey("Fishing net"))
            {
                GoQuizButton.IsVisible = true;
				OutputTextQuiz.IsVisible = true;
            }
        }

        private void HideNet()
        {
            Net1Button.IsVisible = false;
            Net2Button.IsVisible = false;
            Net3Button.IsVisible = false;
            Net4Button.IsVisible = false;
            Net5Button.IsVisible = false;
        }

        private void ShowNet()
        {
            Net1Button.IsVisible = true;
            Net2Button.IsVisible = true;
            Net3Button.IsVisible = true;
            Net4Button.IsVisible = true;
            Net5Button.IsVisible = true;
        }
    }
}