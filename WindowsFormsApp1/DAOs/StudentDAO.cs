using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTOs;

namespace GradeManager.DAOs
{
    public static class StudentDAO
    {
        public static DataTable GetStudents()
        {
            string sql = "Select userId, fullName From Users " +
                "Where roleId='stu' AND status =1";

            return DAO.GetDataBySql(sql);
        }
        public static DataTable GetStudentCourse(string studentId)
        {
            string sql = @"select c.id, s.semesterId, s.semesterName, c.courseId, c.completed, c.result, c.gpa  
                            from StudentCourses c, Semesters s
                            where s.semesterId = c.semesterId AND userId=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.NVarChar);
            p1.Value = studentId;
            return DAO.GetDataBySql(sql,p1);
        }
        public static int AddStudentCourse(StudentCourseDTO dto)
        {
            string sql = @"Insert into StudentCourses (userId, courseId, semesterId, completed) 
                            values(@userId, @courseId, @semesterId, 0)";
            SqlParameter p1 = new SqlParameter("@userId", SqlDbType.NVarChar);
            p1.Value = dto.UserID;
            SqlParameter p2 = new SqlParameter("@courseId", SqlDbType.NVarChar);
            p2.Value = dto.CourseID;
            SqlParameter p3 = new SqlParameter("@semesterId", SqlDbType.NVarChar);
            p3.Value = dto.SemesterID;
            return DAO.ExecuteSql(sql, p1, p2, p3);
        }

        public static DataTable GetStudentGradeByCourseId(string courseId, int studentCourseId)
        {
            string sql = @"select b.id,a.*,b.value
                            from StudentGrades b right join
                                (select g.id as courseGradeId, g.gradeTypeId, t.gradeType, t.weight, g.gradeName, t.resitId
                                    from CourseGrades g, CourseGradeTypes t 
                                    Where g.gradeTypeId=t.id AND t.courseId=@courseId AND g.status=1
                                 ) a
                            on b.courseGradeId=a.courseGradeId AND b.studentCourseId=@studentCourseId
                            Order by [weight], gradeType, gradeName";
            SqlParameter p1 = new SqlParameter("@courseId", SqlDbType.NVarChar);
            p1.Value = courseId;
            SqlParameter p2 = new SqlParameter("@studentCourseId", SqlDbType.Int);
            p2.Value = studentCourseId;
            return DAO.GetDataBySql(sql, p1, p2);
        }

        public static int AddStudentGrade(StudentGradeDTO dto)
        {
            string sql = @"Insert into StudentGrades (courseGradeId, value, studentCourseId, status) 
                            values(@courseGradeId, @value, @studentCourseId, 1)";
            SqlParameter p1 = new SqlParameter("@courseGradeId", dto.CourseGradeID);
            SqlParameter p2 = new SqlParameter("@value", SqlDbType.Float);
            if (dto.Value == -1)
                p2.Value = DBNull.Value;
            else
                p2.Value = dto.Value;
            SqlParameter p3 = new SqlParameter("@studentCourseId", dto.StudentCourseID);
            return DAO.ExecuteSql(sql, p1, p2, p3);
        }
        public static int UpdateStudentGrade(int id, double value)
        {
            string sql = @"Update StudentGrades set 
                            value=@value
                            where id=@id";
            SqlParameter p1 = new SqlParameter("@id", id);
            SqlParameter p2 = new SqlParameter("@value", SqlDbType.Float);
            if (value == -1)
                p2.Value = DBNull.Value;
            else
                p2.Value = value;
            return DAO.ExecuteSql(sql, p1, p2);
        }
        public static int UpdateGPA(int id, double gpa, double scale)
        {
            string sql = @"Update StudentCourses set 
                            gpa=@gpa, scale=@scale, result=@result
                            where id=@id";
            SqlParameter p1 = new SqlParameter("@id", id);
            SqlParameter p2 = new SqlParameter("@gpa", gpa);
            SqlParameter p3 = new SqlParameter("@scale", scale);
            string result = "";
            if ((gpa / scale) >= 0.5)
                result = "PASS";
            else
                result = "NOT PASS";
            SqlParameter p4 = new SqlParameter("@result", result);

            return DAO.ExecuteSql(sql, p1, p2, p3,p4);
        }
        public static int UpdateState(int id, bool state)
        {
            string sql = @"Update StudentCourses set 
                            completed=@completed
                            where id=@id";
            SqlParameter p1 = new SqlParameter("@id", id);
            SqlParameter p2 = new SqlParameter("@completed", state);
           

            return DAO.ExecuteSql(sql, p1,p2);
        }
        public static DataTable GetStudentCourse(string studentId, string semesterId)
        {
            string sql = @"select c.id, s.semesterId, s.semesterName, c.courseId, c.completed, c.result, c.gpa  
                            from StudentCourses c, Semesters s
                            where s.semesterId = c.semesterId AND userId=@id AND c.semesterId= @semId";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.NVarChar);
            p1.Value = studentId;
            SqlParameter p2 = new SqlParameter("@semId", semesterId);
            return DAO.GetDataBySql(sql, p1,p2);
        }
        public static DataTable GetStudentCourseInfo(int id)
        {
            string sql = @"select *  
                            from StudentCourses 
                            where id=@id";
            SqlParameter p1 = new SqlParameter("@id", id);
            
            return DAO.GetDataBySql(sql, p1);
        }
    }

}
