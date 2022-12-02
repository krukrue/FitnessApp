using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public static class DBConnector
    {
        public static SqlConnectionStringBuilder GetBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"dbsys.cs.vsb.cz\STUDENT";
            builder.UserID = "kva0081";         
            builder.Password = "doBxrNSZ2pXJQA3z";
            builder.InitialCatalog = "kva0081";
            return builder;
        }
    }
}
