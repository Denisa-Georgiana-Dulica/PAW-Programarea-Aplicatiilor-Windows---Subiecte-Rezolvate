namespace SubiectStudentiFacultate
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tb_matricol = new System.Windows.Forms.TextBox();
            this.tb_nume = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_medie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_inserare = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matricol";
            // 
            // tb_matricol
            // 
            this.tb_matricol.Location = new System.Drawing.Point(132, 57);
            this.tb_matricol.Name = "tb_matricol";
            this.tb_matricol.Size = new System.Drawing.Size(100, 22);
            this.tb_matricol.TabIndex = 1;
            // 
            // tb_nume
            // 
            this.tb_nume.Location = new System.Drawing.Point(132, 97);
            this.tb_nume.Name = "tb_nume";
            this.tb_nume.Size = new System.Drawing.Size(100, 22);
            this.tb_nume.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nume";
            // 
            // tb_medie
            // 
            this.tb_medie.Location = new System.Drawing.Point(132, 140);
            this.tb_medie.Name = "tb_medie";
            this.tb_medie.Size = new System.Drawing.Size(100, 22);
            this.tb_medie.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Medie";
            // 
            // btn_inserare
            // 
            this.btn_inserare.Location = new System.Drawing.Point(119, 200);
            this.btn_inserare.Name = "btn_inserare";
            this.btn_inserare.Size = new System.Drawing.Size(123, 23);
            this.btn_inserare.TabIndex = 6;
            this.btn_inserare.Text = "Inserare student";
            this.btn_inserare.UseVisualStyleBackColor = true;
            this.btn_inserare.Click += new System.EventHandler(this.btn_inserare_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Actualizare student";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_inserare);
            this.Controls.Add(this.tb_medie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_nume);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_matricol);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_matricol;
        private System.Windows.Forms.TextBox tb_nume;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_medie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_inserare;
        private System.Windows.Forms.Button button1;
    }
}