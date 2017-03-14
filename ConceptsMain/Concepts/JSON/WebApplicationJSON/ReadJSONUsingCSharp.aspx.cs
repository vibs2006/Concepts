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

    public class HourlyGraph
    {
        public int Hour { get; set; }
        public int Sales { get; set; }
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


            //var lst = new List<FMSDetails>();
            //lst.Add(new FMSDetails() { stream = "ServerName1", server = "serverName1" });
            //lst.Add(new FMSDetails() { stream = "ServerName2", server = "serverName2" });

            //var serialzer = new JavaScriptSerializer();

            //string s = serialzer.Serialize(lst.Select(x => new { device = x.stream, geekbench = x.stream }));
            //Response.Write(s);


        }
    }

}