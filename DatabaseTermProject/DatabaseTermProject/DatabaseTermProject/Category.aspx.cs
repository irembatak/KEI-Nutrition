using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace DatabaseTermProject
{
    public partial class Category : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rpt1.DataSource = DatabaseHelper.GetCategories();
            rpt1.DataBind();

            string category = Request.QueryString["category"];
            if (category == null)
            {
                string query = Request.QueryString["query"] != null ? Request.QueryString["query"] : "";
                DataTable searchDataTable = Search(query);

                resultCounterSpan.InnerText = searchDataTable.Rows.Count.ToString();
                Repeater.DataSource = searchDataTable;
                Repeater.DataBind();
                return;
            }

            int.TryParse(category, out int categoryId);
            DataTable dataTable = GetCategory(categoryId);

            resultCounterSpan.InnerText = dataTable.Rows.Count.ToString();
            Repeater.DataSource = dataTable;
            Repeater.DataBind();
        }
           

        private DataTable GetCategory(int id)
        {
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            if (connection.State != ConnectionState.Open) 
                return new DataTable();

            DataTable dtcategory = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *  From NutritionalValues WHERE ID=@id", connection);
            adapter.SelectCommand.Parameters.AddWithValue("id", id);

            adapter.Fill(dtcategory);

            connection.Close();
            return dtcategory;
        }

        private DataTable Search(string query)
        {
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return new DataTable();

            DataTable dtcategory = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT *  From NutritionalValues WHERE Nutrition LIKE @query", connection);
            adapter.SelectCommand.Parameters.AddWithValue("query", "%" + query + "%");

            adapter.Fill(dtcategory);
            return dtcategory;
        }
    }
}
