using GradeManager.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GradeManager.Utils;

namespace GradeManager.DAOs
{
    public class UserDAO
    {
        public UserDTO GetAccount(string userID, string password)
        {
            string roleID = "";
            string fullName= "";
            string majorID= "";
            string SQL = "Select roleID From users where userID=@ID AND password=@password AND status=1 ";
            SqlConnection conn = null;
            try
            {
                conn = DBUtil.GetConnection();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@ID", userID);
                cmd.Parameters.AddWithValue("@password", password);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        roleID = reader.GetString(0);

                        return new UserDTO
                        {
                            UserID = userID,
                            FullName = fullName,
                            Password = "",
                            RoleID = roleID,
                            Status = true,
                            MajorID = majorID

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

        public bool UpdatePassword(string userID, string password)
        {
            bool result;
            string SQL = "Update accounts set password=@password where userID=@ID ";
            SqlConnection conn = null;
            try
            {
                conn = DBUtil.GetConnection();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue("@ID", userID);
                cmd.Parameters.AddWithValue("@password", password);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
    }

}
