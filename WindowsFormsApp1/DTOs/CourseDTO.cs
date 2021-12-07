using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager.DTOs
{
    public class CourseDTO
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public int Status { get; set; }

        public CourseDTO()
        {
        }

        public CourseDTO(string courseID, string courseName, int status)
        {
            CourseID = courseID;
            CourseName = courseName;
            Status = status;
        }
    }
}
