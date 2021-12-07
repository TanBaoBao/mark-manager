using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeManager.Utils
{
    public static class DBUtil
    {
        public static SqlConnection GetConnection()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["MyConStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(strConnection);
            return conn;
        }
    }
}
