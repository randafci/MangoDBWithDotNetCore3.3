using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksApi.Data;
using DataBase.Models;
using MangoDBSerivce.Contract;

namespace BooksApi
{
    public class DetailBookModel : PageModel
    {
        private readonly IBookService _service;

        public DetailBookModel(IBookService service)
        {
            _service = service;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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
            return Page();
        }
    }
}
