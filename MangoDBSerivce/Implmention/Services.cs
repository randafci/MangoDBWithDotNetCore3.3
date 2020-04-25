using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase.Models;
using MangoDBSerivce.Contract;
using Data.Repository;

namespace MangoDBSerivce.Services
{
    public class BookService: IBookService
    {

        private readonly IRepository<Book,int> _books;
        public BookService(IRepository<Book,int> books)
        {

            _books = books;
        }

        public List<Book> GetAll()
        {
            return _books.GetAll();
        }



        public Book Get(int  id)
        {
            return _books.GetById(id);
        }

        public Book Create(Book book)
        {
            _books.Add(book);
            return book;
        }

        public void Update(int  id, Book bookIn)
        {
            _books.Update(id, bookIn);
        }

       
           

   
    }

}
