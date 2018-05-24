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
            List<List<string>> ConventionEntry = new List<List<string>>();
            using (var reader = new StreamReader(@"C:\Users\brian\Documents\GitHub\BoardGameChooser\Geekway2018.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    List<string> GameEntry = new List<string>();
                    for (int i = 0; i < values.Length; i++)
                    {
                        string currentText = values[i];
                        //string paddedText = currentText.PadRight(25).Substring(0, 25);
                        //paddedText = paddedText.Substring(0, Math.Min(paddedText.Length, 27));
                        GameEntry.Add(currentText);
                    }
                    ConventionEntry.Add(GameEntry);
                }
            }

            for(int i = 0; i < ConventionEntry.Count; i++)
            {
                List<string> GameEntry = ConventionEntry[i];
                string GameText = "";
                double gameInterest = 0.0;

                for (int j = 0; j < GameEntry.Count; j++)
                {
                    string currentText = GameEntry[j];

                    
                    if(currentText == "Eh")
                    {
                        gameInterest += 0.5;
                    }else if (currentText == "Yes")
                    {
                        gameInterest += 1.0;
                    }
                    else if (currentText == "Woo")
                    {
                        gameInterest += 1.25;
                    }

                    string paddedText = currentText.PadRight(25).Substring(0, 25);
                    GameText += paddedText + "\t";
                }

                GameText = gameInterest.ToString("#.##") + "\t" + GameText;
                listBox1.Items.Add(GameText);
            }
        }
    }
}
