using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserAuthentication"] == null)
            {
                
                LoginName1.Visible = false;
                Rating.Visible = false;
                StatusLb.Visible = true;
                Login1.Visible = true;
                
            }
            else
            {
                LoginName1.Visible = true;
                Rating.Visible = true;
                StatusLb.Visible = false;
                AdminPanelButton.Visible = true;
                AdminPanelButton.Visible = true;
            }
        }


        protected void Btn_Click(object sender, EventArgs e)
        {
            
        }

    }
}