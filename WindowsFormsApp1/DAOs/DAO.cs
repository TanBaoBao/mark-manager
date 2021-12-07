using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager.DAOs
{
    public class DAO
    {
        public static SqlConnection GetConnection()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["MyConStr"].ToString();
            return new SqlConnection(ConnectionString);
        }

        public static DataTable GetDataBySql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand(sql, GetConnection());
                if (parameters.Length != 0)
                    command.Parameters.AddRange(parameters);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds.Tables[0];
            }
            catch
            {
                throw;
            }

        }

        public static int ExecuteSql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand(sql, GetConnection());
                if (parameters.Length != 0)
                    command.Parameters.AddRange(parameters);
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.SelectCommand = command;
                command.Connection.Open();
                int count = command.ExecuteNonQuery();
                return count;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (command != null)
                    command.Connection.Close();
            }
        }
        public static int ExecuteScalarSql(string sql, params SqlParameter[] parameters)
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand(sql, GetConnection());
                if (parameters.Length != 0)
                    command.Parameters.AddRange(parameters);
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.SelectCommand = command;
                command.Connection.Open();
                int id = (int)command.ExecuteScalar();
                return id;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (command != null)
                    command.Connection.Close();
            }
        }
    }
}
