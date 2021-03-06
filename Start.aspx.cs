﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Start : System.Web.UI.Page
{
    bool err = false;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        
       
    }
    protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
    {
        try
            {
            
            string s;
            s = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(s);
            con.Open();
            
             if ((IsValidEmail(CreateUserWizard1.Email) ))
            {string sqlUserName;
            sqlUserName = "INSERT INTO [User] (name, login, password, email, rating, confirm,photo) VALUES ('" + CreateUserWizard1.UserName + "','" + CreateUserWizard1.UserName + "','" + CreateUserWizard1.Password + "','" + CreateUserWizard1.Email + "',10,0,'" + userPhoto.ImageUrl + "')";
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, con);
            cmd.ExecuteScalar();
                CreateUserWizard1.Visible = false;
                Status.Visible = true;
                userPhoto.Visible = false;
                Button1.Visible = false;
                FileUpload1.Visible = false;
                Label1.Visible = false;
                Status.Text = "Спасибо за регистрацию! Ждите подтверждения администратора";
            }
            else throw new Exception();
        }
        catch 
        {
            Status.Visible = true;
            Status.Text = "Не удалось авторизироваться!!!";
        }
    }
    protected void CreateUserWizard1_CreateUserError(object sender, CreateUserErrorEventArgs e)
    {
        
    }
    bool IsValidEmail(string strIn)
    {

        // Return true if strIn is in valid e-mail format.

        return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

    }
    bool IsValidPassword(string strIn)
    {

        // Return true if strIn is in valid e-mail format.

        return Regex.IsMatch(strIn, @"^(?:.{7,})(?=(.*\d){1,})(?=(.*\W){1,})$");

    }

    protected void FileUpload1_Load1(object sender, EventArgs e)
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
}