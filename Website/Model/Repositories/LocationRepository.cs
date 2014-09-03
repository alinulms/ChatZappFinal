using System.Web;

namespace Website.Model.Repositories
{
  using System.Web.Script.Serialization;

  public class LocationRepository
  {
    private readonly HttpRequest _request;

    public LocationRepository(HttpRequest request)
    {
      _request = request;
    }

    public Location Get()
    {
      var cookieCollection = _request.Cookies;
      var locationCookie  = cookieCollection.Get(Constants.LocationCookie);

      return locationCookie == null 
        ? null 
        : new JavaScriptSerializer().Deserialize<Location>(locationCookie.Value);
    }
  }
}