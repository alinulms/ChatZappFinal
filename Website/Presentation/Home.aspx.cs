using System;

namespace Website.Presentation
{
  using System.Configuration;
  using System.Web;
  using System.Web.Script.Serialization;
  using ASPSnippets.FaceBookAPI;
  using Model;
  using Model.Repositories;

  public partial class Home : System.Web.UI.Page
  {
    protected override void OnInit(EventArgs e)
    {
      AutoFillUserNameTextBox();
      base.OnInit(e);
      DataBind();
    }
    
    private void AutoFillUserNameTextBox()
    {
      var persistedUserRepositor = new PersistedUserRepository(Request);
      var chatzapUser = persistedUserRepositor.GetUser();

      if (chatzapUser != null && !string.IsNullOrEmpty(chatzapUser.UserName))
        TxtName.Text = chatzapUser.UserName;
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
      var faceBookUser = new JavaScriptSerializer().Deserialize<ChatzappUser>(data);
      faceBookUser.PictureUrl = string.Format("https://graph.facebook.com/{0}/picture", faceBookUser.Id);
      faceBookUser.ChattingDistance = string.IsNullOrEmpty(TxtRadiusFacebook.Text) ? 10 : int.Parse(TxtRadiusFacebook.Text);

      btnLogin.Enabled = false;
      Response.Cookies.Add(new HttpCookie(Constants.ChatzapCookie) { Value = new JavaScriptSerializer().Serialize(faceBookUser), Expires = DateTime.MinValue });
      Response.Redirect(ConfigurationManager.AppSettings["MessageBoardPage"]);
    }

    protected void SaveNameAndRadius(object sender, EventArgs e)
    {
      PersistUser(int.Parse(TxtRadius.Text));
      Response.Redirect(ConfigurationManager.AppSettings["MessageBoardPage"]);
    }

    protected void Login(object sender, EventArgs e)
    {
      PersistUser(int.Parse(TxtRadiusFacebook.Text));
      FaceBookConnect.Authorize("user_photos,email", Request.Url.AbsoluteUri.Split('?')[0]);
    }

    private void PersistUser(int chattingDistance)
    {
      Location userLocation = new Location
      {
        Latitude = Double.Parse(Latitude.Value.Replace('.', ',')),
        Longitude = Double.Parse(Longitude.Value.Replace('.', ','))
      };
      Response.Cookies.Add(new HttpCookie(Constants.LocationCookie) { Value = new JavaScriptSerializer().Serialize(userLocation), Expires = DateTime.MinValue });

      ChatzappUser currentUser =  new ChatzappUser
      {
        ChattingDistance = chattingDistance,
        Email = string.Empty,
        Id = string.Empty,
        Name = TxtName.Text,
        PictureUrl = "/Styles/Images/anonymous.jpg",
        UserName = TxtName.Text
      };
      Response.Cookies.Add(new HttpCookie(Constants.ChatzapCookie) { Value = new JavaScriptSerializer().Serialize(currentUser), Expires = DateTime.MinValue });
    }
  }
}