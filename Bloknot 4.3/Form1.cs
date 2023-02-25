using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloknot_4._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            создатьToolStripMenuItem.Click += создатьToolStripMenuItem_Click;
            сохранитьToolStripMenuItem.Click += сохранитьToolStripMenuItem_Click;
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            шрифтToolStripMenuItem.Click += шрифтToolStripMenuItem_Click;
            справкаToolStripMenuItem.Click += справкаToolStripMenuItem_Click;
            fontDialog1.ShowColor = true;
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }

        /// <summary>
        /// Файл  ///////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы хотите сохранить изменения в файле?",
        "Блокнот",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string filename = saveFileDialog1.FileName;
                // сохраняем текст в файл
                System.IO.File.WriteAllText(filename, richTextBox1.Text);
                MessageBox.Show("Файл сохранен");
            }
            else if(result == DialogResult.No)
            {
                richTextBox1.Clear();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        ///// Шрифт ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка шрифта
            richTextBox1.SelectionFont = fontDialog1.Font;
            // установка цвета шрифта
            richTextBox1.SelectionColor = fontDialog1.Color;
        }

        ///// Справка //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ура, работает!!!");
        }

    }
}
