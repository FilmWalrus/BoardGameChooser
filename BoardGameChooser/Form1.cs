using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace BoardGameChooser
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable gameTable = MakeGameTable();
            Globals.columnList.Clear();

            using (var reader = new StreamReader(@"C:\Users\brian\Documents\GitHub\BoardGameChooser\Geekway2018.csv"))
            {
                // Loop through the rows in the csv table
                int gameCount = 0;
                while (!reader.EndOfStream)
                {
                    // Parse the current row of the csv table
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    
                    DataRow newRow = gameTable.NewRow();
                    for (int i = 0; i < values.Length; i++)
                    {
                        if(gameCount == 0)
                        {
                            Globals.columnList.Add(values[i]);
                        }
                        else
                        {
                            if (values[i] != "")
                            {
                                newRow[Globals.columnList[i]] = values[i];
                            }
                        }
                    }

                    if (gameCount != 0)
                    {
                        gameTable.Rows.Add(newRow);

                        // Add this game to the GameList
                        BoardGame newGame = new BoardGame();
                        newGame.gameTitle = newRow["Title"] as string;
                        Int32.TryParse(newRow["Min"] as string, out newGame.minPlayers);
                        Int32.TryParse(newRow["Max"] as string, out newGame.maxPlayers);
                        Globals.globalGameList.AddGame(newGame);
                    }

                    gameCount++;
                }
            }

            dataGridView1.DataSource = gameTable;

            dataGridView1.AutoResizeColumns();

            // Fill player listbox
            foreach (GamePlayer player in Globals.globalPlayerList.playerList)
            {
                PlayersListbox.Items.Add(player.playerName);
            }

        }


        

        public DataTable MakeGameTable()
        {
            // Create a new DataTable titled 'Names.'
            DataTable gameTable = new DataTable("Games");

            //Title	Min	Max	Time	BGGR	Notes	Type

            DataColumn fNameColumn = new DataColumn();
            fNameColumn.DataType = System.Type.GetType("System.String");
            fNameColumn.ColumnName = "Title";
            fNameColumn.DefaultValue = "";
            gameTable.Columns.Add(fNameColumn);

            DataColumn minPlayerColumn = new DataColumn();
            minPlayerColumn.DataType = System.Type.GetType("System.Int32");
            minPlayerColumn.ColumnName = "Min";
            gameTable.Columns.Add(minPlayerColumn);

            DataColumn maxPlayerColumn = new DataColumn();
            maxPlayerColumn.DataType = System.Type.GetType("System.Int32");
            maxPlayerColumn.ColumnName = "Max";
            gameTable.Columns.Add(maxPlayerColumn);

            DataColumn timeColumn = new DataColumn();
            timeColumn.DataType = System.Type.GetType("System.String");
            timeColumn.ColumnName = "Time";
            timeColumn.DefaultValue = "";
            gameTable.Columns.Add(timeColumn);

            DataColumn ratingColumn = new DataColumn();
            ratingColumn.DataType = System.Type.GetType("System.Double");
            ratingColumn.ColumnName = "BGGR";
            gameTable.Columns.Add(ratingColumn);

            DataColumn notesColumn = new DataColumn();
            notesColumn.DataType = System.Type.GetType("System.String");
            notesColumn.ColumnName = "Notes";
            notesColumn.DefaultValue = "";
            gameTable.Columns.Add(notesColumn);

            DataColumn typeColumn = new DataColumn();
            typeColumn.DataType = System.Type.GetType("System.String");
            typeColumn.ColumnName = "Type";
            typeColumn.DefaultValue = "";
            gameTable.Columns.Add(typeColumn);

            // Create list of players
            
            

            foreach (GamePlayer player in Globals.globalPlayerList.playerList)
            {
                DataColumn playerColumn = new DataColumn();
                playerColumn.DataType = System.Type.GetType("System.String");
                playerColumn.ColumnName = player.playerName;
                gameTable.Columns.Add(playerColumn);
            }


            // Create an array for DataColumn objects.
            //DataColumn[] keys = new DataColumn[1];
            //keys[0] = idColumn;
            //gameTable.PrimaryKey = keys;

            // Return the new DataTable.
            return gameTable;
        }

        private void chooseGame_Click(object sender, EventArgs e)
        {
            // Clear the gameValues for all the games
            foreach (BoardGame currentGame in Globals.globalGameList.gameList)
            {
                currentGame.gameValue = 0.0;
            }

            // Create a list of the active players
            List<string> activePlayerList = new List<string>();
            foreach (var playerEntry in PlayersListbox.SelectedItems)
            {
                activePlayerList.Add(playerEntry.ToString());
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string currentTitle = row.Cells["Title"].Value as string;
                BoardGame currentGame = Globals.globalGameList.GetGame(currentTitle);

                foreach (string currentPlayerName in activePlayerList)
                {
                    string playerRating = row.Cells[currentPlayerName].Value as string;

                    if(playerRating == "Woo")
                    {
                        currentGame.gameValue += 1.25;
                    }else if (playerRating == "Yes")
                    {
                        currentGame.gameValue += 1.0;
                    }
                    else if (playerRating == "Eh")
                    {
                        currentGame.gameValue += 0.5;
                    }

                }

                //foreach (DataGridViewCell cell in row.Cells)
                //{
                //    //do operations with cell
                //}
            }

            Globals.globalGameList.gameList.Sort();

            BestListbox.Items.Clear();
            foreach (BoardGame currentGame in Globals.globalGameList.gameList)
            {
                string displayText = currentGame.gameTitle + ": " + currentGame.gameValue;
                BestListbox.Items.Add(displayText);
            }

        }

        private void PlayersListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


