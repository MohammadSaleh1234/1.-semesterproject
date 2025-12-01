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
        private CommandShowInventory inventoryCommand;
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
            
            inventoryCommand = new CommandShowInventory();
            string result = inventoryCommand.Execute(context, "show", new string[] { "inventory" });
            OutputTextInventory.Text = result;
        }
		
        private void OnQuizClick (object? sender, RoutedEventArgs e) {

            Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new OceanQuiz();
		
        }

        private void OnBoatClick(object? sender, RoutedEventArgs e)
        {
            BoatButton.IsVisible = false;
            ShowNet();

        }

        private void OnNetClick(object? sender, RoutedEventArgs e)
        {
            if (sender is Button netButton)
            {
                netButton.IsVisible = false;
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