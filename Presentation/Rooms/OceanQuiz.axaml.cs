using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation; // if you need access to MainWindow

namespace Avalonia.Rooms
{
    public partial class OceanQuiz : UserControl
    {
        public OceanQuiz()
        {
            InitializeComponent();
            ExitButton.Click += OnExitClick;
        }

        private void OnExitClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.ActiveWindow.Close();
        }
    }
}