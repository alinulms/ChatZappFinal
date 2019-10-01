using System;
using System.Threading;
using MongoDB.Driver.Core.Clusters.ServerSelectors;

namespace Website.Infrastructure
{
  using MongoDB.Driver;

  public class MongoDataProvider
  {
    public static IMongoDatabase Get()
    {
      const string connectionString = "mongodb://alin:alin@paulo.mongohq.com:10041/Solr";
      MongoClient client = new MongoClient(connectionString);
      return client.GetDatabase("Solr");
      //var server = client.Cluster.SelectServer(new RandomServerSelector(), CancellationToken.None);
      //if (server == null)
      //{
      //  throw new NullReferenceException("Mongo server could not be found");
      //}
      //return client.GetDatabase("Solr");
    }
  }
}