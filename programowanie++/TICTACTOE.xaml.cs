using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace programowanie__
{
    /// <summary>
    /// Interaction logic for TICTACTOE.xaml
    /// </summary>
    public partial class TICTACTOE : Window
    {
        public GameLogic gameLogic;



        public TICTACTOE()
        {

            InitializeComponent();
            gameLogic = new GameLogic();
            DataContext = gameLogic;
            gameLogic.PropertyChanged += UpdateButtons;
        }
        private void UpdateButtons(object sender, PropertyChangedEventArgs e)
        {
            for (int i = 0; i < itemsControl.Items.Count; i++)
            {
                var container = itemsControl.ItemContainerGenerator.ContainerFromIndex(i) as UIElement;

                if (container != null && gameLogic.GameField[i] != null)
                {
                    container.IsEnabled = false;
                }
            }
        }

        private void makeTurn(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            int index = itemsControl.ItemContainerGenerator.IndexFromContainer(VisualTreeHelper.GetParent(clickedButton));
            
            //MessageBox.Show("col:" + col + "\trow:" + row);
            string[] gameField = gameLogic.GameField;
            gameField[index] = (gameLogic.turnX == true) ? "X" : "O";
            string[] newField = (string[])gameField.Clone();

            gameLogic.GameField = newField;
            gameLogic.turnDone();

            if (gameLogic.checkWin())
            {
                MessageBox.Show("win " + ((gameLogic.turnX == true) ? "O" : "X"));
                gameLogic.restart();
            }
            if (gameLogic.turn == 9)
            {
                MessageBox.Show("Draw!");
                gameLogic.restart();
            }
        }

    }
}
