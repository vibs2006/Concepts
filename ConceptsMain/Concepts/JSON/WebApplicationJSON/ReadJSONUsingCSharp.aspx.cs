using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;

namespace WebApplicationJSON
{
    public class FMSDetails
    {
        public string server { get; set; }
        public string stream { get; set; }

    }

    public partial class ReadJSONUsingCSharp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/");
            StreamReader r = new StreamReader(path + @"\data.txt");

            string json = r.ReadToEnd();
            var serializer = new JavaScriptSerializer();
            FMSDetails objFMSDetails = serializer.Deserialize<FMSDetails>(json); 
            divOutput.InnerHtml = "Server IP is <b>" + objFMSDetails.server + "</b> and Stream name is <b>" + objFMSDetails.stream + "</b>";


        }
    }
}