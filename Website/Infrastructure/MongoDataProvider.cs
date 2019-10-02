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
      const string connectionString = "mongodb://chatzapp:chatzappuser1@ds229258.mlab.com:29258/chatzapp";
      MongoClient client = new MongoClient(connectionString);
      return client.GetDatabase("chatzapp");
      //var server = client.Cluster.SelectServer(new RandomServerSelector(), CancellationToken.None);
      //if (server == null)
      //{
      //  throw new NullReferenceException("Mongo server could not be found");
      //}
      //return client.GetDatabase("Solr");
    }
  }
}