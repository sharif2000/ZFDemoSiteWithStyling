using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZFDemoSite
{
    public partial class GenerateChallenge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ClearContent();
            byte[] challenge = new byte[8];
            new Random().NextBytes(challenge);
            Session["Challenge"] = challenge;
            Response.Write(Convert.ToBase64String(challenge));
            Response.End();
        }
    }
}
