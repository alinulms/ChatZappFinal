using System;

namespace Website.Presentation
{
  using System.Configuration;
  using System.Web;
  using System.Web.Script.Serialization;
  using ASPSnippets.FaceBookAPI;
  using Model;

  public partial class Home : System.Web.UI.Page
  {
    protected override void OnInit(EventArgs e)
    {
      if (Session["UserName"] != null && !string.IsNullOrEmpty(Session["UserName"].ToString()))
        TxtName.Text = Session["UserName"].ToString();
      base.OnInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      FaceBookConnect.API_Key = ConfigurationManager.AppSettings["FacebookAppId"];
      FaceBookConnect.API_Secret = ConfigurationManager.AppSettings["FacebookAppSecret"];
      if (IsPostBack) 
        return;
      
      if (Request.QueryString["error"] == "access_denied")
      {
        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('User has denied access.')", true);
        return;
      }

      string code = Request.QueryString["code"];
      if (string.IsNullOrEmpty(code)) 
        return;

      string data = FaceBookConnect.Fetch(code, "me");
      var faceBookUser = new JavaScriptSerializer().Deserialize<FacebookUser>(data);
      faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
      faceBookUser.ChattingDistance = string.IsNullOrEmpty(TxtRadiusFacebook.Text) ? 10 : int.Parse(TxtRadiusFacebook.Text);

      btnLogin.Enabled = false;
      Response.Cookies.Add(new HttpCookie(Constants.CookieName) { Value = new JavaScriptSerializer().Serialize(faceBookUser), Expires = DateTime.MinValue });
      Response.Redirect(ConfigurationManager.AppSettings["StartingPage"]);
    }

    protected void SaveNameAndRadius(object sender, EventArgs e)
    {
      FacebookUser fbUser = new FacebookUser
      {
        ChattingDistance = int.Parse(TxtRadius.Text),
        Email = string.Empty,
        Id = string.Empty,
        Name = TxtName.Text,
        PictureUrl = "/Styles/Images/anonymous.jpg",
        UserName = TxtName.Text
      };
      
      //Session["UserName"] = TxtName.Text;
      //Session["Radius"] = TxtRadius.Text;
      Session["Latitude"] = Latitude.Value;
      Session["Longitude"] = Longitude.Value;

      Response.Cookies.Add(new HttpCookie(Constants.CookieName) { Value = new JavaScriptSerializer().Serialize(fbUser), Expires = DateTime.MinValue });
      Response.Redirect(ConfigurationManager.AppSettings["MessageBoardPage"]);
    }

    protected void Login(object sender, EventArgs e)
    {
      FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
    }
  }
}