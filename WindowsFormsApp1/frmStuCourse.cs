using GradeManager.DAOs;
using GradeManager.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTOs;

namespace WindowsFormsApp1
{
    public partial class frmStuCourse : Form
    {
        DataTable db;

        public string StudentID { get; set; }

        public frmStuCourse()
        {
            InitializeComponent();
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmStuCourse_Load(object sender, EventArgs e)

        {
            DataTable dbCourse = CourseDAO.SearchCourse("");
            DataTable dbSemester = CourseDAO.GetAllSemester();
            if (dbCourse.Rows.Count == 0 || dbSemester.Rows.Count == 0)
            {
                MessageBox.Show("Must define at least 1 course and 1 semester first");
                this.Close();
            }
            cbCourseId.DisplayMember = "courseId";
            cbCourseId.ValueMember = "courseId";
            cbCourseId.DataSource = dbCourse;

            cbSemester.DisplayMember = "semesterName";
            cbSemester.ValueMember = "semesterId";
            cbSemester.DataSource = dbSemester;

            dgvStuCourse.AutoGenerateColumns = false;
            dgvStuCourse.AllowUserToAddRows = false;
            dgvStuCourse.ReadOnly = true;

            dgvStuCourse.Columns.Add("id", "");
            dgvStuCourse.Columns["id"].DataPropertyName = "id";
            dgvStuCourse.Columns["id"].Visible = false;
            dgvStuCourse.Columns.Add("semesterId", "");
            dgvStuCourse.Columns["semesterId"].DataPropertyName = "semesterId";
            dgvStuCourse.Columns["semesterId"].Visible = false;
            dgvStuCourse.Columns.Add("semesterName", "Semester Name");
            dgvStuCourse.Columns["semesterName"].DataPropertyName = "semesterName";
            dgvStuCourse.Columns.Add("courseId", "Course ID");
            dgvStuCourse.Columns["courseId"].DataPropertyName = "courseId";
            dgvStuCourse.Columns.Add("result", "Result");
            dgvStuCourse.Columns["result"].DataPropertyName = "result";
            dgvStuCourse.Columns.Add("gpa", "GPA");
            dgvStuCourse.Columns["gpa"].DataPropertyName = "gpa";
            dgvStuCourse.Columns["gpa"].Width = 60;
            dgvStuCourse.Columns.Add("completed", "is Completed");
            dgvStuCourse.Columns["completed"].DataPropertyName = "completed";
            dgvStuCourse.Columns["completed"].Width = 80;

            DataGridViewButtonColumn detailCol = new DataGridViewButtonColumn();
            detailCol.HeaderText = "Detail";
            detailCol.Name = "detail";
            detailCol.Text = "Detail";
            detailCol.UseColumnTextForButtonValue = true;
            dgvStuCourse.Columns.Add(detailCol);
            DataGridViewButtonColumn deleteCol = new DataGridViewButtonColumn();
            deleteCol.HeaderText = "Delete";
            deleteCol.Name = "delete";
            deleteCol.Text = "Delete";
            deleteCol.UseColumnTextForButtonValue = true;
            dgvStuCourse.Columns.Add(deleteCol);
            LoadData();

        }
        void LoadData()
        {
            db = StudentDAO.GetStudentCourse(StudentID);
            dgvStuCourse.DataSource = db;
        }
        private int selectingId = -1;
        private void btnAdd_Click(object sender, EventArgs e)
        {

            string courseId = (string)cbCourseId.SelectedValue;
            string semesterId = (string)cbSemester.SelectedValue;
            foreach (DataGridViewRow row in dgvStuCourse.Rows)
            {
                if (row.Cells["semesterId"].Value.ToString().Equals(semesterId) && row.Cells["courseId"].Value.ToString().Equals(courseId))
                {
                    MessageBox.Show("Error: Dupplicate course and semester");
                    return;
                }
            }
            StudentCourseDTO dto = new StudentCourseDTO(StudentID, courseId, semesterId);
            int rs = StudentDAO.AddStudentCourse(dto);
            if (rs == 1)
            {
                MessageBox.Show("Add successfully");
                LoadData();
            }
            else
            {
                MessageBox.Show("Add unsuccessfully");
            }

        }

        private void dgvStuCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvStuCourse.Columns[e.ColumnIndex].Name.Equals("detail"))//da bam nut edit
            {
                frmStudentGrade frm = new frmStudentGrade();
                frm.StudentCourseId =(int) dgvStuCourse.Rows[e.RowIndex].Cells["id"].Value;

                frm.CourseId = dgvStuCourse.Rows[e.RowIndex].Cells["courseId"].Value.ToString();
                frm.isComplete= (bool)dgvStuCourse.Rows[e.RowIndex].Cells["completed"].Value;
                frm.ShowDialog();
                LoadData();
            }
        }
    }
}
