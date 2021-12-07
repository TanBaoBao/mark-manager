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
using WindowsFormsApp1;

namespace GradeManager
{
    public partial class frmAdmin : Form
    {
        DataTable dbCourse;
        DataTable dbStudent;
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnSearchCourse_Click(object sender, EventArgs e)
        {
            LoadCourseData(txtSearchCourse.Text);
        }
        public void LoadCourseData(string search)
        {
            dbCourse = CourseDAO.SearchCourse(search);
            dgvCourse.DataSource = dbCourse;
        }
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            LoadTabCourse();
            LoadTabStudentGrade();
        }
        void LoadTabCourse()
        {
            dgvCourse.AutoGenerateColumns = false;
            dgvCourse.AllowUserToAddRows = false;
            DataGridViewCheckBoxColumn selcol = new DataGridViewCheckBoxColumn();
            selcol.HeaderText = "Select";
            selcol.Name = "select";
            selcol.Width = 50;
            dgvCourse.Columns.Add(selcol);
            dgvCourse.Columns.Add("courseId", "Course ID");
            dgvCourse.Columns["courseId"].DataPropertyName = "courseId";
            dgvCourse.Columns["courseId"].Width = 70;
            dgvCourse.Columns.Add("courseName", "Course Name");
            dgvCourse.Columns["courseName"].Width = 210;
            dgvCourse.Columns["courseName"].DataPropertyName = "courseName";

            DataGridViewButtonColumn asDetailCol = new DataGridViewButtonColumn();
            asDetailCol.HeaderText = "Assessment Structure";
            asDetailCol.Name = "as";
            asDetailCol.Text = "Detail";
            asDetailCol.UseColumnTextForButtonValue = true;
            dgvCourse.Columns.Add(asDetailCol);

            DataGridViewButtonColumn gradeDetailCol = new DataGridViewButtonColumn();
            gradeDetailCol.HeaderText = "Course Grade";
            gradeDetailCol.Name = "grade";
            gradeDetailCol.Text = "Detail";
            gradeDetailCol.UseColumnTextForButtonValue = true;
            dgvCourse.Columns.Add(gradeDetailCol);

            DataGridViewButtonColumn editCol = new DataGridViewButtonColumn();
            editCol.HeaderText = "Edit";
            editCol.Name = "editCol";
            editCol.Text = "Edit";
            editCol.UseColumnTextForButtonValue = true;
            dgvCourse.Columns.Add(editCol);

            LoadCourseData("");
        }
        void LoadTabStudentGrade()
        {
            dgvStudent.AutoGenerateColumns = false;
            dgvStudent.AllowUserToAddRows = false;

            dgvStudent.Columns.Add("studentId", "Student ID");
            dgvStudent.Columns["studentId"].DataPropertyName = "userId";

            dgvStudent.Columns.Add("fullName", "Full Name");
            dgvStudent.Columns["fullName"].DataPropertyName = "fullName";

            DataGridViewButtonColumn stuCouCol = new DataGridViewButtonColumn();
            stuCouCol.HeaderText = "Student Course";
            stuCouCol.Name = "studentCourse";
            stuCouCol.Text = "Detail";
            stuCouCol.UseColumnTextForButtonValue = true;
            dgvStudent.Columns.Add(stuCouCol);

            LoadStudentData();

        }
        void LoadStudentData()
        {
            dbStudent = StudentDAO.GetStudents();
            dgvStudent.DataSource = dbStudent;
        }
        private void btnCreateCourse_Click(object sender, EventArgs e)
        {
            frmCreateCourse frm = new frmCreateCourse() { listCourseID = new List<string>() };

            foreach (DataGridViewRow row in dgvCourse.Rows)
            {
                frm.listCourseID.Add(row.Cells["courseId"].Value.ToString());
            }
            DialogResult rs = frm.ShowDialog();
            if (rs == DialogResult.OK)
            {
                txtSearchCourse.Text = "";
                LoadCourseData("");
            }
        }

        private void dgvCourse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvCourse.Columns[e.ColumnIndex].Name.Equals("as"))//da bam nut edit
            {
                frmAssessmentStructure frm = new frmAssessmentStructure();
                frm.courseID = dgvCourse.Rows[e.RowIndex].Cells["courseId"].Value.ToString();
                frm.ShowDialog();
            }
            if (dgvCourse.Columns[e.ColumnIndex].Name.Equals("grade"))//da bam nut edit
            {
                frmCourseGrade frm = new frmCourseGrade();
                frm.CourseID = dgvCourse.Rows[e.RowIndex].Cells["courseId"].Value.ToString();
                frm.ShowDialog();
            }
            if (dgvCourse.Columns[e.ColumnIndex].Name.Equals("editCol"))//da bam nut edit
            {
                frmEditCourse frm = new frmEditCourse();
                frm.CourseID = dgvCourse.Rows[e.RowIndex].Cells["courseId"].Value.ToString();
                frm.OldCourseName = dgvCourse.Rows[e.RowIndex].Cells["courseName"].Value.ToString();
                DialogResult rs= frm.ShowDialog();
                if (rs==DialogResult.OK)
                {
                    MessageBox.Show("Update successfully");
                    txtSearchCourse.Text = "";
                    LoadCourseData("");
                }
            }
        }

        private void btnDeleteCourse_Click(object sender, EventArgs e)
        {
            string message = "Do you want to delete checked data?";
            string title = "Confirmation";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                int count = 0;
                foreach (DataGridViewRow row in dgvCourse.Rows)
                {
                    DataGridViewCheckBoxCell cell = row.Cells["select"] as DataGridViewCheckBoxCell;
                    if (cell.Value != null && (Convert.ToBoolean(cell.Value) == true))
                    {
                        string courseId = row.Cells["courseId"].Value.ToString();
                        count += CourseDAO.DeleteCourse(courseId);
                    }
                }
                if (count > 0)
                {
                    txtSearchCourse.Text = "";
                    MessageBox.Show($"Deleted {count} row(s) successfully");
                    txtSearchCourse.Text = "";
                    LoadCourseData("");
                }
                else MessageBox.Show("Must select at least 1 row");
            }

            
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dgvStudent.Columns[e.ColumnIndex].Name.Equals("studentCourse"))//da bam nut edit
            {
                frmStuCourse frm = new frmStuCourse();
                frm.StudentID = dgvStudent.Rows[e.RowIndex].Cells["studentId"].Value.ToString();
                frm.ShowDialog();
            }
        }
    }
}
