using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

namespace DatabaseTermProject
{
    public partial class index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rpt1.DataSource = DatabaseHelper.GetCategories();
            rpt1.DataBind();

            if (!Page.IsPostBack) 
                return;
            
            string query =  Request.Form["searchTextbox"]; 
            if (query == null)
                return;

            Response.Redirect("Category.aspx?query=" + query);
        }
    }
}