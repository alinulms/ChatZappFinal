namespace Website.Model.Repositories
{
  using System.Web;
  using System.Web.Script.Serialization;

  public class PersistedUserRepository
  {
    private readonly HttpRequest _request;
    public PersistedUserRepository(HttpRequest request)
    {
      _request = request;
    }

    public ChatzappUser GetUser()
    {
      var cookieCollection = _request.Cookies;
      var chatzapCookie = cookieCollection.Get(Constants.ChatzapCookie);

      if (chatzapCookie == null)
        return null;

      var userCookie = chatzapCookie.Value;
      return new JavaScriptSerializer().Deserialize<ChatzappUser>(userCookie);
    }
  }
}