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
            Button1.Click += OnButton1Click;

            Question2.IsVisible = false;
        }

        private void OnExitClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.ActiveWindow.Close();
        }

        private void OnButton1Click(object? sender, RoutedEventArgs e)
        {
            Question1.IsVisible = false;
            Question2.IsVisible = true;
            Button1.IsVisible = false;
        }
    }
}