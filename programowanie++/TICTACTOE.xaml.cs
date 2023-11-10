using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;


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
