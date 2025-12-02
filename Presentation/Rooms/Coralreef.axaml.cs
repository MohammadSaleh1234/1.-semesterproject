using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation;

namespace Avalonia.Rooms
{
    public partial class Coralreef : UserControl
    {
        private Context context;
        private CommandGo goCommand;
        private CommandShowInventory inventoryCommand;
        private CommandTake takeCommand;
        
        private Tool brush;
        
        public Coralreef()
        {
            InitializeComponent();
            
            //buttons
            GoQuizButton.Click += OnQuizClick;
            ToolButton.Click += OnToolClick;
            
            //tools
            brush = new Tool("brush");
            
            inventoryCommand = new CommandShowInventory();
            string result = inventoryCommand.Execute(context, "show", new string[] { "inventory" });
            OutputTextInventory.Text = result;
        }
		
        private void OnQuizClick (object? sender, RoutedEventArgs e) {
            
			Game.player.ExecuteCommand("go quiz");
            MainWindow.ActiveWindow.Content = new CoralreefQuiz();
		
        }

        private void OnToolClick(object? sender, RoutedEventArgs e)
        {
            //add tool
            Game.player.inventory.AddTool(brush);
            
            //refresh inventory
            inventoryCommand = new CommandShowInventory();
            string result = Game.player.ExecuteCommand("show inventory");
            OutputTextInventory.Text = result;
        }
    }
}