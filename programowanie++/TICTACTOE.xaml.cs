using System;
using System.Collections.Generic;
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

        public class GameLogic { 
            
            public string[,] gameField = new string[3,3];
            public bool turnX;
                
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
            }

            public bool checkWin() {
                for (int i = 0; i < 3; i++)
                {
                    if (gameField[i, 0] != "" && gameField[i, 0] == gameField[i, 1] && gameField[i, 1] == gameField[i, 2])
                        return true; // Winning row

                    if (gameField[0, i] != "" && gameField[0, i] == gameField[1, i] && gameField[1, i] == gameField[2, i])
                        return true; // Winning column
                }

                // Check diagonals for a win
                if (gameField[0, 0] != "" && gameField[0, 0] == gameField[1, 1] && gameField[1, 1] == gameField[2, 2])
                    return true; // Winning diagonal

                if (gameField[0, 2] != "" && gameField[0, 2] == gameField[1, 1] && gameField[1, 1] == gameField[2, 0])
                    return true; // Winning diagonal

                return false; // No winner yet
            }

        }

             
        public GameLogic gameLogic;
        
        private void CreateGrid()
        {
            gameLogic = new GameLogic();
            // Создаем новый Grid
            Grid grid = new Grid();

            // Добавляем строки и столбцы в сетку (3x3)
            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Добавляем кнопки в ячейки Grid
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Button button = new Button
                    {
                        Content = $"Button {row}-{col}",
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        IsEnabled = true,
                            
                    };
                    
                    button.Click += makeTurn;
                    Binding binding = new Binding(gameLogic.gameField[row, col]);

                    button.SetBinding(Button.ContentProperty, binding);
                    Grid.SetRow(button, row); // Устанавливаем строку для кнопки
                    Grid.SetColumn(button, col); // Устанавливаем столбец для кнопки
                    grid.Children.Add(button); // Добавляем кнопку в Grid
                }
            }

            // Добавляем созданный Grid на окно
            Content = grid;


        }

        private void makeTurn(object sender, RoutedEventArgs e)
        {
            Button bt = (Button)sender;
            int col = Grid.GetColumn(bt);
            int row = Grid.GetRow(bt);
            MessageBox.Show("col:" + col + "\trow:" + row);
            gameLogic.gameField[row, col] = (gameLogic.turnX == true) ? "X" : "O";
            gameLogic.turnDone();
            bt.IsEnabled = false;
            if (gameLogic.checkWin()) {
                MessageBox.Show("win " + ((gameLogic.turnX == true) ? "O":"X"));

            }
        }

        public TICTACTOE()
        {
            
            InitializeComponent();
            CreateGrid();
             
        }
    }
}
