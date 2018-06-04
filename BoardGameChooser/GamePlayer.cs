using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameChooser
{
    public static class Globals
    {
        public static PlayerList globalPlayerList = new PlayerList();
        public static GameList globalGameList = new GameList();
        public static List<string> columnList = new List<string>();
    }

    

    public class PlayerList
    {
        public PlayerList()
        {
            playerList.Clear();
            FillDefaultPlayers();
        }

        public bool AddPlayer(string playerName)
        {
            foreach (GamePlayer player in playerList)
            {
                if (playerName == player.playerName)
                {
                    return false;
                }
            }
            playerList.Add(new GamePlayer(playerName));

            return true;
        }

        public void FillDefaultPlayers()
        {
            AddPlayer("Ben");
            AddPlayer("Brian");
            AddPlayer("Chance");
            AddPlayer("Danielle");
            AddPlayer("Katie");
            AddPlayer("Kelley");
            AddPlayer("Marni");
            AddPlayer("Peter");
        }

        public List<GamePlayer> playerList = new List<GamePlayer>();
    }



    public class GamePlayer : IComparable
    {
        public GamePlayer()
        {
            playerName = "";
            isPlaying = false;
        }

        public GamePlayer(string pName)
        {
            playerName = pName;
            isPlaying = false;
        }

        public int CompareTo(GamePlayer other)
        {
            return gameRating.CompareTo(other.gameRating);
        }

        public int CompareTo(object obj)
        {
            GamePlayer p = obj as GamePlayer;
            if (this.gameRating == p.gameRating)
                return 0;
            else if (this.gameRating < p.gameRating)
                return 1;
            else
                return -1;
        }

        public string playerName;
        public bool isPlaying;
        public double gameRating;
    }


}
