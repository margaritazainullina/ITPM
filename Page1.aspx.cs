using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Page1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    /* protected void FileUpload1_Load(object sender, EventArgs e)
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
                
             }
             catch (Exception ex)
             {
                 Label1.Text = "ERROR: " + ex.Message.ToString();
             }
         else
         {
             Label1.Text = "Вы не выбрали файл.";
         }
     }*/

    protected void FileUploadComplete(object sender, EventArgs e)
    {
         string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
         AsyncFileUpload1.SaveAs(Server.MapPath("img/users/") + filename);
         userPhoto.ImageUrl = "img/users/" + AsyncFileUpload1.FileName;
        
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
    }
    protected void Download0_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddBook.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Login1.Visible = false;
        StatusLb.Visible = false;
        Response.Redirect("Start.aspx");
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        Response.Redirect("AdminPanel.aspx");
    }

    protected void UserPanelButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserPanel.aspx");
    }

    protected void Exit_Click(object sender, EventArgs e)
    {

        Login1.Visible = true;
        StatusLb.Visible = true;
        Registration.Visible = true;
        LoginName1.Visible = false;
        Rating.Visible = false;
        Session["UserAuthentication"] = null;
        Response.Redirect("Index.aspx");
    }

  
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

        string username = Login1.UserName;
        string pwd = Login1.Password;
        string s;
        s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(s);
        con.Open();
        string sqlUserName;
        sqlUserName = "SELECT login,password,rating  FROM [User] WHERE login ='" + username + "' AND password ='" + pwd + "'";
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
        string CurrentName;
        CurrentName = (string)cmd.ExecuteScalar();
        // пользователь есть в бд    
        if (CurrentName != null)
        {
            Session["UserAuthentication"] = username;
            Session.Timeout = 1;
            Login1.Visible = false;
            StatusLb.Visible = false;
            LoginName1.Visible = true;
            LoginName1.FormatString = "Welcome, " + Session["UserAuthentication"].ToString();
            Exit.Visible = true;
            Registration.Visible = false;
            //если зашел админ
            if (Session["UserAuthentication"].ToString().CompareTo("admin") == 0)
            {
                AdminPanelButton.Visible = true;
            }
            else
            {
                UserPanelButton.Visible = true;
            }
            //сделать отображение рейтинга
            sqlUserName = "Select rating FROM [User] WHERE login ='" + username + "'";
            cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            CurrentName = Convert.ToString(cmd.ExecuteScalar());
            if (CurrentName != null)
            {
                Rating.Text = "Ваш рейтинг=" + CurrentName;
                Rating.Visible = true;
            }
        }

        else
        {
            //Session["UserAuthentication"] = "";
            StatusLb.Text = "Вы не зарегистрированы либо не верно ввели данные!!! Повторите ввод или нажмите кнопку регистрации";
        }

    
    }
}