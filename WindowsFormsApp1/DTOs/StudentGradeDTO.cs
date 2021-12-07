using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTOs
{
    public class StudentGradeDTO
    {
        public int ID { get; set; }
        public int CourseGradeID { get; set; }
        public double Value { get; set; }
        public int StudentCourseID { get; set; }
    }
}
