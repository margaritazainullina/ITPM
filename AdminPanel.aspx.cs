using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {try{
        if (Session["UserAuthentication"].ToString().CompareTo("admin") == 0)
        {
            LoginName LoginName1 = Master.FindControl("LoginName1") as LoginName;
            LoginName1.Visible = true;
            LoginName1.FormatString = "Welcome, " + Session["UserAuthentication"].ToString();
            Label Rating = Master.FindControl("Rating") as Label;
            Rating.Visible = true;
            Rating.Text = "Ваш рейтинг=" + 1000;
            Button Exit = Master.FindControl("Exit") as Button;
            Exit.Visible = true;
            Label StatusLb = Master.FindControl("StatusLb") as Label;
            StatusLb.Visible = false;
            Button AdminPanelButton = Master.FindControl("AdminPanelButton") as Button;
            AdminPanelButton.Visible = true;
            Login Login1 = Master.FindControl("Login1") as Login;
            Login1.Visible = false;
            Button Registration = Master.FindControl("Registration") as Button;
            Registration.Visible = false;

            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);
            SqlCommand commandString = new SqlCommand("SELECT login, email, confirm FROM [User] where confirm=0",Conn);
            SqlDataAdapter da = new SqlDataAdapter(commandString);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind(); 
         
            
            //    commandString = "SELECT category FROM [category] ";
            //    Cmd = new SqlCommand(commandString, Conn);
            //    rdr = Cmd.ExecuteReader();
            //    ParentCatList.DataSource = rdr;
            //    ParentCatList.DataBind();
            //    rdr.Close();
            //    rdr = null;
            //    commandString = "SELECT category, parent_cat FROM [category] ";
            //    Cmd = new SqlCommand(commandString, Conn);
            //    rdr = Cmd.ExecuteReader();
            //    Categories.DataSource = rdr;
            //    Categories.DataBind();
            //    rdr.Close();
            //    //Response.Redirect("AdminPanel.aspx");
            
            
            
        }
        else throw new Exception();
    }
    catch (Exception ex)
        {
            Response.Redirect("Index.aspx");
        }
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
        SqlConnection Conn = new SqlConnection(strSQLconnection);
        Conn.Open();

        TableCell lid = GridView1.Rows[e.NewEditIndex].Cells[1];
        String strsession1 = "update [user] SET confirm=1 WHERE name='" + lid.Text + "'";
        SqlCommand cmd = new SqlCommand(strsession1, Conn);
        cmd.ExecuteNonQuery();
        Conn.Close();
        Response.Redirect("AdminPanel.aspx");
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
        SqlConnection Conn = new SqlConnection(strSQLconnection);
        Conn.Open();
       
        TableCell lid = GridView1.Rows[e.RowIndex].Cells[1];
       String strsession1 = "delete from [user] where name='"+lid.Text+"'";
        SqlCommand cmd = new SqlCommand(strsession1, Conn);
        cmd.ExecuteNonQuery();
        Conn.Close();
        Response.Redirect("AdminPanel.aspx");
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.DataBind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.DataBind();
    }
    protected void AddCateg_Click(object sender, EventArgs e)
    {
        string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
        SqlConnection Conn = new SqlConnection(strSQLconnection);
        Conn.Open();
        SqlDataReader rdr = null;
        string sqlUserName;
        sqlUserName = "INSERT INTO [category] (category, parent_cat) VALUES ('" + CatName.Text + "','" + ParentCatList.Text + "')";
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sqlUserName, Conn);
        cmd.ExecuteScalar();
        Response.Redirect("AdminPanel.aspx");
    }
}