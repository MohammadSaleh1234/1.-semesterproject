using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation;

namespace Avalonia.Rooms
{
    public partial class Titlescreen : UserControl
    {
        private Context context;
        private Tool scissor;
        private int ClickCounter;
        
        public Titlescreen()
        {
            InitializeComponent();
            QuitGameButton.Click += OnQuitClick;

            
        }

    

private void OnQuitClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.ActiveWindow.Close();

        }

    }
}