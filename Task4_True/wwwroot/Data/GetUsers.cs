using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.Remoting.Messaging;

namespace Task4_True.wwwroot.Data
{
    public class GetUsers
    {
        public IEnumerable<Json> GetUser()
        {
            var client = new MongoClient("mongodb://Soso:123123123@task4-shard-00-00.iyfiu.gcp.mongodb.net:27017,task4-shard-00-01.iyfiu.gcp.mongodb.net:27017,task4-shard-00-02.iyfiu.gcp.mongodb.net:27017/Soso?ssl=true&replicaSet=atlas-upe107-shard-0&authSource=admin&retryWrites=true&w=majority");
            var database = client.GetDatabase("Soso");
            var collection = database.GetCollection < BsonDocument("Users");
        }
    } 
}
