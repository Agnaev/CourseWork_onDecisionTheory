using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_theoryOfDecide
{
    public partial class Form1 : Form
    {
        private Control[,] text;
        private List<Control> labels = new List<Control>();
        Control btn_getAnswer;
        public Form1()
        {

            InitializeComponent();
        }

        private void Btn_createMatrix_Click(object sender, EventArgs e)
        {
            
            int.TryParse(textBox_countOfVertexes.Text, out int countOfVertexes);
            if (countOfVertexes < 2)
            {
                MessageBox.Show("Укажите корректное число вершин.");
                return;
            }

            if (countOfVertexes > 50)
            {
                MessageBox.Show("Слишком большое количество вершин.");
                return;
            }

            
            textBox_countOfVertexes.Enabled = false;

            text = new Control[countOfVertexes, countOfVertexes];
            for (int i = 0; i < countOfVertexes; i++)
            {
                for (int j = 0; j < countOfVertexes; j++)
                {
                    text[i, j] = new TextBox
                    {
                        Location = new Point(26 + j * 60, 98 + i * 30),
                        Size = new Size(50, 20),
                        Visible = true,
                        Enabled = i < j,
                        Text = i == j ? "0" : "",
                        Name = $"{i}_{j}"
                    };

                    text[i, j].TextChanged += new EventHandler(delegate (object sender_, EventArgs event_) {
                        TextBox tb = (TextBox)sender_;
                        string[] coordinats = tb.Name.Split(new char[] { '_' });
                        int.TryParse(coordinats[1], out int x);//второре значение записывается в первое
                        int.TryParse(coordinats[0], out int y);//первое - во второе
                        text[x, y].Text = tb.Text;
                    });

                    AddElementToForm(text[i, j]);
                }
            }
            btn_getAnswer = new Button
            {
                Text = "Получить ответ.",
                Location = new Point(26, 69),
                Size = new Size(257, 23)
            };
            btn_getAnswer.Click += GetAnswer_click;

            btn_createMatrix.Visible = false;
            AddElementToForm(btn_getAnswer);
        }

        private void CountOfVertex_keyPress(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                Btn_createMatrix_Click(sender, new EventArgs());
        }

        /// <summary>
        /// Посчитать ответ после ввода матрицы смежности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetAnswer_click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control textBox in text)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        MessageBox.Show("Заполните всю матрицу смежности");
                        textBox.Text = string.Empty;
                        return;
                    }
                    else if (!Regex.IsMatch(textBox.Text, @"^\d*$"))
                    {
                        MessageBox.Show("Разрешается вводить только числа");
                        textBox.Text = string.Empty;
                        return;
                    }
                }

                Reload.Visible = true;
                btn_getAnswer.Enabled = false;

                List<Edge> Edges = new List<Edge>();
                for (int i = 1; i <= text.GetLength(0); i++)
                {
                    for (int j = 1; j <= text.GetLength(1); j++)
                    {
                        double.TryParse(text[i - 1, j - 1].Text, out double temp);
                        if (i != j && temp != 0)
                        {
                            text[i - 1, j - 1].Text = temp.ToString();
                            Edges.Add(new Edge(i, j, temp));
                        }
                    }
                }

                Edges = Kernel.AlgorithmByPrim(text.GetLength(0), Edges);

                int pos = 26 + text.GetLength(0) * 60;
                double sum = 0;
                for (int i = 0; i < Edges.Count; i++)
                {
                    Control temp = new Label()
                    {
                        Size = new Size(151, 13),
                        Location = new Point(26, pos + i * 25),
                        Text = $"from {Edges[i].SourceVertex} to {Edges[i].EndedVertex} with weight {Edges[i].Weight}"
                    };
                    labels.Add(temp);
                    AddElementToForm(temp);
                    sum += Edges[i].Weight;
                }
                
                var label = new Label()
                {
                    Size = new Size(151, 13),
                    Location = new Point(26, pos + Edges.Count * 25),
                    Text = $"Total weights is {sum}"
                };
                AddElementToForm(label);
                labels.Add(label);
            }
            catch (Exception exc)
            {
                ExceptionWriter(exc);
                return;
            }
        }

        private void TextBox_countOfVertexes_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox_countOfVertexes.Text, @"^\d*$"))
            {
                textBox_countOfVertexes.Text = string.Empty;
                MessageBox.Show("Разрешается вводить только числа");
            }
        }

        private void Reload_Click(object sender, EventArgs e)
        {
            foreach(var textbox in text)
                textbox.Dispose();
            foreach(var label in labels)
                label.Dispose();
            
            Reload.Visible = false;
            
            btn_getAnswer.Visible = false;
            btn_createMatrix.Visible = true;

            textBox_countOfVertexes.Text = "";
            textBox_countOfVertexes.Enabled = true;
        }
    }
}
