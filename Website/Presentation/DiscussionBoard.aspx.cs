using System;

namespace Website.Presentation
{
  public partial class DiscussionBoard : System.Web.UI.Page
  {
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      DataBind();
    }
  }
}