using GradeManager.DAOs;
using GradeManager.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmEditCourse : Form
    {
        public string OldCourseName { get; set; }
        public string CourseID { get; set; }
        public frmEditCourse()
        {
            InitializeComponent();
        }

        private void btnEditCourse_Click(object sender, EventArgs e)
        {
            if (txtCourseName.Text.Equals(""))
            {
                MessageBox.Show("Course name cannot be null");
            }
            else
            {
                int rs = CourseDAO.UpdateCourse(new CourseDTO() { CourseID = this.CourseID, CourseName = txtCourseName.Text, Status = 1 });

                if (rs != 1) MessageBox.Show("Error");
                else
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void frmEditCourse_Load(object sender, EventArgs e)
        {
            txtCourseName.Text = OldCourseName;
        }
    }
}
