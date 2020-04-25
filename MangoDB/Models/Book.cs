using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DataBase.Models
{
    public class Book
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("bookName")]
        public string BookName { get; set; }

        [BsonElement("price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }
    }
}
