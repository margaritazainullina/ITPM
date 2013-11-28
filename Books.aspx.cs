using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Books : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserAuthentication"] != null)
        {

            LoginName LoginName1 = Master.FindControl("LoginName1") as LoginName;
            LoginName1.Visible = true;
            LoginName1.FormatString = "Welcome, " + Session["UserAuthentication"].ToString();
            Label Rating = Master.FindControl("Rating") as Label;
            Rating.Visible = true;
            string s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(s);
            con.Open();
            string sqlUserName;
            sqlUserName = "Select rating FROM [User] WHERE login ='" + Session["UserAuthentication"].ToString() + "'";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentRating = Convert.ToString(cmd.ExecuteScalar());
            if (CurrentRating != null)
                Rating.Text = "Ваш рейтинг=" + CurrentRating;

            Button Exit = Master.FindControl("Exit") as Button;
            Exit.Visible = true;
            Label StatusLb = Master.FindControl("StatusLb") as Label;
            StatusLb.Visible = false;
            Button UserPanelButton = Master.FindControl("UserPanelButton") as Button;
            UserPanelButton.Visible = true;
            Login Login1 = Master.FindControl("Login1") as Login;
            Login1.Visible = false;
            Button Registration = Master.FindControl("Registration") as Button;
            Registration.Visible = false;


            //----
            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);
            SqlCommand commandString = new SqlCommand("SELECT * FROM [category] ", Conn);
            SqlDataAdapter da = new SqlDataAdapter(commandString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            // GridView1.DataSource = ds;
            //GridView1.DataBind();


            int i = 0;
            String[,] categories = new String[ds.Tables[0].Rows.Count, 2];
            foreach (System.Data.DataRow tr in ds.Tables[0].Rows)
            {
                categories[i, 0] = tr[1].ToString();
                categories[i, 1] = tr[2].ToString();
                i++;
            }


            //корневой элемент Root
            Category root = new Category("", null);

            //переводим массив в дерево
            for (int j = 0; j < categories.GetLength(0); j++)
            {
                root.add(categories[j, 0], categories[j, 1], root);
            }

            String path = Server.MapPath("xml");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + "//categories.xml"))
            {
                file.WriteLine(root.print(root));
            }
            if (DetailsView1.Rows.Count > 0)
                LinkButton1.Visible = true;
            else
                LinkButton1.Visible = false;
        }




        else
        {
            Response.Redirect("Index.aspx");
        }

    }



    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        string category = TreeView1.SelectedNode.Text;
        if (category.CompareTo("Все_книги_сайта") != 0)
        {
            string s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(s);
            con.Open();
            string sqlUserName;
            sqlUserName = "Select Id_category FROM [category] WHERE (category =N'" + category + "')";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentCategory = Convert.ToString(cmd.ExecuteScalar());
            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);
            SqlCommand commandString = new SqlCommand("SELECT [Book].Id_book,[Book].name,[Book].publishing,[Book].author, [Book].book_url FROM [Book], [Book_category], [category] WHERE ([category].Id_category=" + CurrentCategory + ") AND ([Book].Id_book = [Book_category].id_book) AND ([category].Id_category = [Book_category].id_category)", Conn);
            SqlDataAdapter da = new SqlDataAdapter(commandString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataSourceID = "";
            GridView1.DataBind();

        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {

            string s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(s);
            con.Open();
            string sqlUserName;
            sqlUserName = "Select rating FROM [User] WHERE login ='" + Session["UserAuthentication"].ToString() + "'";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentRating = Convert.ToString(cmd.ExecuteScalar());
            if (Convert.ToInt32(CurrentRating) != 0)
            {
                string Path = DetailsView1.Rows[1].Cells[1].Text;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path);
                State.Text = "Вы успешно загрузили книгу";
                Label Rating = Master.FindControl("Rating") as Label;
                Rating.Visible = true;
                Rating.Text = "Ваш рейтинг=" + Convert.ToString(Convert.ToInt32(CurrentRating) - 1);
                String strsession1 = "update [user] SET rating=" + Convert.ToString(Convert.ToInt32(CurrentRating) - 1) + " WHERE login ='" + Session["UserAuthentication"].ToString() + "'";
                cmd = new SqlCommand(strsession1, con);
                cmd.ExecuteNonQuery();


                //Response.Redirect("Search.aspx");
                // добавить рейтинг для человека который выставил книгу

                string sqlUserName1 = "Select [User].name from [User],[Book],[Book_user] WHERE ([Book].name='" + DetailsView1.Rows[1].Cells[1].Text + "') AND ([Book].Id_book = [Book_user].book_idbook) AND ([User].Id_user = [Book_user].user_iduser)";
                SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand(sqlUserName1, con);
                string CurrentUser = Convert.ToString(cmd1.ExecuteScalar());
                sqlUserName1 = "Select rating from [User]  WHERE name='" + CurrentUser + "'";
                cmd1 = new System.Data.SqlClient.SqlCommand(sqlUserName1, con);
                string rating = Convert.ToString(cmd1.ExecuteScalar());
                strsession1 = "UPDATE [User] SET rating=" + Convert.ToString(Convert.ToInt32(rating) + 1) + " WHERE name='" + CurrentUser + "'";
                cmd1 = new SqlCommand(strsession1, con);
                cmd1.ExecuteNonQuery();

                con.Close();

            }
            else State.Text = "Не удалось загрузить!!! У вас недостаточно рейтинга!!!";
            //Response.Redirect("Search.aspx");
        }
        catch (Exception ex)
        {
            State.Text = "Не удалось загрузить!!!";
        }
    }
    protected void DetailsView1_DataBound(object sender, EventArgs e)
    {
        if (DetailsView1.Rows.Count > 0)
            LinkButton1.Visible = true;
        else
            LinkButton1.Visible = false;
    }
}