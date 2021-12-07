using GradeManager.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTOs;

namespace WindowsFormsApp1
{
    public partial class frmUser : Form
    {
        public string UserID{get;set;}
        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            dgvGrade.AutoGenerateColumns = false;
            dgvGrade.AllowUserToAddRows = false;
            dgvGrade.ReadOnly = true;

            dgvGrade.Columns.Add("id", "");
            dgvGrade.Columns["id"].DataPropertyName = "id";
            dgvGrade.Columns["id"].Visible = false;
            dgvGrade.Columns.Add("gradeTypeId", "");
            dgvGrade.Columns["gradeTypeId"].DataPropertyName = "gradeTypeId";
            dgvGrade.Columns["gradeTypeId"].Visible = false;
            dgvGrade.Columns.Add("gradeType", "Grade Type");
            dgvGrade.Columns["gradeType"].DataPropertyName = "gradeType";
            dgvGrade.Columns.Add("weight", "Weight");
            dgvGrade.Columns["weight"].DataPropertyName = "weight";
            dgvGrade.Columns.Add("gradeName", "Grade Name");
            dgvGrade.Columns["gradeName"].DataPropertyName = "gradeName";
            dgvGrade.Columns.Add("value", "Value");
            dgvGrade.Columns["value"].DataPropertyName = "value";

            cbSemester.ValueMember = "semesterId";
            cbSemester.DisplayMember = "semesterName";
            LoadSemester();
            //string semId = cbSemester.SelectedValue.ToString();
            lbCourse.DisplayMember = "courseId";


        }

        private void cbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvGrade.DataSource = null;
            string semId = cbSemester.SelectedValue.ToString();
            lbCourse.DataSource = StudentDAO.GetStudentCourse(UserID, semId);
        }
        DataTable dbSem;
        DataTable dbCourse;
        DataTable dbGrade;
        void LoadSemester() {
            dbSem = CourseDAO.GetAllSemester();
            cbSemester.DataSource = dbSem;
        }
        void LoadCourse(string userId, string semId)
        {
            dbCourse = StudentDAO.GetStudentCourse(userId, semId);
            lbCourse.DataSource = dbCourse;
        }
        void LoadGrade(string courseId, int studentCourseId)
        {
            dbGrade = StudentDAO.GetStudentGradeByCourseId(courseId, studentCourseId);
            dgvGrade.DataSource = dbGrade;
        }
        private void lbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)(lbCourse.SelectedItem as DataRowView)["id"];
            DataTable studentCourse = StudentDAO.GetStudentCourseInfo(id);
            StudentCourseDTO dto = new StudentCourseDTO();
            txtResult.Text = "";
            txtGPA.Text = "";
            labelNoti.Text = "";
            foreach (DataRow dr in studentCourse.Rows)
            {
                dto.ID = (int)dr["id"];
                dto.CourseID = (string)dr["courseId"];
                dto.Completed = (bool)dr["completed"];

                if (dr["result"] != DBNull.Value)
                {
                    dto.Result = (string)dr["result"];
                    txtResult.Text = dto.Result;
                }
                if (dr["gpa"] != DBNull.Value)
                {
                    dto.GPA = (double)dr["gpa"];
                    dto.Scale = (double)dr["scale"];
                    txtGPA.Text = dto.GPA.ToString();
                }
            }
            LoadGrade(dto.CourseID, dto.ID);
            if (dto.Result!=null && !dto.Completed)
            {
                if (dto.Result.Equals("NOT PASS"))
                   labelNoti.Text=$"Your curren GPA is {dto.GPA}/{dto.Scale}, less than 50%";
            }
            checkBox1.Checked = dto.Completed;
            
        }

        private bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvGrade[column, row];
            DataGridViewCell cell2 = dgvGrade[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }
        private void dgvGrade_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (e.RowIndex >= 0)
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                if (e.RowIndex >= 1)
                {
                    if (IsTheSameCellValue(1, e.RowIndex))
                    {
                        e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                    }
                    else
                    {
                        e.AdvancedBorderStyle.Top = dgvGrade.AdvancedCellBorderStyle.Top;
                    }
                }
            }
        }

        private void dgvGrade_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex <= 0) return;
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (IsTheSameCellValue(1, e.RowIndex))
                {
                    e.Value = "";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
