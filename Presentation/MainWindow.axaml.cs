using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Rooms;
using Domain;
using System;

namespace Presentation
{
    public partial class MainWindow : Window
    {

        public static MainWindow ActiveWindow;
        
    public MainWindow()
    {
        InitializeComponent();
		ActiveWindow = this;
        MainContent.Content = new Entry();
    }
    
    }
}
