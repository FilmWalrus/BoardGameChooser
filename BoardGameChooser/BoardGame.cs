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

        public List<BoardGame> gameList = new List<BoardGame>();
    }

    public class BoardGame
    {
        public BoardGame()
        {

        }

        public string gameTitle = "";
        public int minPlayers = 0;
        public int maxPlayers = 0;
        public string playTime = "";
        public string gameNotes = "";
        public string gameType = "";

    }

    
}
