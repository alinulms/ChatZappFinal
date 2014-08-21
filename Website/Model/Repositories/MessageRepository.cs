using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Model.Repositories
{
  using System.Globalization;
  using Infrastructure;
  using MongoDB.Driver;
  using MongoDB.Driver.Builders;

  public class MessageRepository
  {
    private const string CollectionName = "Messages";

    private static MongoDatabase DataProvider { get { return MongoDataProvider.Get(); } }
    private static MongoCollection Collection { get { return DataProvider.GetCollection(CollectionName); } }

    public static IEnumerable<Message> GetAll()
    {
      if (Collection == null)
        throw new NullReferenceException("Collection could not be found: " + CollectionName);
      return Collection.FindAllAs<Message>();
    }

    public static IEnumerable<Message> GetAllInRadius(double latitude, double longitude, int radius)
    {
      if (Collection == null)
        throw new NullReferenceException("Collection could not be found: " + CollectionName);
      var messages = Collection.FindAllAs<Message>();
      var filteredMessags = MessageFilter.GetFilteredMessages(messages, latitude, longitude, radius);
      var firstMessages = filteredMessags.OrderBy(msg => msg.SendTime).GroupBy(item => item.GroupId).Select(grp => grp.First());
      DateTime now = DateTime.Now;

      var lastTwentyFourHoursMessages = firstMessages.Where(msg => msg.SendTime > now.AddHours(-24) && msg.SendTime <= now);
      return lastTwentyFourHoursMessages;
    }

    public static IEnumerable<Message> GetByGroupId(string groupId)
    {
      if (Collection == null)
        throw new NullReferenceException("Collection could not be found: " + CollectionName);
      var query = Query<Message>.EQ(e => e.GroupId, groupId);
      var messages = Collection.FindAs<Message>(query);
      return messages;
    }

    public static void Insert(Message message)
    {
      Collection.Insert(message);
    }

    public static string GetNumberOfMessageInDiscussion(string groupId)
    {
      if (Collection == null)
        throw new NullReferenceException("Collection could not be found: " + CollectionName);
      var messagesInGroup = GetByGroupId(groupId).ToList();
      return messagesInGroup.Count().ToString(CultureInfo.InvariantCulture);
    }

    public static void DeleteAll()
    {
      if (Collection == null)
        throw new NullReferenceException("Collection could not be found: " + CollectionName);
      Collection.RemoveAll();
    }
  }
}