using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager.DTOs
{
    public class GradeTypeDTO
    {
        public int ID { get; set; }
        public string CourseID { get; set; }
        public string GradeType { get; set; }
        public double Weight { get; set; }
        public bool HasResit { get; set; }
        public int ResitID { get; set; }
        public int Status { get; set; }

        public GradeTypeDTO(int iD, string courseID, string gradeType, double weight)
        {
            ID = iD;
            CourseID = courseID;
            GradeType = gradeType;
            Weight = weight;
        }

        public GradeTypeDTO(string courseID, string gradeType, double weight, int status)
        {
            CourseID = courseID;
            GradeType = gradeType;
            Weight = weight;
            Status = status;
        }

        public GradeTypeDTO(string courseID, string gradeType, double weight, bool hasResit, int status)
        {
            CourseID = courseID;
            GradeType = gradeType;
            Weight = weight;
            HasResit = hasResit;
            Status = status;
        }
        

        public GradeTypeDTO()
        {
        }



        public override bool Equals(object obj)
        {
            if (obj is GradeTypeDTO)
                return this.ID.Equals(((GradeTypeDTO)obj).ID);
            else return false;
        }

        public override int GetHashCode()
        {
            return ID;
        }
    }
}
