using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Mines
{
    public partial class gameForm : Form
    {
        static public long Ticks = 0;
        static public char[,] gameTable;
        public gameForm()
        {
            InitializeComponent();

            #region
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, false);
            SetStyle(ControlStyles.CacheText, true);
            SetStyle(ControlStyles.UserMouse, true);
            #endregion

            
        }

        private void gameForm_Load(object sender, EventArgs e)
        {
            
            int count = value.count;


            if (Math.Sqrt(count) % 1 == 0)
            {
                var btnTable = new Button[Convert.ToInt32(Math.Sqrt(count)), Convert.ToInt32(Math.Sqrt(count))];
                gameTable = SearchBombs(AddBombs(CreateTable(btnTable)));

                #region
                /*#region
                for (int i = 0; i < columns.Length; i++)
                {
                    columns[i] = new DataGridViewButtonColumn();
                    columns[i].Width = 50;
                    columns[i].Name = "col" + i;
                }

                for(int i = 0; i < rows.Length;i++)
                {
                    rows[i] = new DataGridViewRow();
                    
                    rows[i].Height = 50;
                }

                for (int i = 0; i < Convert.ToInt32(Math.Sqrt(count)); i++)
                {
                    dataGridView1.Columns.Add(columns[i]);
                    dataGridView1.Rows.Add(rows[i]);
                }

                for(int i = 0; i < Convert.ToInt32(Math.Sqrt(count)); i++)
                {
                    for(int j = 0; j < Convert.ToInt32(Math.Sqrt(count)); j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "?";
                    }
                }
                #endregion*/
                #endregion
            }
            else
            {
                int a = 0, b = 0, sub = int.MaxValue;
                // нахождение наилучших пар чисел для создания столбцов и строк
                for(int i = count/2; i >= 0; i--)
                {
                    for(int j = count/2;j>=0;j--)
                    {
                        if(i * j == count && Math.Abs(i-j) < sub)
                        {
                            a = i;
                            b = j;
                            sub = Math.Abs(i - j);
                        }
                    }
                }
                if (a == 0 || b == 0)
                {
                    MessageBox.Show("Введите другое число");
                    this.Close();
                    return;
                }

                var btnTable = new Button[a, b];
                
                gameTable = SearchBombs(AddBombs(CreateTable(btnTable)));

            }
        }

        private char[,] CreateTable(Button[,] gameTable)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < gameTable.GetLength(0); i++)
            {
                for(int j = 0; j < gameTable.GetLength(1); j++)
                {
                    gameTable[i, j] = new Button();
                    gameTable[i, j].Text = "?";
                    gameTable[i, j].Size = new Size(40, 40);
                    gameTable[i, j].BackColor = Color.DarkGray;
                    gameTable[i, j].Location = new Point(y, x);
                    gameTable[i, j].Font = new Font("Arial Black", 14);
                    gameTable[i, j].Name = i + "_" + j;
                    gameTable[i, j].FlatStyle = FlatStyle.Flat;
                    gameTable[i, j].MouseDown += GameForm_MouseDown;
                    x += 40;
                }
                y += 40;
                x = 0;
            }

            for(int i = 0; i < gameTable.GetLength(0); i++)
            {
                for(int j = 0; j < gameTable.GetLength(1); j++)
                {
                    pnlGameField.Controls.Add(gameTable[i, j]);
                }
            }

            return new char[gameTable.GetLength(0),gameTable.GetLength(1)];

        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((sender as Button).Text == "?")
                {
                    if (gameTable[Convert.ToInt32((sender as Button).Name.Split('_').First()), Convert.ToInt32((sender as Button).Name.Split('_').Last())] == 'B')
                    {
                        (sender as Button).Text = "B";
                        (sender as Button).BackColor = Color.Red;
                        MessageBox.Show("Упс.\nВы попали на мину.\nВы проиграли");
                        this.Close();
                    }
                    else
                    {
                        (sender as Button).Text = gameTable[Convert.ToInt32((sender as Button).Name.Split('_').First()), Convert.ToInt32((sender as Button).Name.Split('_').Last())].ToString();
                        (sender as Button).BackColor = Color.Teal;
                    }
                }
            }
            else
            {
                if ((sender as Button).Text == "?")
                {
                    (sender as Button).Text = "F";
                    (sender as Button).BackColor = Color.SteelBlue;
                    lblBombsCount.Text = (Convert.ToInt32(lblBombsCount.Text) - 1).ToString();
                }
                else
                if (((Button)sender).Text == "F")
                {
                    lblBombsCount.Text = (Convert.ToInt32(lblBombsCount.Text) + 1).ToString();
                    (sender as Button).Text = "?";
                    (sender as Button).BackColor = Color.Green;
                }
            }

            GameState(gameTable);
        }

        private char[,] AddBombs(char[,] gameTable)
        {
            Random a = new Random();
            int iBombs = 0;
            int b = 0;
            while(iBombs < Convert.ToInt32(value.count * value.difficulty))
            for(int i = 0; i < gameTable.GetLength(0); i++)
            {
                for(int j = 0; j < gameTable.GetLength(1); j++)
                {
                    b = a.Next(1, 100);
                    if(b <= 15 && gameTable[i,j] != 'B')
                    {
                        iBombs++;
                        gameTable[i, j] = 'B';
                    }
                }
            }
            value.Bombs = iBombs;
            lblBombsCount.Text = iBombs.ToString();
            return gameTable;
        }

        private char[,] SearchBombs(char[,] gameTable)
        {
            int count = 0;

            for(int i = 0; i < gameTable.GetLength(0); i++)
            {
                for(int j = 0; j < gameTable.GetLength(1); j++)
                {
                    //---------------------------------
                    if (gameTable[i, j] != 'B')
                    {
                        for (int i1 = i - 1; i1 <= i + 1; i1++)
                        {
                            for (int j1 = j - 1; j1 <= j + 1; j1++)
                            {
                                if (i1 < 0 || j1 < 0 || i1 > gameTable.GetLength(0)-1 || j1 > gameTable.GetLength(1)-1)
                                {
                                    continue;
                                }
                                if (i1 == i && j1 == j)
                                {
                                    continue;
                                }

                                if(gameTable[i1,j1] == 'B')
                                {
                                    count++;
                                }

                            }
                        }
                        gameTable[i, j] = Convert.ToChar(count.ToString());
                        count = 0;
                    }
                    //---------------------------------
                }
            }

            return gameTable;
        }
        
        private void GameState(char[,] gameTable)
        {
            if(lblBombsCount.Text == "0")
            {
                for (int i = 0; i < gameTable.Length; i++)
                {
                        if (pnlGameField.Controls[i].Text == "?")
                        {
                            return;
                        }
                }
                GamePass a = new GamePass();
                a.ShowDialog();
                this.Close();
            }

        }
    }
}
