using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksApi.Data;
using DataBase.Models;
using MangoDBSerivce.Contract;

namespace BooksApi
{
    public class CreateBookModel : PageModel
    {
        private readonly IBookService _service;

        public CreateBookModel(IBookService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            _service.Create(Book);        

            return RedirectToPage("./ListBooks");
        }
    }
}