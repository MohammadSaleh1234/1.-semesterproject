using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation; // if you need access to MainWindow

namespace Avalonia.Rooms
{
    public partial class Entry : UserControl
    {
        
        private Context context;
        private CommandShowInventory inventoryCommand;
        
        
        public Entry()
        {
            InitializeComponent();
            GoBeachButton.Click += OnBeachClick;

        }

        private void OnBeachClick(object? sender, RoutedEventArgs e)
        {
            Game.player.ExecuteCommand("go beach");
            MainWindow.ActiveWindow.Content = new Beach();
            
        }
        
    }
}