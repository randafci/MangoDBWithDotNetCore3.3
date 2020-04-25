using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Repository;
using DataBase.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using BooksApi.Models;
namespace Data.Repository.EntityFramework
{
  public  class Repository<T, K> : IRepository<T, K> where T : class
    {
      
     
        private readonly IMongoCollection<T> _entitySet;


        public Repository(IBookstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _entitySet = database.GetCollection<T>(typeof(T).Name);

        }



        public T Add(T item)
        {
            _entitySet.InsertOne(item);
            return item;
        }

        public void Update(K id, T item)
        {
            var filter = Builders<T>.Filter.Eq("ID", id);
            _entitySet.ReplaceOne(filter, item);
        }
          


        public T GetById(K id)
        {
            var filter = Builders<T>.Filter.Eq("ID", id);
            var result =  _entitySet.Find(filter).FirstOrDefault();
         
     
            return result;
        }
      
        public List<T> GetAll()
        {
            return _entitySet.Find(new BsonDocument()).ToList();
            

        }

    }

}