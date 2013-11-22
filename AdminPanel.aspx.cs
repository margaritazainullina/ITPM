using System;
using System.Collections.Generic;
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
            string strSQLconnection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Book_Share.mdf;Integrated Security=True";
            SqlConnection Conn = new SqlConnection(strSQLconnection);

            SqlDataReader rdr = null;
            string commandString = "SELECT login,email,confirm FROM [User] where (confirm=0)";

            try
            {
                Conn.Open();
                SqlCommand Cmd = new SqlCommand(commandString, Conn);
                rdr = Cmd.ExecuteReader();

                GridView1.DataSource = rdr;
                GridView1.DataBind();
                if (GridView1.Rows.Count == 0)
                    Label1.Text = "Нет незарегистрированных пользователей";
                rdr = null;
                commandString = "SELECT category FROM [category] ";
                Cmd = new SqlCommand(commandString, Conn);
                rdr = Cmd.ExecuteReader();
                ParentCatList.DataSource = rdr;
                ParentCatList.DataBind();
                rdr = null;
                commandString = "SELECT category,parent_cat FROM [category] ";
                Cmd = new SqlCommand(commandString, Conn);
                rdr = Cmd.ExecuteReader();
                Categories.DataSource = rdr;
                Categories.DataBind();
                Response.Redirect("AdminPanel.aspx");
            }
            catch (Exception ex)
            {
                // Log error
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (Conn != null)
                {
                    Conn.Close();
                }
            }
        }
    }
        catch
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