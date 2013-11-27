using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddBook : System.Web.UI.Page
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

            if (ListCategory.Text == "")
            {
                ListCategory.DataTextField = ds.Tables[0].Columns["category"].ToString();
                ListCategory.DataValueField = ds.Tables[0].Columns["category"].ToString();
                ListCategory.DataSource = ds.Tables[0];
                ListCategory.DataBind();
                ListCategory.Text = "";
            }
        }
        else
        {
            Response.Redirect("Index.aspx");
        }
    }
    protected void FileUpload1_Load(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
            try
            {

                String curPath1 = Server.MapPath("books");
                String curPath = curPath1 + "\\" + FileUpload1.FileName;
                FileUpload1.SaveAs(curPath);

                File.Text = FileUpload1.PostedFile.FileName;
                FileUpload1.SaveAs(curPath);
             
            }
            catch (Exception ex)
            {
                File.Text = "ERROR: " + ex.Message.ToString();
            }
        else
        {
            File.Text = "Вы не выбрали файл.";
        }
    }
    protected void ButtAdd_Click(object sender, EventArgs e)
    {
        if (File.Text != "")
        {
            string s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(s);
            con.Open();
            string sqlUserName;
            sqlUserName = "Select Id_category FROM [category] WHERE (category =N'" + ListCategory.Text + "')";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentCategory = Convert.ToString(cmd.ExecuteScalar());
            
            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);
            Conn.Open();

            sqlUserName = "INSERT INTO [Book] (name,author,publishing, info,book_url) VALUES (N'" + TxtName.Text + "',N'" + TxtAuthor.Text + "',N'" + TxtPublishing.Text + "',N'" + TxtInfo.Text + "',N'" + "books\\" + File.Text + "')";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, Conn);
            cmd.ExecuteScalar();

            sqlUserName = "Select Id_book FROM [Book] WHERE (name =N'" + TxtName.Text + "')";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentIDBook =Convert.ToString( cmd.ExecuteScalar());

            sqlUserName = "INSERT INTO [Book_category] (id_book,id_category) VALUES (" + CurrentIDBook+ "," + CurrentCategory+ ")";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, Conn);
            cmd.ExecuteScalar();

            sqlUserName = "Select Id_user FROM [User] WHERE name =N'" + Session["UserAuthentication"].ToString() + "'";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentIDUser = Convert.ToString(cmd.ExecuteScalar());

            sqlUserName = "INSERT INTO [Book_user] (book_idbook,user_iduser) VALUES (" + CurrentIDBook + "," + CurrentIDUser + ")";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, Conn);
            cmd.ExecuteScalar();
            State.Visible = true;
            State.Text = "Книга успешно добавлена";
            TxtName.Text = "";
            TxtPublishing.Text = "";
            TxtAuthor.Text = "";
            TxtInfo.Text = "";
            File.Text = "";
            //FileUpload1.FileName. = "";
        }
        else
        {
            State.Visible = true;
            State.Text = "Невозможно добавить!!!!";
        }
    }
    protected void ButtDownload_Click(object sender, EventArgs e)
    {

    }
}