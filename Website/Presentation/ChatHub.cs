using System;
using Microsoft.AspNet.SignalR;

namespace Website.Presentation
{
  using Model.Factories;
  using Model.Repositories;

  public class ChatHub : Hub
  {
    public void Send(string name, string userImageUrl, string message, string discussionId, string latitude, string longitude, string browser)
    {
      var newLat = latitude.Replace('.', ',');
      var newLong = longitude.Replace('.', ',');
      if (string.IsNullOrEmpty(discussionId))
      {
        var newGroupId = Guid.NewGuid().ToString().Replace("-", "");
        try
        {
          MessageRepository.Insert(MessageFactory.Create(name, userImageUrl, newGroupId, message, DateTime.Now, Double.Parse(newLat), Double.Parse(newLong), browser));
        }
        catch (Exception)
        {
          throw new Exception(string.Concat(name, " ", message, " ", discussionId, " ", latitude, " ", longitude, " ", browser));
        }
      }
      else
      {
        MessageRepository.Insert(MessageFactory.Create(name, userImageUrl, discussionId, message, DateTime.Now, Convert.ToDouble(latitude), Convert.ToDouble(longitude), browser));
      }
      Clients.All.broadcastMessage(name, userImageUrl, message, discussionId);
    }
  }
}