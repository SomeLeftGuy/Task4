using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Task4_True.Pages.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Task4_True.Control
{
    public class UserControl
    {
        IGridFSBucket gridFS;   // файловое хранилище
        IMongoCollection<User> Users; // коллекция в базе данных
            
        
        public UserControl()
        {
            // строка подключения
            string connectionString = "mongodb+srv://Soso:123123123@task4.iyfiu.gcp.mongodb.net/Soso?retryWrites=true&w=majority";
            var connection = new MongoUrlBuilder(connectionString);
            // получаем клиента для взаимодействия с базой данных
            MongoClient client = new MongoClient(connectionString);
            // получаем доступ к самой базе данных
            IMongoDatabase database = client.GetDatabase(connection.DatabaseName, settings: null); 
            // получаем доступ к файловому хранилищу
            gridFS = new GridFSBucket(database);
            // обращаемся к коллекции Products
            Users = database.GetCollection<User>("Users");
        }
        public  IEnumerable<User> GetUsers()
        {
            // строитель фильтров
            var builder = new FilterDefinitionBuilder<User>();
            var filter = builder.Empty; // фильтр для выборки всех документов
            return Users.Find(filter).ToEnumerable();
        }
       

        // получаем один документ по id
        public async Task<User> GetUser(string id)
        {
            return await Users.Find(new BsonDocument("_id", new ObjectId(id))).FirstOrDefaultAsync();
        }
        // добавление документа
        public async Task<Microsoft.AspNet.Identity.IdentityResult> Create(User p)
        {
            
            return await Users.InsertOneAsync(p) ;
            
        }
        // обновление документа
        public async Task Update(User p)
        {
            await Users.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(p.Id)), p);
        }
        // удаление документа
        public async Task Remove(string id)
        {
            await Users.DeleteOneAsync(new BsonDocument("_id", new ObjectId(id)));
        }
      
       
    }
}