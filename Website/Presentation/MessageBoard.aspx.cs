namespace Website.Presentation
{
  public partial class MessageBoard : System.Web.UI.Page
  {
    protected override void OnInit(System.EventArgs e)
    {
      base.OnInit(e);
      DataBind();
    }
  }
}