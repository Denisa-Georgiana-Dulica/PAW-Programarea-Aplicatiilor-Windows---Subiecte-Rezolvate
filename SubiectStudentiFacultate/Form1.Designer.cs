namespace SubiectStudentiFacultate
{
    partial class Form1
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
            this.dgv_studenti = new System.Windows.Forms.DataGridView();
            this.btn_afisare = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_studenti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_studenti
            // 
            this.dgv_studenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_studenti.Location = new System.Drawing.Point(136, 106);
            this.dgv_studenti.Name = "dgv_studenti";
            this.dgv_studenti.ReadOnly = true;
            this.dgv_studenti.RowHeadersWidth = 51;
            this.dgv_studenti.RowTemplate.Height = 24;
            this.dgv_studenti.Size = new System.Drawing.Size(500, 252);
            this.dgv_studenti.TabIndex = 0;
            this.dgv_studenti.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_studenti_RowHeaderMouseClick);
            // 
            // btn_afisare
            // 
            this.btn_afisare.Location = new System.Drawing.Point(136, 386);
            this.btn_afisare.Name = "btn_afisare";
            this.btn_afisare.Size = new System.Drawing.Size(121, 23);
            this.btn_afisare.TabIndex = 1;
            this.btn_afisare.Text = "Afisare studenti";
            this.btn_afisare.UseVisualStyleBackColor = true;
            this.btn_afisare.Click += new System.EventHandler(this.btn_afisare_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(292, 385);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 2;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(407, 385);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 3;
            this.btn_insert.Text = "Insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(561, 385);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_afisare);
            this.Controls.Add(this.dgv_studenti);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_studenti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_studenti;
        private System.Windows.Forms.Button btn_afisare;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_delete;
    }
}

