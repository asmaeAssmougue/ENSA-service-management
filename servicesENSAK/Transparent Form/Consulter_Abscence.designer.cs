namespace Transparent_Form
{
    partial class Consulter_Abscence
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
            this.dataGridView_abscence = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_abscence)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_abscence
            // 
            this.dataGridView_abscence.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_abscence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_abscence.Location = new System.Drawing.Point(1, 92);
            this.dataGridView_abscence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_abscence.Name = "dataGridView_abscence";
            this.dataGridView_abscence.RowHeadersWidth = 51;
            this.dataGridView_abscence.Size = new System.Drawing.Size(812, 464);
            this.dataGridView_abscence.TabIndex = 1;
            this.dataGridView_abscence.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_note_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(71)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1069, 95);
            this.panel1.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(209, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(373, 39);
            this.label12.TabIndex = 2;
            this.label12.Text = "Consultation des absences";
            // 
            // Consulter_Abscence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView_abscence);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Consulter_Abscence";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_abscence)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_abscence;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
    }
}