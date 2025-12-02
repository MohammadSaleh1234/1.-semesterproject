using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation; // if you need access to MainWindow

namespace Avalonia.Rooms
{
    public partial class CoralreefQuiz : UserControl
    {
        public CoralreefQuiz()
        {
            InitializeComponent();
            GoOceanButton.Click += OnOceanClick;
        }

        private void OnOceanClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.ActiveWindow.Content = new Ocean();
        }
    }
}