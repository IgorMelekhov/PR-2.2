using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PR_2._3
{
    public partial class Dictionary : Form
    {
        public Dictionary()
        {
            InitializeComponent();
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            textBoxChanged.Validating += textBoxChanged_Validating;
            textBoxCount.Validating += textBoxCount_Validating;
        }
        Dictionary<string, int> group = new Dictionary<string, int>()
        {
            ["2-ИСП"] = 25,
            ["2-ТЭО"] = 24,
        };
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedState= comboBox1.SelectedItem.ToString();
            int counter = 0;
            if (group.TryGetValue(selectedState,out counter)) textBox1Count.Text = counter.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string selectGroup = null;
            if ( comboBox1.SelectedItem != null)
            {
                try
                {
                    selectGroup = comboBox1.SelectedItem.ToString();
                    this.group[selectGroup] = Convert.ToInt32(textBoxChanged.Text);
                }
                catch
                {
                    MessageBox.Show("Введены неверные значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxChanged.Clear();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxChanged.Clear();
            }
            textBoxChanged.Clear();
            textBox1Count.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
            if (!string.IsNullOrEmpty(name))
            {
                try
                {

                    int count = Convert.ToInt16(textBoxCount.Text);
                    group.Add(name, count);
                    List<string> list = new List<string>(group.Keys);
                    comboBox1.DataSource = list;
                }
                catch
                {
                    MessageBox.Show("Введены неверные значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxName.Clear();
                    textBoxCount.Clear();
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели название группы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Clear();
                textBoxCount.Clear();
            }
            textBoxName.Clear() ;
            textBoxCount.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string name = comboBox1.SelectedItem.ToString();
                group.Remove(name);
                List<string> list = new List<string>(group.Keys);
                comboBox1.DataSource = list;
            }
            else
            {
                MessageBox.Show("Вы не выбрали группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxChanged.Clear();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int sum = group.Values.Sum();
            textBoxTotalNumberStudent.Text = sum.ToString();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newF = new Form2();
            newF.Show();
        }
        private void textBoxChanged_Validating(object sender, CancelEventArgs e)
        {
            int inputNumber;
            if (!String.IsNullOrEmpty(textBoxChanged.Text))
            {
                if (!int.TryParse(textBoxChanged.Text, out inputNumber))
                {
                    errorProvider1.SetError(textBoxChanged, "В поле должно быть введено целое число!");
                }
                else errorProvider1.Clear();
            }
            else errorProvider1.Clear();
        }
        private void textBoxCount_Validating(object sender, CancelEventArgs e)
        {
            int inputNumber;
            if (!String.IsNullOrEmpty(textBoxCount.Text))
            {
                if (!int.TryParse(textBoxCount.Text, out inputNumber))
                {
                    errorProvider1.SetError(textBoxCount, "В поле должно быть введено целое число!");
                }
                else errorProvider1.Clear();
            }
            else errorProvider1.Clear();
        }

        private void cleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBoxCount.Clear();
            textBoxName.Clear();
            textBoxChanged.Clear();
            textBoxTotalNumberStudent.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxCount.Clear();
            textBoxName.Clear();
            textBoxChanged.Clear();
            textBoxTotalNumberStudent.Clear();
        }
    }
}
