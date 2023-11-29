using System.ComponentModel;
using System.Linq;

namespace programowanie__
{
    public class GameLogic : INotifyPropertyChanged
    {
        public string[] gameField = new string[9];
        public bool turnX;
        public GameLogic()
        {
            turnX = true;
        }
        public void turnDone()
        {
            turnX = !turnX;
        }
        public void restart()
        {
            GameField = new string[9];
        }
        public bool checkWin()
        {
            string[,] gameField2D = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameField2D[i, j] = gameField[i * 3 + j];
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (gameField2D[i, 0] != null && gameField2D[i, 0] == gameField2D[i, 1] && gameField2D[i, 1] == gameField2D[i, 2])
                    return true;

                if (gameField2D[0, i] != null && gameField2D[0, i] == gameField2D[1, i] && gameField2D[1, i] == gameField2D[2, i])
                    return true;
            }
            if (gameField2D[0, 0] != null && gameField2D[0, 0] == gameField2D[1, 1] && gameField2D[1, 1] == gameField2D[2, 2])
                return true;

            if (gameField2D[0, 2] != null && gameField2D[0, 2] == gameField2D[1, 1] && gameField2D[1, 1] == gameField2D[2, 0])
                return true;
            return false;
        }
        public int turn { get { return gameField.Count(s => s != null); } }
        public string[] GameField
        {
            get { return gameField; }
            set
            {
                gameField = value;
                OnPropertyChanged("GameField");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
