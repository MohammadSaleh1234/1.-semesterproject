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

	    private Game game;
	    
	    private Tool trashbag;
        public Beach()
        {
            InitializeComponent();

            OutputTextFact.IsVisible = false;
            
            //buttons
	        GoQuizButton.Click += OnQuizClick;
	        ToolButton.Click += OnToolClick;
	        
	        //buttons til plastic
	        Plastic1Button.Click += OnPlasticClick;
	        Plastic2Button.Click += OnPlasticClick;
	        Plastic3Button.Click += OnPlasticClick;
	        Plastic4Button.Click += OnPlasticClick;
	        Plastic5Button.Click += OnPlasticClick;
	        
	        //tools in the room
			trashbag = new Tool("trashbag");
	        
	        //shows inventory when entering room
	        string result = Game.player.ExecuteCommand("show inventory");
	        OutputTextInventory.Text = result;

        }
		
		private void OnQuizClick (object? sender, RoutedEventArgs e)
		{

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
	       string result = Game.player.ExecuteCommand("show inventory");
	       OutputTextInventory.Text = result;                                                  

            
       }

       private void OnPlasticClick(object? sender, RoutedEventArgs e)
       {
	       
	       string result = Game.player.ExecuteCommand("take plastic");
	       OutputTextFact.Text = result;
	       
	       if (sender is Button button)
	       {
		       button.IsVisible = false;
	       }
	       OutputTextFact.IsVisible = true;
	       
       }
	}
}
