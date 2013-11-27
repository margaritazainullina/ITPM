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
        sqlUserName = "Select Id_category FROM [category] WHERE (category =N'" + CatList.Text + "')";
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
        string CurrentCategory = Convert.ToString(cmd.ExecuteScalar());

        string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
        SqlConnection Conn = new SqlConnection(strSQLconnection);
        SqlCommand commandString = new SqlCommand("SELECT [Book].name,[Book].publishing,[Book].author, [Book].book_url  FROM [Book] INNER JOIN ([User] INNER JOIN ([Book_user] INNER JOIN ([category] INNER JOIN [Book_category] ON [category].Id_category = [Book_category].id_category) ON [Book_user].book_idbook = [Book_category].id_book) ON [User].Id_user= [Book_user].user_iduser) ON [Book].Id_book= [Book_user].book_idbook WHERE ((Book_category.id_category=" + CurrentCategory + ") And ([Book].publishing like '%" + Publishing.Text + "%')And ([Book].author like '%" + Author.Text + "%') And ([Book].name like '%" + Name.Text + "%'));", Conn);
        SqlDataAdapter da = new SqlDataAdapter(commandString);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
}