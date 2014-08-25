using System;
using System.Linq;

namespace Website.Presentation.Controls
{
  using System.Configuration;

  public partial class BottomNavigationControl : System.Web.UI.UserControl
  {
    protected void NewDiscussion(object sender, EventArgs e)
    {
      Response.Redirect(ConfigurationManager.AppSettings["DiscussionBoardPage"]);
    }

    protected void ShowAllDiscussion(object sender, EventArgs e)
    {
      Response.Redirect(ConfigurationManager.AppSettings["MessageBoardPage"]);
    }

    protected void ChangeRadius(object sender, EventArgs e)
    {
      Response.Redirect(ConfigurationManager.AppSettings["StartingPage"]);
    }

    public string IsNewDiscussionPage
    {
      get { return GetPageName().ToLower().Equals("discussionboard.aspx") ? "active" : string.Empty; }
    }

    public string IsMessageBoardPage
    {
      get { return GetPageName().ToLower().Equals("messageboard.aspx") ? "active" : string.Empty; }
    }

    private string GetPageName()
    {
      return Request.Url.ToString().Split('/').Last();
    }
  }
}