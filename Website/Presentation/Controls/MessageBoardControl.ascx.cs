using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace Website.Presentation.Controls
{
  using System.Web.Script.Serialization;
  using Model;

  public partial class MessageBoardControl : System.Web.UI.UserControl
  {
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      DataBind();
    }

    protected IEnumerable<Message> GetMessageBoardDiscussions()
    {
      var allMsg = Model.Repositories.MessageRepository.GetAllInRadius(Latitude, Longitude, Radius);
      return allMsg;
    }

    public double Longitude
    {
      get
      {
        if (Session["Longitude"] != null && Session["Longitude"].ToString() != string.Empty)
          return Double.Parse(Session["Longitude"].ToString().Replace('.', ','));
        Response.Redirect("/");
        return double.NaN;
      }
    }
    public double Latitude
    {
      get
      {
        if (Session["Latitude"] != null && !string.IsNullOrEmpty(Session["Latitude"].ToString()))
          return Double.Parse(Session["Latitude"].ToString().Replace('.', ','));
        Response.Redirect("/");
        return double.NaN;
      }
    }

    public int Radius
    {
      get
      {
        if (Session["Radius"] != null && !string.IsNullOrEmpty(Session["Radius"].ToString()))
          return Int32.Parse(Session["Radius"].ToString().Replace('.', ','));

        HttpCookie httpCookie = Request.Cookies[Constants.CookieName];
        if (httpCookie != null)
        {
          var userCookie = httpCookie.Value;
          FacebookUser fbUser = new JavaScriptSerializer().Deserialize<FacebookUser>(userCookie);
          return fbUser.ChattingDistance;
        }
        Response.Redirect("/");
        return -1;
      }
    }

    public string UserName
    {
      get
      {
        HttpCookie httpCookie = Request.Cookies[Constants.CookieName];
        if (httpCookie != null)
        {
          var userCookie = httpCookie.Value;
          FacebookUser fbUser = new JavaScriptSerializer().Deserialize<FacebookUser>(userCookie);
          return fbUser.UserName;
        }
        Response.Redirect("/");
        return string.Empty;
      }
    }

    protected void ShowDiscussion(object sender, EventArgs e)
    {
      Response.Redirect(string.Concat("/DiscussionBoard.aspx?gid=", ((LinkButton)sender).CommandArgument));
    }

    protected string GetMessagesInDiscussion(string groupId)
    {
      return Model.Repositories.MessageRepository.GetNumberOfMessageInDiscussion(groupId);
    }
  }
}