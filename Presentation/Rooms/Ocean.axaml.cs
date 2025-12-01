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
            
            inventoryCommand = new CommandShowInventory();
            string result = inventoryCommand.Execute(context, "show", new string[] { "inventory" });
            OutputTextInventory.Text = result;
        }
		
        private void OnQuizClick (object? sender, RoutedEventArgs e) {

            Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new OceanQuiz();
		
        }
    }
}