using GradeManager.DTOs;
using GradeManager.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeManager.DTOs;
using WindowsFormsApp1.DTOs;

namespace GradeManager.DAOs
{
    public static class CourseDAO
    {
        public static DataTable SearchCourse(string searchTxt)
        {
            string sql = "Select courseId, courseName From Courses " +
                "Where ((courseId like '%'+ @search +'%') OR (courseName like '%'+ @search +'%')) AND status =1";
            SqlParameter p1 = new SqlParameter("@search", SqlDbType.NVarChar);
            p1.Value = searchTxt;
            return DAO.GetDataBySql(sql, p1);
        }

        public static int AddCourse(CourseDTO c)
        {
            string sql = @"Insert into Courses values(@id, @name, @status)";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
            p1.Value = c.CourseID;
            SqlParameter p2 = new SqlParameter("@name", SqlDbType.VarChar);
            p2.Value = c.CourseName;
            SqlParameter p3 = new SqlParameter("@status", SqlDbType.Int);
            p3.Value = c.Status;
            return DAO.ExecuteSql(sql, p1, p2, p3);
        }
        public static Boolean CheckCourseExist(string id)
        {
            string SQL = "Select courseId From Courses Where courseId=@id";
            SqlConnection conn = null;
            try
            {
                conn = DBUtil.GetConnection();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public static int UpdateCourse(CourseDTO c)
        {
            string sql = "Update Courses " +
                "set courseName=@name, status=1 " +
                "where courseId=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.VarChar);
            p1.Value = c.CourseID;
            SqlParameter p2 = new SqlParameter("@name", SqlDbType.VarChar);
            p2.Value = c.CourseName;

            return DAO.ExecuteSql(sql, p1, p2);
        }
        public static int DeleteCourse(string id)
        {
            string sql = "Update Courses " +
                "set status=0 " +
                "where courseId=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.NVarChar);
            p1.Value = id;
            return DAO.ExecuteSql(sql, p1);
        }

        public static DataTable GetCourseGradeType(string courseID)
        {
            //List < GradeTypeDTO> list = null;
            string sql = @"Select id, gradeType, weight, hasResit From CourseGradeTypes " +
                "Where courseId=@id AND status =1 AND resitId IS NULL";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.NVarChar);
            p1.Value = courseID;
            return DAO.GetDataBySql(sql, p1);
            //if (db!= null || db.Rows.Count != 0)
            //{
            //    foreach (DataRow row in db.Rows)
            //        list.Add(new GradeTypeDTO(courseID, (string)row["gradeType"], Convert.ToDouble(row["weight"])));

            //}
            //return list;
        }
        public static int AddGradeType(GradeTypeDTO gt)
        {
            string sql = @"Insert into CourseGradeTypes(courseId, gradeType, weight, hasResit, status) 
                            output INSERTED.id values(@courseid, @type, @weight, @hasResit, @status)";
            SqlParameter p1 = new SqlParameter("@courseid", SqlDbType.VarChar);
            p1.Value = gt.CourseID;
            SqlParameter p2 = new SqlParameter("@type", SqlDbType.VarChar);
            p2.Value = gt.GradeType;
            SqlParameter p3 = new SqlParameter("@weight", SqlDbType.Float);
            p3.Value = gt.Weight;
            SqlParameter p4 = new SqlParameter("@hasResit", SqlDbType.Bit);
            p4.Value = gt.HasResit;
            SqlParameter p5 = new SqlParameter("@status", SqlDbType.Int);
            p5.Value = gt.Status;
            return DAO.ExecuteScalarSql(sql, p1, p2, p3, p4, p5);
        }

        public static int UpdateGradeType(int id, GradeTypeDTO gt)
        {
            string sql = "Update CourseGradeTypes " +
                "set gradeType=@type, weight=@weight, hasResit=@hasResit " +
                "where id=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;

            SqlParameter p2 = new SqlParameter("@type", SqlDbType.VarChar);
            p2.Value = gt.GradeType;
            SqlParameter p3 = new SqlParameter("@weight", SqlDbType.Float);
            p3.Value = gt.Weight;
            SqlParameter p4 = new SqlParameter("@hasResit", SqlDbType.Bit);
            p4.Value = gt.HasResit;
            return DAO.ExecuteSql(sql, p1, p2, p3, p4);
        }
        public static int DelGradeType(int id)
        {
            string sql = "Update CourseGradeTypes " +
                "set status=@status " +
                "where id=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;

            SqlParameter p2 = new SqlParameter("@status", SqlDbType.Int);
            p2.Value = 0;

            return DAO.ExecuteSql(sql, p1, p2);
        }

        public static GradeTypeDTO GetResit(int _resitId)
        {
            int id;
            int status;
            string SQL = "Select * From CourseGradeTypes Where resitId is not null and resitId=@id";
            SqlConnection conn = null;
            try
            {
                conn = DBUtil.GetConnection();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@id", _resitId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        id = (int)reader["id"];
                        status = (int)reader["status"];

                        return new GradeTypeDTO()
                        {
                            ID = id,
                            ResitID = _resitId,
                            Status = status
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        public static int UpdateResit(GradeTypeDTO gt)
        {
            string sql = "Update CourseGradeTypes " +
                "set gradeType=@type, weight=@weight, resitId=@resitId, status=1  " +
                "where id=@id";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = gt.ID;
            SqlParameter p2 = new SqlParameter("@type", SqlDbType.VarChar);
            p2.Value = gt.GradeType;
            SqlParameter p3 = new SqlParameter("@weight", SqlDbType.Float);
            p3.Value = gt.Weight;
            SqlParameter p4 = new SqlParameter("@resitId", SqlDbType.Int);
            p4.Value = gt.ResitID;
            return DAO.ExecuteSql(sql, p1, p2, p3, p4);
        }
        public static int AddResit(GradeTypeDTO resit)
        {
            string sql = "Insert into CourseGradeTypes(courseId, gradeType, weight, resitId, status) " +
                "values(@courseid, @type, @weight, @resitId, @status)";
            SqlParameter p1 = new SqlParameter("@courseid", SqlDbType.VarChar);
            p1.Value = resit.CourseID;
            SqlParameter p2 = new SqlParameter("@type", SqlDbType.VarChar);
            p2.Value = resit.GradeType;
            SqlParameter p3 = new SqlParameter("@weight", SqlDbType.Float);
            p3.Value = resit.Weight;
            SqlParameter p4 = new SqlParameter("@resitId", SqlDbType.Int);
            p4.Value = resit.ResitID;
            SqlParameter p5 = new SqlParameter("@status", SqlDbType.Int);
            p5.Value = resit.Status;
            return DAO.ExecuteSql(sql, p1, p2, p3, p4, p5);
        }

        public static DataTable GetAllGradeType(string courseID)
        {
            string sql = @"Select id, gradeType, weight, hasResit From CourseGradeTypes " +
                "Where courseId=@id AND status =1 ";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.NVarChar);
            p1.Value = courseID;
            return DAO.GetDataBySql(sql, p1);

        }
        public static DataTable GetCourseGrade(string courseID)
        {
            string sql = @"select g.iD, g.gradeTypeId, t.gradeType, t.weight, g.gradeName  
                            from CourseGrades g, CourseGradeTypes t 
                            Where g.gradeTypeId=t.id AND t.courseId=@id AND g.status=1
                            Order by [weight], gradeType, gradeName ";
            SqlParameter p1 = new SqlParameter("@id", SqlDbType.NVarChar);
            p1.Value = courseID;
            return DAO.GetDataBySql(sql, p1);
        }
        public static int AddCourseGrade(CourseGradeDTO dto)
        {
            string sql = @"Insert into CourseGrades values(@gradeTypeId, @gradeName, 1)";
            SqlParameter p1 = new SqlParameter("@gradeTypeId", SqlDbType.Int);
            p1.Value = dto.GradeTypeID;
            SqlParameter p2 = new SqlParameter("@gradeName", SqlDbType.NVarChar);
            p2.Value = dto.GradeName;
            return DAO.ExecuteSql(sql, p1, p2);
        }

        public static int UpdateCourseGrade(CourseGradeDTO dto)
        {
            string sql = @"Update CourseGrades
                            set gradeTypeId=@gradeTypeId, gradeName=@gradeName, status=@status 
                            where id=@id";
            SqlParameter p1 = new SqlParameter("@gradeTypeId", SqlDbType.Int);
            p1.Value = dto.GradeTypeID;
            SqlParameter p2 = new SqlParameter("@gradeName", SqlDbType.NVarChar);
            p2.Value = dto.GradeName;
            SqlParameter p3 = new SqlParameter("@status", SqlDbType.Int);
            p3.Value = dto.Status;
            SqlParameter p4 = new SqlParameter("@id", SqlDbType.Int);
            p4.Value = dto.ID;
            return DAO.ExecuteSql(sql, p1, p2, p3, p4);
        }
        public static int DeleteCourseGrade(int id)
        {
            string sql = @"Update CourseGrades  
                            set status=0
                            where id=@id";

            SqlParameter p1 = new SqlParameter("@id", SqlDbType.Int);
            p1.Value = id;
            return DAO.ExecuteSql(sql, p1);
        }

        public static DataTable GetAllSemester()
        {
            string sql = @"select semesterId, semesterName, startDate
                            from Semesters
                            Where status=1
                            Order by startDate DESC";
            
            return DAO.GetDataBySql(sql);
        }
    }
}
