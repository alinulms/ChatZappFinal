namespace Website.Infrastructure
{
  using System;
  using System.Globalization;
  using System.Linq;
  using System.Net;
  using System.Runtime.Serialization.Json;
  using System.Text;

  public class GooglePlacesService
  {
    private string _latitude;
    private string _longitude;
    private const string GooglePlacesServiceUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?";

    public GooglePlacesService(string latitude, string longitude)
    {
      _latitude = latitude;
      _longitude = longitude;
    }

    public string GetNearbyPlace()
    {
      string urlRequest = BuildGooglePlacesUrl();
      GoogleLocationApiResponse response = MakeRequest(urlRequest);
      if (response.status.ToLower().Equals("invalid_request"))
        return string.Empty;
      return response.results.FirstOrDefault().name;
    }

    private string BuildGooglePlacesUrl()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append(GooglePlacesServiceUrl);
      sb.Append("location=");
      sb.Append(_latitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));
      sb.Append(",");
      sb.Append(_longitude.ToString(CultureInfo.InvariantCulture).Replace(',', '.'));
      sb.Append("&radius=1");
      sb.Append("&key=");
      sb.Append(Constants.GoogleApiKey);
      return sb.ToString();
    }

    public static GoogleLocationApiResponse MakeRequest(string requestUrl)
    {
      try
      {
        HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
        using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
        {
          if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception(String.Format(
            "Server error (HTTP {0}: {1}).",
            response.StatusCode,
            response.StatusDescription));
          DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(GoogleLocationApiResponse));
          object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
          GoogleLocationApiResponse jsonGoogleLocationApiResponse
          = objResponse as GoogleLocationApiResponse;
          return jsonGoogleLocationApiResponse;
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return null;
      }
    }
  }
}