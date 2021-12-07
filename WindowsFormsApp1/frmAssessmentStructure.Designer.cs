
namespace GradeManager
{
    partial class frmAssessmentStructure
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtGradeType = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dgvGradeType = new System.Windows.Forms.DataGridView();
            this.btnAddGradeType = new System.Windows.Forms.Button();
            this.btnDelGradeType = new System.Windows.Forms.Button();
            this.btnUpdateGradeType = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeType)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grade Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Weight(%)";
            // 
            // txtGradeType
            // 
            this.txtGradeType.Location = new System.Drawing.Point(121, 21);
            this.txtGradeType.Name = "txtGradeType";
            this.txtGradeType.Size = new System.Drawing.Size(256, 22);
            this.txtGradeType.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(121, 60);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 3;
            // 
            // dgvGradeType
            // 
            this.dgvGradeType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGradeType.Location = new System.Drawing.Point(21, 138);
            this.dgvGradeType.Name = "dgvGradeType";
            this.dgvGradeType.RowHeadersWidth = 51;
            this.dgvGradeType.RowTemplate.Height = 24;
            this.dgvGradeType.Size = new System.Drawing.Size(511, 240);
            this.dgvGradeType.TabIndex = 4;
            this.dgvGradeType.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGradeType_CellClick);
            // 
            // btnAddGradeType
            // 
            this.btnAddGradeType.Location = new System.Drawing.Point(414, 18);
            this.btnAddGradeType.Name = "btnAddGradeType";
            this.btnAddGradeType.Size = new System.Drawing.Size(118, 23);
            this.btnAddGradeType.TabIndex = 5;
            this.btnAddGradeType.Text = "Add";
            this.btnAddGradeType.UseVisualStyleBackColor = true;
            this.btnAddGradeType.Click += new System.EventHandler(this.btnAddGradeType_Click);
            // 
            // btnDelGradeType
            // 
            this.btnDelGradeType.Location = new System.Drawing.Point(414, 76);
            this.btnDelGradeType.Name = "btnDelGradeType";
            this.btnDelGradeType.Size = new System.Drawing.Size(118, 23);
            this.btnDelGradeType.TabIndex = 6;
            this.btnDelGradeType.Text = "Delete";
            this.btnDelGradeType.UseVisualStyleBackColor = true;
            this.btnDelGradeType.Click += new System.EventHandler(this.btnDelGradeType_Click);
            // 
            // btnUpdateGradeType
            // 
            this.btnUpdateGradeType.Location = new System.Drawing.Point(414, 47);
            this.btnUpdateGradeType.Name = "btnUpdateGradeType";
            this.btnUpdateGradeType.Size = new System.Drawing.Size(118, 23);
            this.btnUpdateGradeType.TabIndex = 7;
            this.btnUpdateGradeType.Text = "Update";
            this.btnUpdateGradeType.UseVisualStyleBackColor = true;
            this.btnUpdateGradeType.Click += new System.EventHandler(this.btnUpdateGradeType_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(286, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 21);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Has Resit";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // frmAssessmentStructure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnUpdateGradeType);
            this.Controls.Add(this.btnDelGradeType);
            this.Controls.Add(this.btnAddGradeType);
            this.Controls.Add(this.dgvGradeType);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.txtGradeType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmAssessmentStructure";
            this.Text = "Assessment Structure";
            this.Load += new System.EventHandler(this.frmAssessmentStructure_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGradeType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGradeType;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView dgvGradeType;
        private System.Windows.Forms.Button btnAddGradeType;
        private System.Windows.Forms.Button btnDelGradeType;
        private System.Windows.Forms.Button btnUpdateGradeType;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

