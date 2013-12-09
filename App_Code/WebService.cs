using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [System.Web.Services.WebMethod()]
    public double Plus(double a, double b)
    {
        return a + b;
    }

    [System.Web.Services.WebMethod()]
    public double Minus(double a, double b)
    {
        return a - b;
    }

    [System.Web.Services.WebMethod()]
    public double Multiply(double a, double b)
    {
        return a * b;
    }

    [System.Web.Services.WebMethod()]
    public double Divide(double a, double b)
    {
        return a / b;
    }

    [System.Web.Services.WebMethod()]
    public double Sinus(double x)
    {
       
            if (x < 0 || x > 360) throw new ArgumentException("Argument should be less them 360 degrees and bigger than 0");
            return Math.Sin(x);

    }
}
