namespace Transparent_Form
{
    partial class Consulter_Note
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
            this.dataGridView_note = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_note)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_note
            // 
            this.dataGridView_note.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_note.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_note.Location = new System.Drawing.Point(1, 105);
            this.dataGridView_note.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_note.Name = "dataGridView_note";
            this.dataGridView_note.RowHeadersWidth = 51;
            this.dataGridView_note.Size = new System.Drawing.Size(655, 448);
            this.dataGridView_note.TabIndex = 0;
            this.dataGridView_note.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 105);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(163, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(324, 39);
            this.label12.TabIndex = 3;
            this.label12.Text = "Consultation des notes";
            // 
            // Consulter_Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_note);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Consulter_Note";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_note)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_note;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
    }
}