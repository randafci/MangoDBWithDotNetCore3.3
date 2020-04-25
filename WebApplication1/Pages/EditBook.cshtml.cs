using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data;
using DataBase.Models;
using MangoDBSerivce.Contract;

namespace BooksApi
{
    public class EditBookModel : PageModel
    {
        private readonly IBookService _service;

        public EditBookModel(IBookService service)
        {
            _service = service;
        }

        [BindProperty]
        public Book Book { get; set; }

        public int ID { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = _service.GetAll().Find(x => x.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            ID = id;
            return Page();
        }

        public IActionResult OnPost()
        {
            _service.Update(Book.Id, Book);            

            return RedirectToPage("./ListBooks");
        }

    }
}
