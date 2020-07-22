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
    public partial class GamePass : Form
    {
        public GamePass()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void GamePass_Load(object sender, EventArgs e)
        {
            lblDifficulty.Text = Convert.ToString(value.difficulty * 100) + "%";
            lblSizeField.Text = gameForm.gameTable.GetLength(0).ToString() + "x" + gameForm.gameTable.GetLength(1).ToString();
        }
    }
}
