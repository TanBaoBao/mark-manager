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
using GradeManager.DTOs;
using WindowsFormsApp1.DTOs;

namespace WindowsFormsApp1
{
    public partial class frmCourseGrade : Form
    {
        public string CourseID { get; set; }
        DataTable db;
        public frmCourseGrade()
        {
            InitializeComponent();
        }

        private void frmCourseGrade_Load(object sender, EventArgs e)
        {
            DataTable dbType = CourseDAO.GetAllGradeType(CourseID);
            
            if (dbType.Rows.Count == 0)
            {
                MessageBox.Show("Must define at least 1 grade type of this course first");
                this.Close();
            }
            else
            {
                List<GradeTypeDTO> listType = new List<GradeTypeDTO>();
                foreach (DataRow row in dbType.Rows)
                {
                    listType.Add(new GradeTypeDTO((int)row["id"], CourseID, row["gradeType"].ToString(), Convert.ToDouble(row["weight"])));
                }
                cbGradeType.DisplayMember = "GradeType";
                cbGradeType.ValueMember = "ID";
                cbGradeType.DataSource = listType;
            }
            dgvGrade.AutoGenerateColumns = false;
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
            LoadData();
        }
        public void LoadData()
        {
            db = CourseDAO.GetCourseGrade(CourseID);
            dgvGrade.DataSource = db;

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

        private int selectingId=-1;
        private void dgvGrade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (e.ColumnIndex == 4)
            {
                selectingId = (int)dgvGrade.Rows[e.RowIndex].Cells["id"].Value;
                txtGradeName.Text = dgvGrade.Rows[e.RowIndex].Cells["gradeName"].Value.ToString();
                int gradeTypeId = (int)dgvGrade.Rows[e.RowIndex].Cells["gradeTypeId"].Value;
                cbGradeType.SelectedValue = gradeTypeId;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectingId = -1;
            if (txtGradeName.Equals(""))
            {
                MessageBox.Show("Grade name must not be null");
                return;
            }
            CourseGradeDTO dto = new CourseGradeDTO((int)cbGradeType.SelectedValue, txtGradeName.Text, 1);
            int rs=CourseDAO.AddCourseGrade(dto);
            if (rs != 1)
            {
                MessageBox.Show("Add unsuccessfully");
            }
            else
            {
                MessageBox.Show("Add successfully");
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(selectingId==-1)
            {
                MessageBox.Show("Choose a course grade first, click cells in column Grade Name");
                return;
            }
            CourseGradeDTO dto = new CourseGradeDTO(selectingId, (int)cbGradeType.SelectedValue, txtGradeName.Text, 1);
            int rs= CourseDAO.UpdateCourseGrade(dto);
            if (rs != 1)
            {
                MessageBox.Show("Update unsuccessfully");
            }
            else
            {
                MessageBox.Show("Update successfully");
                LoadData();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (selectingId == -1)
            {
                MessageBox.Show("Choose a course grade first, click cells in column Grade Name");
                return;
            }
            int rs = CourseDAO.DeleteCourseGrade(selectingId);
            if (rs != 1)
            {
                MessageBox.Show("Delete unsuccessfully");
            }
            else
            {
                MessageBox.Show("Delete successfully");
                LoadData();
            }
        }
    }
}
