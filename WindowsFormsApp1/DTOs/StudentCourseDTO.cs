using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTOs
{
    public class StudentCourseDTO
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string CourseID { get; set; }
        public string SemesterID { get; set; }
        public bool Completed { get; set; }
        public string Result { get; set; }
        public double GPA { get; set; }
        public bool Status { get; set; }
        public double Scale { get; set; }

        public StudentCourseDTO()
        {
        }

        public StudentCourseDTO(string userID, string courseID, string semesterID)
        {
            UserID = userID;
            CourseID = courseID;
            SemesterID = semesterID;
        }
    }
}
