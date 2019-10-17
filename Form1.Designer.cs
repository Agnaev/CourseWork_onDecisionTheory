using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CourseWork_theoryOfDecide
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        private void AddElementToForm(Control elem)
        {
            try
            {
                this.Controls.Add(elem);
            }
            catch(Exception e)
            {
                ExceptionWriter(e);
            }
        }

        private void RemoveElementFromForm(Control elem)
        {
            try
            {
                if (this.Controls.Contains(elem))
                    this.Controls.Remove(elem);
            }
            catch(Exception e)
            {
                ExceptionWriter(e);
            }
        }

        private void ExceptionWriter(Exception e)
        {
            using (StreamWriter writer = new StreamWriter("Log.txt", true, Encoding.UTF8))
            {
                writer.WriteLine(e.Message);
                writer.Close();
            }
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_countOfVertexes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_createMatrix = new System.Windows.Forms.Button();
            this.Reload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_countOfVertexes
            // 
            this.textBox_countOfVertexes.Location = new System.Drawing.Point(26, 43);
            this.textBox_countOfVertexes.Name = "textBox_countOfVertexes";
            this.textBox_countOfVertexes.Size = new System.Drawing.Size(100, 20);
            this.textBox_countOfVertexes.TabIndex = 0;
            this.textBox_countOfVertexes.TextChanged += new System.EventHandler(this.TextBox_countOfVertexes_TextChanged);
            this.textBox_countOfVertexes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CountOfVertex_keyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите количество вершин";
            // 
            // btn_createMatrix
            // 
            this.btn_createMatrix.Location = new System.Drawing.Point(26, 69);
            this.btn_createMatrix.Name = "btn_createMatrix";
            this.btn_createMatrix.Size = new System.Drawing.Size(257, 23);
            this.btn_createMatrix.TabIndex = 2;
            this.btn_createMatrix.Text = "Ввести матрицу смежности";
            this.btn_createMatrix.UseVisualStyleBackColor = true;
            this.btn_createMatrix.Click += new System.EventHandler(this.Btn_createMatrix_Click);
            // 
            // Reload
            // 
            this.Reload.Location = new System.Drawing.Point(290, 68);
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(75, 23);
            this.Reload.TabIndex = 3;
            this.Reload.Text = "Reload";
            this.Reload.UseVisualStyleBackColor = true;
            this.Reload.Visible = false;
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reload);
            this.Controls.Add(this.btn_createMatrix);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_countOfVertexes);
            this.Name = "Form1";
            this.Text = "Course work";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox_countOfVertexes;
        private Label label1;
        private Button btn_createMatrix;
        private Button Reload;
    }
}

