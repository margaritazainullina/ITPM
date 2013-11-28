using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
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
            // отображение рубрик
            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);
            SqlCommand commandString = new SqlCommand("SELECT category FROM [category] ", Conn);
            SqlDataAdapter da = new SqlDataAdapter(commandString);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (CatList.Text == "")
            {
                CatList.DataTextField = ds.Tables[0].Columns["category"].ToString();
                CatList.DataValueField = ds.Tables[0].Columns["category"].ToString();
                CatList.DataSource = ds.Tables[0];
                CatList.DataBind();
                CatList.Text = "";
            }
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        string s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(s);
        con.Open();
        string sqlUserName;
        sqlUserName = "SELECT Id_category FROM [category] WHERE (category =N'" + CatList.Text + "')";
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
        string CurrentCategory = Convert.ToString(cmd.ExecuteScalar());

        string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
        SqlConnection Conn = new SqlConnection(strSQLconnection);
        SqlCommand commandString;
        if (CatList.Text.CompareTo("") == 0)
            commandString = new SqlCommand("SELECT [Book].Id_book,[Book].name,[Book].publishing,[Book].author, [Book].book_url FROM [Book], [Book_category], [category] WHERE [Book].name LIKE '%" + Name.Text + "%' AND [Book].publishing LIKE '%" + Publishing.Text + "%' AND [Book].author LIKE '%" + Author.Text + "%' AND ([Book].Id_book = [Book_category].id_book) AND ([category].Id_category = [Book_category].id_category)", Conn);
        else
            commandString = new SqlCommand("SELECT [Book].Id_book,[Book].name,[Book].publishing,[Book].author, [Book].book_url FROM [Book], [Book_category], [category] WHERE [Book].name LIKE '%" + Name.Text + "%' AND [Book].publishing LIKE '%" + Publishing.Text + "%' AND [Book].author LIKE '%" + Author.Text + "%' AND ([category].Id_category=" + CurrentCategory + ") AND ([Book].Id_book = [Book_category].id_book) AND ([category].Id_category = [Book_category].id_category)", Conn);
        SqlDataAdapter da = new SqlDataAdapter(commandString);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataSourceID = "";
        GridView1.DataBind();
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