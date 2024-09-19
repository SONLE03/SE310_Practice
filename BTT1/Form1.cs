using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTT1
{
    public partial class Form1 : Form
    {
        public static Farm farm;
        public static int numberOfCows = 0;
        public static int numberOfSheep = 0;
        public static int numberOfGoats = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(numberOfCow.Text) || String.IsNullOrEmpty(numberOfSheeps.Text) || String.IsNullOrEmpty(numberOfGoat.Text))
            {
                MessageBox.Show("Lack of information", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            numberOfCows = Convert.ToInt32(numberOfCow.Text);
            numberOfSheep = Convert.ToInt32(numberOfSheeps.Text);
            numberOfGoats = Convert.ToInt32(numberOfGoat.Text);
            farm = new Farm(numberOfCows, numberOfSheep, numberOfGoats);
            MessageBox.Show("OK", "Notification", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numberOfCows == 0 || numberOfSheep == 0 || numberOfGoats == 0)
            {
                MessageBox.Show("Lack of information", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AnimalSounds.Text = farm.AnimalSounds();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (numberOfCows == 0 || numberOfSheep == 0 || numberOfGoats == 0)
            {
                MessageBox.Show("Lack of information", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TotalMilk.Text = TotalMilk.Text + farm.TotalMilkYield().ToString();
        }
    }
}
