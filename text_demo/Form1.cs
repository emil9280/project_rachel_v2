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

namespace text_demo
{
    public partial class Form1 : Form
    {

        private string Path_final_1;
        private string Path_final_2;
        private List<string> Name1 = new List<string>();
        private List<int> Amount = new List<int>();
        public Form1()
        {
            InitializeComponent();
            Read_From();
            foreach(string element in Name1)
            {
                CB_V_N.Items.Add(element);
            }
            path_1();
           
        }
        private void path_1()
        {
            string Path_1 = Directory.GetCurrentDirectory();
            string Path_2 = Path_1 + "demo.txt";
            string Path_3 = Path_1 + "demo1.txt";
            if (!File.Exists(Path_2))
            {
                File.Create(Path_2);
            }
            if (!File.Exists(Path_3))
            {
                File.Create(Path_3);
            }
            Path_final_1 = Path_2;
            Path_final_2 = Path_3;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            Amount[CB_V_N.SelectedIndex] -= (int)numericUpDown1.Value;
            label1.Text = Amount[CB_V_N.SelectedIndex].ToString();
            Write_To();
            numericUpDown1.Value = 0;
        }
        private void Write_To()
        {
            TextWriter txt = new StreamWriter(Path_final_1);
            for (int i = 0; i < Name1.Count; i++)
            {
                txt.WriteLine("");
                txt.WriteLine(Name1[i]);
                txt.WriteLine(Amount[i]);                
            }
            txt.Close();
        }
        private void Read_From()
        {
            TextReader tet = new StreamReader(Path_final_2);
            while (tet.ReadLine() != null)
            {
                Name1.Add(tet.ReadLine());
                Amount.Add(Convert.ToInt32(tet.ReadLine()));                
            }
            tet.Close();
        }

        private void Add_vine_Click(object sender, EventArgs e)
        {
            if (TB_new.Text != "")
            {
                Name1.Add(TB_new.Text);
                Amount.Add(0);
                CB_V_N.Items.Add(TB_new.Text);
                TB_new.Text = "";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BU_RE_Click(object sender, EventArgs e)
        {
            Amount[CB_V_N.SelectedIndex] += (int)numericUpDown1.Value;
            label1.Text = Amount[CB_V_N.SelectedIndex].ToString();
            Write_To();
            numericUpDown1.Value = 0;
        }

        private void CB_V_N_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = Amount[CB_V_N.SelectedIndex].ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void locate_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.Show(this);
        }
    }
}
