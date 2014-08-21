using System;

namespace Website.Model.Factories
{
  using MongoDB.Bson;

  public class MessageFactory
  {
    public static Message Create(string author, string userImageUrl, string groupId, string text, DateTime sendTime, Double latitude, Double longitude, string browser)
    {
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
        Browser = browser
      };
    }
  }
}