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

namespace GradeManager
{
    public partial class frmAssessmentStructure : Form
    {
        public string courseID;
        private List<GradeTypeDTO> listGT;
        private double total;
        private DataTable db;
        public frmAssessmentStructure()
        {
            InitializeComponent();
        }

        private void frmAssessmentStructure_Load(object sender, EventArgs e)
        {
            dgvGradeType.ReadOnly = false;
            dgvGradeType.AutoGenerateColumns = false;
            dgvGradeType.AllowUserToAddRows = false;
            dgvGradeType.Columns.Add("id", "id");
            dgvGradeType.Columns["id"].DataPropertyName = "id";
            dgvGradeType.Columns["id"].Visible = false;
            dgvGradeType.Columns.Add("gradeType", "Grade Type");
            dgvGradeType.Columns["gradeType"].DataPropertyName = "gradeType";
            dgvGradeType.Columns.Add("weight", "Weight");
            dgvGradeType.Columns["weight"].DataPropertyName = "weight";
            dgvGradeType.Columns["weight"].DefaultCellStyle.Format = "#0%";
            dgvGradeType.Columns.Add("hasResit", "Has Resit");
            dgvGradeType.Columns["hasResit"].DataPropertyName = "hasResit";
            LoadData();
        }
        public void LoadData()
        {
            db = CourseDAO.GetCourseGradeType(courseID);
            listGT = new List<GradeTypeDTO>();
            foreach (DataRow row in db.Rows)
            {
                listGT.Add(new GradeTypeDTO(courseID, row["gradeType"].ToString(), Convert.ToDouble(row["weight"]), (bool)row["hasResit"], 1));
            }
            dgvGradeType.DataSource = db;
            for (int i = 0; i < dgvGradeType.RowCount - 1; i++)
            {
                DataGridViewRow row = dgvGradeType.Rows[i];
                if (row.Cells["gradeType"].Value.ToString().IndexOf("resit", StringComparison.OrdinalIgnoreCase) > 0)
                    row.Visible = false;
            }
        }

        private int selectingId = -1;

        private void btnAddGradeType_Click(object sender, EventArgs e)
        {
            selectingId = -1;
            bool flag = true;
            if (txtGradeType.Text.Equals("") || numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Input Data is invalid");
                flag = false;
                return;
            }
            double totalWeight = Convert.ToDouble(numericUpDown1.Value / 100);
            foreach (GradeTypeDTO tmp in listGT)
            {
                if (txtGradeType.Text.Equals(tmp.GradeType, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Grade type has already existed, please try another");
                    flag = false;
                    return;
                }

                totalWeight += tmp.Weight;
            }
            if (totalWeight > 1)
            {
                MessageBox.Show("Total weight > 100%, cannot add, please try another");
                flag = false;
                return;
            }
            if (flag)
            {
                GradeTypeDTO gt = new GradeTypeDTO(courseID, txtGradeType.Text, Convert.ToDouble(numericUpDown1.Value / 100), checkBox1.Checked, 1);
                int id = -1;
                id = CourseDAO.AddGradeType(gt);
                gt.ID = id;
                if (gt.HasResit)
                {
                    GradeTypeDTO resit = new GradeTypeDTO(gt.CourseID, gt.GradeType + " Resit", gt.Weight, 1);
                    resit.ResitID = gt.ID;
                    CourseDAO.AddResit(resit);
                }
                if (id != -1)
                {
                    MessageBox.Show("Add successfully");
                    LoadData();
                }

            }
        }

        private void btnUpdateGradeType_Click(object sender, EventArgs e)
        {
            if (selectingId == -1)
            {
                MessageBox.Show("Choose row first");
                return;
            }
            bool flag = true;
            if (txtGradeType.Text.Equals("") || numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Input Data is invalid");
                flag = false;
            }
            double totalWeight = Convert.ToDouble(numericUpDown1.Value / 100);
            foreach (DataGridViewRow row in dgvGradeType.Rows)
            {
                if ((int)row.Cells["id"].Value != selectingId)
                    totalWeight += (double)row.Cells["weight"].Value;

            }
            if (totalWeight > 1)
            {
                MessageBox.Show("Total weight > 100%, cannot add, please try another");
                flag = false;
            }
            if (flag)
            {
                GradeTypeDTO gt = new GradeTypeDTO(courseID, txtGradeType.Text, Convert.ToDouble(numericUpDown1.Value / 100), checkBox1.Checked, 1);

                int rs = CourseDAO.UpdateGradeType(selectingId, gt);

                if (rs != 0)
                {
                    GradeTypeDTO resit = CourseDAO.GetResit(selectingId);
                    if (gt.HasResit)
                    {
                        if (resit == null)
                        {
                            resit = new GradeTypeDTO(gt.CourseID, gt.GradeType + " Resit", gt.Weight, 1);
                            resit.ResitID = selectingId;
                            rs = CourseDAO.AddResit(resit);
                        }
                        else
                        {
                            resit.GradeType = gt.GradeType + " Resit";
                            resit.Weight = gt.Weight;
                            resit.Status = 1;
                            rs = CourseDAO.UpdateResit(resit);
                        }
                    }
                    else
                    {
                        if (resit != null)
                        {
                            rs = CourseDAO.DelGradeType(resit.ID);
                        }
                    }
                    if (rs == 0) MessageBox.Show("Error: Resit");
                    else
                        MessageBox.Show("Update successfully");
                    LoadData();
                }
            }
        }

        private void btnDelGradeType_Click(object sender, EventArgs e)
        {
            if (selectingId == -1)
            {
                MessageBox.Show("Choose row first");
                return;
            }
            CourseDAO.DelGradeType(selectingId);
            GradeTypeDTO resit = CourseDAO.GetResit(selectingId);
            if (resit != null)
                CourseDAO.DelGradeType(resit.ID);
            LoadData();
            MessageBox.Show("Delete successfully");
            txtGradeType.Text = "";
            numericUpDown1.Value = 0;
            checkBox1.Checked = false;
        }
        private void dgvGradeType_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            selectingId = (int)dgvGradeType.Rows[e.RowIndex].Cells["id"].Value;
            txtGradeType.Text = dgvGradeType.Rows[e.RowIndex].Cells["gradeType"].Value.ToString();
            numericUpDown1.Value = Convert.ToInt32((Convert.ToDouble(dgvGradeType.Rows[e.RowIndex].Cells["weight"].Value) * 100));
            checkBox1.Checked = (bool)dgvGradeType.Rows[e.RowIndex].Cells["hasResit"].Value;
        }
    }
}
