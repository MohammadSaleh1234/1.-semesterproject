using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Domain;
using System;

namespace Presentation
{
    public partial class MainWindow : Window
    {
        private Context context;
        private CommandGo goCommand;
        private CommandShowInventory inventoryCommand;
        private CommandTake takeCommand;

        private Tool bag;


        public MainWindow()
        {
            InitializeComponent();

            World world = new World();
            context = new Context(world.GetEntry());

            //commands
            goCommand = new CommandGo();
            inventoryCommand = new CommandShowInventory();
            takeCommand = new CommandTake();

            bag = new Tool("bag");
            Game.inventory.AddTool(bag);




            UpdateUI();


            //buttons
            ExitGameButton.Click += OnExitGameClicked;
            ShowInventoryButton.Click += OnShowInventoryClicked;
        }

        //updates on room change
        private void UpdateUI()
        {

            OutputTextBlock.Text = context.GetCurrent().Welcome();
            ExitsPanel.Children.Clear();

            foreach (string exit in context.GetCurrent().GetExits())
            {
                var button = new Button { Content = $"Go to {exit}" };

                void OnButtonClicked(object sender, RoutedEventArgs e){
                    string result = goCommand.Execute(context, "go", new string[] { exit });
                    OutputTextBlock.Text = result;
                    UpdateUI();
                }
                button.Click += OnButtonClicked;
                ExitsPanel.Children.Add(button);
            }
        }

        //open inventory method
        private void OnShowInventoryClicked(object? sender, RoutedEventArgs e)
        {
            inventoryCommand = new CommandShowInventory();
            string result = inventoryCommand.Execute(context, "show", new string[] { "inventory" });
            OutputTextInventory.Text = result;


            UpdateUI();

        }


        //close game method
        private void OnExitGameClicked(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
