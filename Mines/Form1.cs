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
    public partial class mainMenuForm : Form
    {
        public mainMenuForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Replace(" ", "") == "")
            {
                MessageBox.Show("Необходимо ввести число!");
                return;
            }
            if(Convert.ToInt32(textBox1.Text) < 16 || Convert.ToInt32(textBox1.Text) > 1000)
            {
                MessageBox.Show("Необходимо ввести число от 16 до 1000");
                return;
            }
            value.difficulty = Convert.ToSingle(comboBox1.SelectedItem.ToString().Replace("%", ""))/100f;
            value.count = Convert.ToInt32(textBox1.Text);
            gameForm gm = new gameForm();
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            gm.ShowDialog();
            this.Opacity = 100;
            this.ShowInTaskbar = true;
            return;
        }

        private void mainMenuForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;
        }
    }
}
