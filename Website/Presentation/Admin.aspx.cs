using System;
using System.Collections.Generic;

namespace Website.Presentation
{
  using Model;
  using Model.Repositories;

  public partial class Admin : System.Web.UI.Page
  {
    protected override void OnInit(EventArgs e)
    {
      DataBind();
      base.OnInit(e);
    }

    protected IEnumerable<Message> DataSource
    {
      get { return MessageRepository.GetAll(); }
    }

    protected void DeleteAllMessages(object sender, EventArgs e)
    {
      MessageRepository.DeleteAll();
      Response.Redirect(".");
    }
  }
}