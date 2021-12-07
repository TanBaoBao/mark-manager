using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTOs
{
    public class CourseGradeDTO
    {
        public int ID { get; set; }
        public int GradeTypeID { get; set; }
        public string GradeName { get; set; }
        public int Status { get; set; }

        public CourseGradeDTO(int iD, int gradeTypeID, string gradeName, int status)
        {
            ID = iD;
            GradeTypeID = gradeTypeID;
            GradeName = gradeName;
            Status = status;
        }

        public CourseGradeDTO()
        {
        }

        public CourseGradeDTO(int gradeTypeID, string gradeName, int status)
        {
            GradeTypeID = gradeTypeID;
            GradeName = gradeName;
            Status = status;
        }
    }
}
