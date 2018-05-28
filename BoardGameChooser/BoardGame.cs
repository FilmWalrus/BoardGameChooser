using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChooser
{

    public class GameList
    {
        public GameList()
        {
            gameList.Clear();
        }

        public bool AddGame(BoardGame newGame)
        {
            foreach (BoardGame thisGame in gameList)
            {
                if (thisGame.gameTitle == newGame.gameTitle)
                {
                    return false;
                }
            }
            gameList.Add(newGame);

            return true;
        }

        public BoardGame GetGame(string gameTitle)
        {
            foreach (BoardGame thisGame in gameList)
            {
                if (thisGame.gameTitle == gameTitle)
                {
                    return thisGame;
                }
            }

            return null;
        }

        public List<BoardGame> gameList = new List<BoardGame>();
    }

    public class BoardGame: IComparable
    {
        public BoardGame()
        {

        }

        public int CompareTo(BoardGame other)
        {
            return gameValue.CompareTo(other.gameValue);
        }

        public int CompareTo(object obj)
        {
            BoardGame p = obj as BoardGame;
            if (this.gameValue == p.gameValue)
                return 0;
            else if (this.gameValue < p.gameValue)
                return 1;
            else
                return -1; // this.Length > p.Length
        }

        public string gameTitle = "";
        public int minPlayers = 0;
        public int maxPlayers = 0;
        public string playTime = "";
        public string gameNotes = "";
        public string gameType = "";

        public double gameValue = 0.0;
    }

    
}
