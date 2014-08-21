using System;

namespace Website.Infrastructure
{
  using MongoDB.Driver;

  public class MongoDataProvider
  {
    public static MongoDatabase Get()
    {
      const string connectionString = "mongodb://alin:alin@paulo.mongohq.com:10041/Solr";
      MongoClient client = new MongoClient(connectionString);
      var server = client.GetServer();
      if (server == null)
      {
        throw new NullReferenceException("Mongo server could not be found");
      }
      return server.GetDatabase("Solr");
    }
  }
}