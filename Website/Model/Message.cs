using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Website.Model
{
  public class Message
  {
    [BsonId]
    public ObjectId Id { get; set; }
    public string GroupId { get; set; }
    public string UserImageUrl { get; set; }
    public string Author { get; set; }
    public string Text { get; set; }
    public DateTime SendTime { get; set; }
    public Double Latitude { get; set; }
    public Double Longitude { get; set; }
    public string Browser { get; set; }
    public string AuthenticationMethod { get; set; }
  }
}