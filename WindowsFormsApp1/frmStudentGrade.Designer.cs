
namespace WindowsFormsApp1
{
    partial class frmStudentGrade
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
            this.dgvStudentGrade = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGPA = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentGrade
            // 
            this.dgvStudentGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentGrade.Location = new System.Drawing.Point(33, 12);
            this.dgvStudentGrade.Name = "dgvStudentGrade";
            this.dgvStudentGrade.RowHeadersWidth = 51;
            this.dgvStudentGrade.RowTemplate.Height = 24;
            this.dgvStudentGrade.Size = new System.Drawing.Size(460, 355);
            this.dgvStudentGrade.TabIndex = 0;
            this.dgvStudentGrade.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudentGrade_CellValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(580, 336);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 47);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(555, 169);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(146, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Course Completed";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(552, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "GPA";
            // 
            // txtGPA
            // 
            this.txtGPA.Location = new System.Drawing.Point(598, 75);
            this.txtGPA.Name = "txtGPA";
            this.txtGPA.ReadOnly = true;
            this.txtGPA.Size = new System.Drawing.Size(100, 22);
            this.txtGPA.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(555, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Calculate GPA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmStudentGrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 401);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtGPA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvStudentGrade);
            this.Name = "frmStudentGrade";
            this.Text = "Student Grade";
            this.Load += new System.EventHandler(this.frmStudentGrade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentGrade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGPA;
        private System.Windows.Forms.Button button2;
    }
}