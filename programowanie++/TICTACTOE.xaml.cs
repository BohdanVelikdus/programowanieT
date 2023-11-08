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


namespace programowanie__
{
    /// <summary>
    /// Interaction logic for TICTACTOE.xaml
    /// </summary>
    public partial class TICTACTOE : Window
    {
        //
        //
        //
        //
        //
        //
        ///
        //
        //
        //
        //
        //



        public class GameLogic { 
            
            public string[,] gameField = new string[3,3];
            public bool turnX;
            public int turn = 0;
            public GameLogic() {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        gameField[row, col] = "";
                    }
                }
                turnX = true;
            }

            public void turnDone() {
                turnX = !turnX;
                turn++;
            }

            public bool checkWin() {
                for (int i = 0; i < 3; i++)
                {
                    if (gameField[i, 0] != "" && gameField[i, 0] == gameField[i, 1] && gameField[i, 1] == gameField[i, 2])
                        return true;

                    if (gameField[0, i] != "" && gameField[0, i] == gameField[1, i] && gameField[1, i] == gameField[2, i])
                        return true; 
                }

     
                if (gameField[0, 0] != "" && gameField[0, 0] == gameField[1, 1] && gameField[1, 1] == gameField[2, 2])
                    return true; 

                if (gameField[0, 2] != "" && gameField[0, 2] == gameField[1, 1] && gameField[1, 1] == gameField[2, 0])
                    return true; 

                
                return false; 
            }

            //public string getValue//(/*int row, int col*/) {
            //return gameField[row, col]; 
            //return "/_/";
            //}

            public int row;
            public int col;

            public string getValue
            {
                get {
                    return gameField[row, col];
                }
                set { 
                    
                }
            }


        }

             
        public GameLogic gameLogic;
        
        private void CreateGrid()
        {
            gameLogic = new GameLogic();

            Grid grid = new Grid();


            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }


            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    gameLogic.row = row;
                    gameLogic.col = col;
                    Button button = new Button
                    {
                        //Content = $"Button {row}-{col}",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        IsEnabled = true,
                        Content = {Binding gameLogic.getValue}
                    };
                    button.Click += makeTurn;
                    //gameLogic.row = row;
                    //gameLogic.col = col;
                    //Binding binding = new Binding("getValue");

                    //binding.Source = gameLogic;

                    //button.SetBinding(ContentProperty, binding);
                    //button.SetBinding(ContentProperty, binding);

                    Grid.SetRow(button, row); 
                    Grid.SetColumn(button, col);
                    grid.Children.Add(button); 
                }
            }


            Content = grid;


        }

        private void makeTurn(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            int col = Grid.GetColumn(bt);
            int row = Grid.GetRow(bt);
            //MessageBox.Show("col:" + col + "\trow:" + row);
            gameLogic.gameField[row, col] = (gameLogic.turnX == true) ? "X" : "O";
            gameLogic.turnDone();
            bt.IsEnabled = false;
            if (gameLogic.checkWin()) {
                MessageBox.Show("win " + ((gameLogic.turnX == true) ? "O":"X"));

            }
            if (gameLogic.turn == 9) {
                MessageBox.Show("Draw!");
            }
        }

        public TICTACTOE()
        {
            
            InitializeComponent();
            CreateGrid();
            //
        }
    }
}
