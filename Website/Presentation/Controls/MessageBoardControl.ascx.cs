using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Website.Presentation.Controls
{
  using System.Configuration;
  using Model;
  using Model.Repositories;

  public partial class MessageBoardControl : System.Web.UI.UserControl
  {
    private ChatzappUser _chatzappUser;
    private Location _location;

    protected override void OnInit(EventArgs e)
    {
      ValidateUser();
      ValidateLocation();

      base.OnInit(e);
      DataBind();
    }

    private void ValidateLocation()
    {
      var locationRepository = new LocationRepository(Request);
      _location = locationRepository.Get();

      if(_location == null)
        Response.Redirect(ConfigurationManager.AppSettings["StartingPage"]);
    }

    private void ValidateUser()
    {
      var persistedUserRepository = new PersistedUserRepository(Request);
      _chatzappUser = persistedUserRepository.GetUser();

      if (_chatzappUser == null)
        Response.Redirect(ConfigurationManager.AppSettings["StartingPage"]);
    }

    protected IEnumerable<Message> GetMessageBoardDiscussions()
    {
      var allMsg = MessageRepository.GetAllInRadius(_location.Latitude, _location.Longitude, _chatzappUser.ChattingDistance);
      return allMsg;
    }

    protected void ShowDiscussion(object sender, EventArgs e)
    {
      Response.Redirect(string.Concat(ConfigurationManager.AppSettings["DiscussionBoardPage"], "?gid=", ((LinkButton)sender).CommandArgument));
    }

    protected string GetMessagesInDiscussion(string groupId)
    {
      return MessageRepository.GetNumberOfMessageInDiscussion(groupId);
    }
  }
}