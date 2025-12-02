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
        private Game game;
        
        public Ocean()
        {
            InitializeComponent();
            
            GoQuizButton.Click += OnQuizClick;
            BoatButton.Click += OnBoatClick;
            
            Net1Button.Click += OnNetClick;
            Net2Button.Click += OnNetClick;
            Net3Button.Click += OnNetClick;
            Net4Button.Click += OnNetClick;
            Net5Button.Click += OnNetClick;

            HideNet();
            
            string result = Game.player.ExecuteCommand("show inventory");
            OutputTextInventory.Text = result;
        }
		
        private void OnQuizClick (object? sender, RoutedEventArgs e) {
            
            MainWindow.ActiveWindow.Content = new OceanQuiz();
		
        }

        private void OnBoatClick(object? sender, RoutedEventArgs e)
        {
            BoatButton.IsVisible = false;
            ShowNet();

        }

        private void OnNetClick(object? sender, RoutedEventArgs e)
        {
            
            
            if (sender is Button button)
            {
                button.IsVisible = false;
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