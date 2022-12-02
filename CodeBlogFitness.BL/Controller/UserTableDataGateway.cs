using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class UserTableDataGateway
    {
        public DataTable Load()
        {
            var query = "select * from Users;";

            var result = new DataTable();

            var connString = DBConnector.GetBuilder().ConnectionString;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        result.Load(reader);
                    }
                }
            }
            return result;
        }
    }
}
