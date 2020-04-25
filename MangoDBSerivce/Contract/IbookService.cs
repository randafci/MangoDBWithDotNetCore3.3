using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;
using Data.Repository.EntityFramework;

namespace MangoDBSerivce.Contract
{
   public interface IBookService
    {
         List<Book> GetAll();
        Book Get(int id);
        Book Create(Book book);

        void Update(int id, Book bookIn);
    }
}
