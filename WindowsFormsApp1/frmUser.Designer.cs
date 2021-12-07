
namespace WindowsFormsApp1
{
    partial class frmUser
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
            this.lbCourse = new System.Windows.Forms.ListBox();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.dgvGrade = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGPA = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNoti = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCourse
            // 
            this.lbCourse.FormattingEnabled = true;
            this.lbCourse.ItemHeight = 16;
            this.lbCourse.Location = new System.Drawing.Point(185, 71);
            this.lbCourse.Name = "lbCourse";
            this.lbCourse.Size = new System.Drawing.Size(150, 212);
            this.lbCourse.TabIndex = 2;
            this.lbCourse.SelectedIndexChanged += new System.EventHandler(this.lbCourse_SelectedIndexChanged);
            // 
            // cbSemester
            // 
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Location = new System.Drawing.Point(37, 71);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(121, 24);
            this.cbSemester.TabIndex = 3;
            this.cbSemester.SelectedIndexChanged += new System.EventHandler(this.cbSemester_SelectedIndexChanged);
            // 
            // dgvGrade
            // 
            this.dgvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrade.Location = new System.Drawing.Point(365, 22);
            this.dgvGrade.Name = "dgvGrade";
            this.dgvGrade.RowHeadersWidth = 51;
            this.dgvGrade.RowTemplate.Height = 24;
            this.dgvGrade.Size = new System.Drawing.Size(662, 322);
            this.dgvGrade.TabIndex = 4;
            this.dgvGrade.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGrade_CellFormatting);
            this.dgvGrade.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvGrade_CellPainting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(386, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current GPA";
            // 
            // txtGPA
            // 
            this.txtGPA.Location = new System.Drawing.Point(480, 348);
            this.txtGPA.Name = "txtGPA";
            this.txtGPA.Size = new System.Drawing.Size(100, 22);
            this.txtGPA.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(897, 350);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 21);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "is complete";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(739, 348);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 22);
            this.txtResult.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Current Result";
            // 
            // labelNoti
            // 
            this.labelNoti.AutoSize = true;
            this.labelNoti.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelNoti.Location = new System.Drawing.Point(386, 392);
            this.labelNoti.Name = "labelNoti";
            this.labelNoti.Size = new System.Drawing.Size(57, 29);
            this.labelNoti.TabIndex = 10;
            this.labelNoti.Text = "Noti";
            // 
            // frmUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 450);
            this.Controls.Add(this.labelNoti);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtGPA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvGrade);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.lbCourse);
            this.Name = "frmUser";
            this.Text = "User";
            this.Load += new System.EventHandler(this.frmUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbCourse;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.DataGridView dgvGrade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGPA;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNoti;
    }
}