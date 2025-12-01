using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Rooms;
using Domain;
using Presentation;

namespace Avalonia.Rooms
{
    public partial class Beach : UserControl
    {
	    private Context context;
	    private CommandShowInventory inventoryCommand;
	    
	    private Tool trashbag;
        public Beach()
        {
            InitializeComponent();
            
            //buttons
	        GoQuizButton.Click += OnQuizClick;
	        ToolButton.Click += OnToolClick;
	        
	        //tools in the room
			trashbag = new Tool("trashbag");
	        
	        //shows inventory when entering room
	        inventoryCommand = new CommandShowInventory();
	        string result = inventoryCommand.Execute(context, "show", new string[] { "inventory" });
	        OutputTextInventory.Text = result;

        }
		
		private void OnQuizClick (object? sender, RoutedEventArgs e) {

			Game.player.ExecuteCommand("go quiz");
			MainWindow.ActiveWindow.Content = new BeachQuiz();
		
       }
		
       private void OnToolClick(object? sender, RoutedEventArgs e)
       {
	       //add tool
	       Game.player.inventory.AddTool(trashbag);

	       //fjerner knappen efter man har trykket
	       ToolButton.IsVisible = false;
	       
	       //refresh inventory
	       inventoryCommand = new CommandShowInventory();
	       string result = inventoryCommand.Execute(context, "show", new string[] { "inventory" });
	       OutputTextInventory.Text = result;                                                  

            
       }
	}
}
