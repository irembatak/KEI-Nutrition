using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using DatabaseTermProject.Objects;

namespace DatabaseTermProject
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable categoriesDataTable = DatabaseHelper.GetCategories();
            rpt1.DataSource = categoriesDataTable;
            rpt1.DataBind();

            UpdateDetails(categoriesDataTable);
        }

        private void UpdateDetails(DataTable categoriesDataTable)
        {
            string nutrition = Request.QueryString["nutrition"];
            if (nutrition == null)
            {
                deleteButton.Visible = false;
                updateButton.Visible = false;
                createButton.Visible = true;
                nameListEntry.Visible = true;
                headline.InnerText = "Create new entry";
                UpdateCategorySelector(categoriesDataTable, categoryListBox, -1);
                return;
            }

            DataTable nutritionDataTable = GetNutrition(nutrition);
            if (nutritionDataTable.HasErrors || nutritionDataTable.Rows.Count != 1)
                return;

            DataRow nutritionRow = nutritionDataTable.Rows[0];
            Nutrition nutritionValues = MapNutritionValues(nutritionRow);

            headline.InnerText = nutritionValues.Name;
            calorieTextbox.Text = nutritionValues.Calorie;
            carbohydrateTextbox.Text = nutritionValues.Carbohydrate;
            proteinTextbox.Text = nutritionValues.Protein;
            oilTextbox.Text = nutritionValues.Oil;
            fiberTextbox.Text = nutritionValues.Fiber;
            cholesterolTextbox.Text = nutritionValues.Cholesterol;
            sodiumTextbox.Text = nutritionValues.Sodium;
            potassiumTextbox.Text = nutritionValues.Potassium;
            vitaminATextbox.Text = nutritionValues.VitaminA;
            calciumTextbox.Text = nutritionValues.Calcium;
            vitaminCTextbox.Text = nutritionValues.VitaminC;
            ferrousTextbox.Text = nutritionValues.Ferrous;

            deleteButton.Visible = true;
            updateButton.Visible = true;
            createButton.Visible = false;
            nameListEntry.Visible = false;

            UpdateCategorySelector(categoriesDataTable, categoryListBox, (int)nutritionRow["ID"]);
        }

        private DataTable GetNutrition(string nutrition)
        {
            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return new DataTable();

            DataTable dtnutrition = new DataTable();
            
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * From NutritionalValues WHERE Nutrition=@nutrition", connection);
            adapter.SelectCommand.Parameters.AddWithValue("nutrition", nutrition);
            adapter.Fill(dtnutrition);

            connection.Close();
            return dtnutrition;
        }

        private Nutrition MapNutritionValues(DataRow dataRow)
        {
            return new Nutrition(dataRow["Nutrition"].ToString())
            {
                Calorie = dataRow["Calorie_kcal"].ToString(),
                Carbohydrate = dataRow["Carbohydrate_g"].ToString(),
                Protein = dataRow["Protein_g"].ToString(),
                Oil = dataRow["Oil_g"].ToString(),
                Fiber = dataRow["Fiber_g"].ToString(),
                Cholesterol = dataRow["Cholesterol_mg"].ToString(),
                Sodium = dataRow["Sodium_mg"].ToString(),
                Potassium = dataRow["Potassium"].ToString(),
                VitaminA = dataRow["VitaminA_IU"].ToString(),
                Calcium = dataRow["Calcium_mg"].ToString(),
                VitaminC = dataRow["VitaminC_mg"].ToString(),
                Ferrous = dataRow["Ferrous"].ToString()
            };
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            string nutrition = Request.QueryString["nutrition"];
            if (nutrition == null)
                return;

            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return;

            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "DELETE FROM NutritionalValues WHERE Nutrition=@nutrition";
            sqlCommand.Parameters.AddWithValue("nutrition", nutrition);
            sqlCommand.ExecuteNonQuery();

            Response.Redirect("index.aspx");
            connection.Close();
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string nutrition = Request.QueryString["nutrition"];
            if (nutrition == null)
                return;

            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return;

            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "UPDATE NutritionalValues " +
                                     "SET Calorie_kcal=@calorie , Carbohydrate_g=@carbohydrate , Protein_g=@protein, Oil_g=@oil , Fiber_g=@fiber , Cholesterol_mg=@cholesterol ," +
                                     "Sodium_mg=@sodium , Potassium=@potassium , VitaminA_IU=@vitaminA, Calcium_mg=@calcium , VitaminC_mg=@vitaminC , Ferrous=@ferrous , ID=@id " +
                                     "WHERE Nutrition=@nutrition";

            sqlCommand.Parameters.AddWithValue("nutrition", nutrition);
            sqlCommand.Parameters.AddWithValue("calorie", Request.Form["calorieTextbox"]);
            sqlCommand.Parameters.AddWithValue("carbohydrate", Request.Form["carbohydrateTextbox"]);
            sqlCommand.Parameters.AddWithValue("protein", Request.Form["proteinTextbox"]);
            sqlCommand.Parameters.AddWithValue("oil", Request.Form["oilTextbox"]);
            sqlCommand.Parameters.AddWithValue("fiber", Request.Form["fiberTextbox"]);
            sqlCommand.Parameters.AddWithValue("cholesterol", Request.Form["cholesterolTextbox"]);
            sqlCommand.Parameters.AddWithValue("sodium", Request.Form["sodiumTextbox"]);
            sqlCommand.Parameters.AddWithValue("potassium", Request.Form["potassiumTextbox"]);
            sqlCommand.Parameters.AddWithValue("vitaminA", Request.Form["vitaminATextbox"]);
            sqlCommand.Parameters.AddWithValue("calcium", Request.Form["calciumTextbox"]);
            sqlCommand.Parameters.AddWithValue("vitaminC", Request.Form["vitaminCTextbox"]);
            sqlCommand.Parameters.AddWithValue("ferrous", Request.Form["ferrousTextbox"]);
            sqlCommand.Parameters.AddWithValue("id", Request.Form["categoryListBox"]);

            sqlCommand.ExecuteNonQuery();

            connection.Close();

            UpdateDetails(DatabaseHelper.GetCategories());
        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            string nutritionName = Request.Form["nameTextBox"];
            if (GetNutrition(nutritionName).Rows.Count > 0)
            {
                errorSpan.Visible = true;
                errorSpan.InnerText = "Name is already taken";
                return;
            }

            SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString);
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return;

            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = "INSERT INTO NutritionalValues (Nutrition, Calorie_kcal, Carbohydrate_g, Protein_g, Oil_g, Fiber_g, Cholesterol_mg, Sodium_mg, Potassium, VitaminA_IU, Calcium_mg, VitaminC_mg, Ferrous, ID)" +
                                     "VALUES ( @nutrition, @calorie , @carbohydrate , @protein, @oil , @fiber , @cholesterol , @sodium , @potassium , @vitaminA, @calcium , @vitaminC , @ferrous , @id)";

            sqlCommand.Parameters.AddWithValue("nutrition", nutritionName);
            sqlCommand.Parameters.AddWithValue("calorie", Request.Form["calorieTextbox"]);
            sqlCommand.Parameters.AddWithValue("carbohydrate", Request.Form["carbohydrateTextbox"]);
            sqlCommand.Parameters.AddWithValue("protein", Request.Form["proteinTextbox"]);
            sqlCommand.Parameters.AddWithValue("oil", Request.Form["oilTextbox"]);
            sqlCommand.Parameters.AddWithValue("fiber", Request.Form["fiberTextbox"]);
            sqlCommand.Parameters.AddWithValue("cholesterol", Request.Form["cholesterolTextbox"]);
            sqlCommand.Parameters.AddWithValue("sodium", Request.Form["sodiumTextbox"]);
            sqlCommand.Parameters.AddWithValue("potassium", Request.Form["potassiumTextbox"]);
            sqlCommand.Parameters.AddWithValue("vitaminA", Request.Form["vitaminATextbox"]);
            sqlCommand.Parameters.AddWithValue("calcium", Request.Form["calciumTextbox"]);
            sqlCommand.Parameters.AddWithValue("vitaminC", Request.Form["vitaminCTextbox"]);
            sqlCommand.Parameters.AddWithValue("ferrous", Request.Form["ferrousTextbox"]);

            sqlCommand.Parameters.AddWithValue("id", int.TryParse(Request.Form["categoryListBox"], out int foodType) ? foodType : 1);
            sqlCommand.ExecuteNonQuery();

            connection.Close();
            Response.Redirect("Details.aspx?nutrition=" + nutritionName);

            UpdateDetails(DatabaseHelper.GetCategories());
        }

        private void UpdateCategorySelector(DataTable categoriesDataTable, ListBox listBox, int selectedCategory)
        {
            if (listBox == null)
                return;

            listBox.Items.Clear();

            for (int i = 0; i < categoriesDataTable.Rows.Count; i++)
            {
                int typeId = (int)categoriesDataTable.Rows[i]["TypeID"];

                listBox.Items.Add(new ListItem(categoriesDataTable.Rows[i]["TypeFood"].ToString(), typeId.ToString()));
                if (selectedCategory == typeId)
                    listBox.SelectedIndex = i;
            }
        }
    }
}