using System;

namespace Website.Model.Factories
{
  using System.Globalization;
  using Infrastructure;
  using MongoDB.Bson;

  public class MessageFactory
  {
    public static Message Create(string author, string userImageUrl, string groupId, string text, DateTime sendTime, Double latitude, Double longitude, string browser)
    {
      string nearbyPlace = new GooglePlacesService(latitude.ToString(CultureInfo.InvariantCulture), longitude.ToString(CultureInfo.InvariantCulture)).GetNearbyPlace();
      return new Message
      {
        Id = ObjectId.GenerateNewId(),
        UserImageUrl = userImageUrl,
        GroupId = groupId,
        Author = author,
        SendTime = sendTime,
        Text = text,
        Longitude = longitude,
        Latitude = latitude,
        Browser = browser,
        AuthenticationMethod = string.Empty,
        NearbyPlace = nearbyPlace,
        PostTime = DateTime.Now.ToString("HH:mm:ss")
      };
    }
  }
}