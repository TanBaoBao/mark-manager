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

namespace GradeManager
{
    public partial class frmCreateCourse : Form
    {
        public List<string> listCourseID { get; set; }
        public frmCreateCourse()
        {
            InitializeComponent();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            string courseID = txtCourseID.Text;
            string courseName = txtCourseName.Text;
            if (txtCourseID.Text.Trim().Equals("") || txtCourseName.Text.Trim().Equals(""))
                MessageBox.Show("Course ID or Name must not be null");
            else
            {
                if (listCourseID.Contains(courseID))
                    MessageBox.Show("Course ID has already existed, please try another");
                else
                {
                    try
                    {
                        int count = 0;
                        CourseDTO c = new CourseDTO(courseID, courseName, 1);
                        bool checkExist = CourseDAO.CheckCourseExist(courseID);
                        if (checkExist)
                        {
                            count = CourseDAO.UpdateCourse(c);
                        }
                        else
                            count = CourseDAO.AddCourse(c);
                        if (count == 1)
                        {
                            MessageBox.Show("Create successfully");
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show("Unsuccesfully, please try again");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void btnCancelFrmAddCourse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
