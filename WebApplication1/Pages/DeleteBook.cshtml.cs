using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data;
using DataBase.Models;
using MangoDBSerivce.Services;

namespace BooksApi
{
    public class DeleteBookModel : PageModel
    {
        private readonly BookService _service;

        public DeleteBookModel(BookService service)
        {
            _service = service;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = _service.GetAll().Find(x=> x.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = _service.GetAll().Find(x => x.Id == id);
            
            //if (Book != null)
            //{
            //    _service.Remove(Book);
            //}

            return RedirectToPage("./ListBooks");
        }
    }
}
