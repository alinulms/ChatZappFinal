using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Script.Serialization;

namespace Website.Presentation.Controls
{
  using Model;
  using Model.Repositories;

  public partial class DiscussionControl : System.Web.UI.UserControl
  {
    public string GroupId
    {
      get
      {
        return Request.QueryString["gid"] == null
          ? string.Empty
          : Request.QueryString["gid"].ToString(CultureInfo.InvariantCulture);
      }
    }

    protected override void OnInit(EventArgs e)
    {
      PersistedUserRepository persistedUserRepository = new PersistedUserRepository(Request);
      var chatzapUser = persistedUserRepository.GetUser();
      
      if (chatzapUser!= null)
      {
        UserName.Value = chatzapUser.Name;
        UserImageUrl.Value = chatzapUser.PictureUrl;
      }
      base.OnInit(e);
      DataBind();
    }
    protected IEnumerable<Message> GetMessages()
    {
      return string.IsNullOrEmpty(GroupId) ? Enumerable.Empty<Message>() : MessageRepository.GetByGroupId(GroupId);
    }
  }
}