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
using WindowsFormsApp1.DTOs;

namespace WindowsFormsApp1
{
    public partial class frmStudentGrade : Form
    {
        public int StudentCourseId { get; set; }
        public string CourseId { get; set; }
        public bool isComplete { get; set; }
        DataTable db;

        public frmStudentGrade()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            db = StudentDAO.GetStudentGradeByCourseId(CourseId, StudentCourseId);
            dgvStudentGrade.DataSource = db;
        }

        private void frmStudentGrade_Load(object sender, EventArgs e)
        {
            dgvStudentGrade.AllowUserToAddRows = false;
            dgvStudentGrade.AutoGenerateColumns = false;

            dgvStudentGrade.Columns.Add("id", "");
            dgvStudentGrade.Columns["id"].DataPropertyName = "id";
            dgvStudentGrade.Columns["id"].Visible = false;
            dgvStudentGrade.Columns.Add("courseGradeId", "");
            dgvStudentGrade.Columns["courseGradeId"].DataPropertyName = "courseGradeId";
            dgvStudentGrade.Columns["courseGradeId"].Visible = false;
            dgvStudentGrade.Columns.Add("gradeTypeId", "");
            dgvStudentGrade.Columns["gradeTypeId"].DataPropertyName = "gradeTypeId";
            dgvStudentGrade.Columns["gradeTypeId"].Visible = true;
            dgvStudentGrade.Columns.Add("weight", "");
            dgvStudentGrade.Columns["weight"].DataPropertyName = "weight";
            dgvStudentGrade.Columns["weight"].Visible = false;
            dgvStudentGrade.Columns.Add("gradeName", "Grade Name");
            dgvStudentGrade.Columns["gradeName"].DataPropertyName = "gradeName";
            dgvStudentGrade.Columns.Add("value", "Value");
            dgvStudentGrade.Columns["value"].DataPropertyName = "value";
            dgvStudentGrade.Columns.Add("resitId", "resitId");
            dgvStudentGrade.Columns["resitId"].DataPropertyName = "resitId";
            dgvStudentGrade.Columns["resitId"].Visible = false;

            //dgvStudentGrade.ReadOnly = true;

            dgvStudentGrade.Columns["gradeName"].ReadOnly = true;
            LoadData();
            checkBox1.Checked = isComplete;
        }

        private void dgvStudentGrade_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStudentGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals(""))
                return;
            double result = Convert.ToDouble(dgvStudentGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            if (!(result > 10 || result < 0))
            {
                dgvStudentGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Math.Round(result, 1);
            }
            else
            {
                MessageBox.Show("Value must be from 0 to 10");
                dgvStudentGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
            }
        }
        double gpa = -1;
        double scale = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            gpa = 0;
            scale = 0;
            Dictionary<GradeTypeDTO, List<double>> gradeDic;
            Dictionary<int, int> scaleDic;
            scaleDic = new Dictionary<int, int>();
            gradeDic = new Dictionary<GradeTypeDTO, List<double>>();
            foreach (DataGridViewRow row in dgvStudentGrade.Rows)
            {
                GradeTypeDTO gType = new GradeTypeDTO()
                {
                    ID = (int)row.Cells["gradeTypeId"].Value,
                    Weight = (double)row.Cells["weight"].Value
                };
                double grade = 0;
                if (row.Cells["value"].Value != DBNull.Value)
                {
                    grade = Convert.ToDouble(row.Cells["value"].Value);
                }

                if (gradeDic.ContainsKey(gType))
                {
                    gradeDic[gType].Add(grade);

                }
                else
                {
                    List<double> gradeList = new List<double>();
                    gradeList.Add(grade);
                    gradeDic.Add(gType, gradeList);
                }
                int gTypeID = (int)row.Cells["gradeTypeId"].Value;
                if (scaleDic.ContainsKey(gTypeID))
                {
                    scaleDic[gTypeID] += 1;

                }
                else
                {
                    scaleDic.Add(gTypeID, 1);
                }
            }
            foreach (DataGridViewRow row in dgvStudentGrade.Rows)
            {
                if (row.Cells["resitId"].Value != DBNull.Value && row.Cells["value"].Value != DBNull.Value)
                {
                    gradeDic.Remove(new GradeTypeDTO() { ID = (int)row.Cells["resitId"].Value });
                    scaleDic.Remove((int)row.Cells["resitId"].Value);
                }
            }
            foreach (KeyValuePair<GradeTypeDTO, List<double>> tmp in gradeDic)
            {
                GradeTypeDTO gradeType = tmp.Key;
                List<double> gradeList = tmp.Value;
                double total = 0;
                foreach (double grade in gradeList)
                {
                    total += grade;
                }
                gpa += (total / gradeList.Count) * gradeType.Weight;
            }
            txtGPA.Text = Math.Round(gpa, 1).ToString();
            foreach (DataGridViewRow row in dgvStudentGrade.Rows)
            {
                if ((row.Cells["value"].Value != DBNull.Value) && scaleDic.ContainsKey((int)row.Cells["gradeTypeId"].Value))
                {
                    double gradeWeight = (double)row.Cells["weight"].Value / scaleDic[(int)row.Cells["gradeTypeId"].Value];
                    scale += 10 * gradeWeight;
                }
            }
            //MessageBox.Show(scale.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvStudentGrade.Rows)
            {

                if (row.Cells["id"].Value == DBNull.Value)
                {
                    StudentGradeDTO stuGrade = new StudentGradeDTO();
                    stuGrade.StudentCourseID = StudentCourseId;
                    stuGrade.CourseGradeID = (int)row.Cells["courseGradeId"].Value;
                    if (row.Cells["value"].Value == DBNull.Value)
                        stuGrade.Value = -1;
                    else stuGrade.Value = (double)row.Cells["value"].Value;
                    StudentDAO.AddStudentGrade(stuGrade);
                }
                else
                {
                    double value;
                    if (row.Cells["value"].Value == DBNull.Value)
                        value = -1;
                    else value = (double)row.Cells["value"].Value;
                    StudentDAO.UpdateStudentGrade((int)row.Cells["id"].Value, value);
                }
            }
            if (gpa != -1)
            {
                StudentDAO.UpdateGPA(StudentCourseId, Math.Round(gpa, 1), Math.Round(scale, 1));
            }
            StudentDAO.UpdateState(StudentCourseId, checkBox1.Checked);
            MessageBox.Show("Update successfully");
        }
    }
}

