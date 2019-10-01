using System;
using Owin;

namespace Website
{
  public class Global : System.Web.HttpApplication
    {
      protected void Application_Start(object sender, EventArgs e)
      {
      }
    
      public void Configuration(IAppBuilder app)
      {
        app.MapSignalR();
      }
    }
}