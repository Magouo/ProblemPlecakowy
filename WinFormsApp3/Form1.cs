using ProblemPlecakowy;
using System.ComponentModel.Design;

namespace WinFormsApp3

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool dziala = true;
            while (dziala == true)
            {

                int seed = int.Parse(textBox1.Text);
                int liczbaPrzedmiotow = int.Parse(textBox2.Text);
                int pojemnosc = int.Parse(textBox3.Text);

                if(seed > 0 && liczbaPrzedmiotow > 0 && pojemnosc > 0 )
                {
                    Problem problem = new Problem(liczbaPrzedmiotow, seed);
                    Wynik wynik = problem.Rozwiaz(pojemnosc);

                    label4.Text = wynik.ToString();
                    label5.Text = problem.ToString();
                    break;
                }

                else
                {
                    dziala = false;
                    label4.Text = "Ktoras wartosc wynosi 0\nPopraw";
                    label5.Text = "";
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
