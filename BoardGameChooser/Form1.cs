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
            List<string> columnList = new List<string>();

            using (var reader = new StreamReader(@"C:\Users\brian\Documents\GitHub\BoardGameChooser\Geekway2018.csv"))
            {
                int gameCount = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    DataRow newRow = gameTable.NewRow();
                    for (int i = 0; i < values.Length; i++)
                    {
                        if(gameCount == 0)
                        {
                            columnList.Add(values[i]);
                        }
                        else
                        {
                            if (values[i] != "")
                            {
                                newRow[columnList[i]] = values[i];
                            }
                        }
                    }

                    if (gameCount != 0)
                    {
                        gameTable.Rows.Add(newRow);
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


            //for (int i = 0; i < ConventionEntry.Count; i++)
            //{
            //    List<string> GameEntry = ConventionEntry[i];
            //    string GameText = "";
            //    double gameInterest = 0.0;

            //    for (int j = 0; j < GameEntry.Count; j++)
            //    {
            //        string currentText = GameEntry[j];


            //        if(currentText == "Eh")
            //        {
            //            gameInterest += 0.5;
            //        }else if (currentText == "Yes")
            //        {
            //            gameInterest += 1.0;
            //        }
            //        else if (currentText == "Woo")
            //        {
            //            gameInterest += 1.25;
            //        }

            //        string paddedText = currentText.PadRight(25).Substring(0, 25);
            //        GameText += paddedText + "\t";
            //    }

            //    GameText = gameInterest.ToString("#.##") + "\t" + GameText;
            //    listBox1.Items.Add(GameText);
            //}
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void PlayersListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}


