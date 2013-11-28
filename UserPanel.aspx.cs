using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserPanel : System.Web.UI.Page
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
            sqlUserName = "Select photo FROM [User] WHERE login ='" + Session["UserAuthentication"].ToString() + "'";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentPhoto = Convert.ToString(cmd.ExecuteScalar());
            if ((CurrentPhoto != null) && (userPhoto.ImageUrl.ToString().CompareTo("")==0))
                userPhoto.ImageUrl = CurrentPhoto;
            NameText.Text = Session["UserAuthentication"].ToString();
            sqlUserName = "Select email FROM [User] WHERE login ='" + Session["UserAuthentication"].ToString() + "'";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentEmail = Convert.ToString(cmd.ExecuteScalar());
            if ((CurrentEmail != null)&&(EmailText.Text.CompareTo("")==0))
                EmailText.Text = CurrentEmail;
            sqlUserName = "Select password FROM [User] WHERE login ='" + Session["UserAuthentication"].ToString() + "'";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string CurrentPassword = Convert.ToString(cmd.ExecuteScalar());
            if ((CurrentPassword != null) && (Password1.Text.CompareTo("")==0))
                Password1.Text = CurrentPassword;
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
           // Status.Text = "Мой профиль";
            sqlUserName = "Select Id_user FROM [User] WHERE login ='" + Session["UserAuthentication"].ToString() + "'";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            string userID = Convert.ToString(cmd.ExecuteScalar());
            // просмотр книг текущего пользователя
            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);
            SqlCommand commandString = new SqlCommand("SELECT [Book].name FROM [Book] INNER JOIN ([User] INNER JOIN [Book_User] ON [User].Id_user = [Book_User].user_iduser) ON [Book].Id_book = [Book_User].book_idbook WHERE ((([User].Id_user)="+userID+")); ", Conn);
            SqlDataAdapter da = new SqlDataAdapter(commandString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ListBooks.DataTextField = ds.Tables[0].Columns["name"].ToString();
            ListBooks.DataValueField = ds.Tables[0].Columns["name"].ToString();
            ListBooks.DataSource = ds.Tables[0];
            ListBooks.DataBind();
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
                String curPath1 = Server.MapPath("img");
                String curPath = curPath1 + "\\users\\" + FileUpload1.FileName;
                FileUpload1.SaveAs(curPath);

                Label1.Text = "Имя: " +
                     FileUpload1.PostedFile.FileName + "<br>" +
                     FileUpload1.PostedFile.ContentLength + " kb<br>" +
                     "Тип: " +
                     FileUpload1.PostedFile.ContentType;
                FileUpload1.SaveAs(curPath);
                userPhoto.ImageUrl = "img\\users\\" + FileUpload1.FileName;
            }
            catch (Exception ex)
            {
                Label1.Text = "ERROR: " + ex.Message.ToString();
            }
        else
        {
            Label1.Text = "Вы не выбрали файл.";
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);
            Conn.Open();
            String strsession1 = "update [user] SET name=N'" + NameText.Text + "',email=N'" + EmailText.Text + "',password=N'" + Password1.Text + "',photo=N'" + userPhoto.ImageUrl + "' WHERE name=N'" + Session["UserAuthentication"].ToString() + "'";
            SqlCommand cmd = new SqlCommand(strsession1, Conn);
            cmd.ExecuteNonQuery();
            Conn.Close();
            Response.Redirect("UserPanel.aspx");
        }
        catch (Exception ex)
        {
            Response.Redirect("UserPanel.aspx");
        }
        //Response.Redirect("UserPanel.aspx");
    }
    protected void Download0_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBook.aspx");
    }
}