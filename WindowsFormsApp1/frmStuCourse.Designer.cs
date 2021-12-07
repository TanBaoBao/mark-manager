
namespace WindowsFormsApp1
{
    partial class frmStuCourse
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
            this.dgvStuCourse = new System.Windows.Forms.DataGridView();
            this.cbCourseId = new System.Windows.Forms.ComboBox();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStuCourse
            // 
            this.dgvStuCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStuCourse.Location = new System.Drawing.Point(64, 160);
            this.dgvStuCourse.Name = "dgvStuCourse";
            this.dgvStuCourse.RowHeadersWidth = 51;
            this.dgvStuCourse.RowTemplate.Height = 24;
            this.dgvStuCourse.Size = new System.Drawing.Size(922, 234);
            this.dgvStuCourse.TabIndex = 0;
            this.dgvStuCourse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStuCourse_CellClick);
            // 
            // cbCourseId
            // 
            this.cbCourseId.FormattingEnabled = true;
            this.cbCourseId.Location = new System.Drawing.Point(236, 75);
            this.cbCourseId.Name = "cbCourseId";
            this.cbCourseId.Size = new System.Drawing.Size(121, 24);
            this.cbCourseId.TabIndex = 1;
            // 
            // cbSemester
            // 
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Location = new System.Drawing.Point(236, 36);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(121, 24);
            this.cbSemester.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Semester";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Course ID";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(455, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(129, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmStuCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 450);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSemester);
            this.Controls.Add(this.cbCourseId);
            this.Controls.Add(this.dgvStuCourse);
            this.Name = "frmStuCourse";
            this.Text = "Student Course";
            this.Load += new System.EventHandler(this.frmStuCourse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStuCourse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStuCourse;
        private System.Windows.Forms.ComboBox cbCourseId;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
    }
}