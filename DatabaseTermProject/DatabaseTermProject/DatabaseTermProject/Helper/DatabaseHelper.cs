using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseTermProject
{
    public static class DatabaseHelper
    {
        public static string ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DatabaseManagementSystemProject;Database=DatabaseManagementSystemProject; Integrated Security = True";

        public static DataTable GetCategories()
        {
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return new DataTable();

            DataTable dtcategory = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *  From TypeOfFood", connection);
            adapter.Fill(dtcategory);
            return dtcategory;
        }
    }
}