using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieWeb.Data;
using AplicatieWeb.Models;

namespace AplicatieWeb.Pages.Hairstylists
{
    public class CreateModel : PageModel
    {
        private readonly AplicatieWeb.Data.AplicatieWebContext _context;

        public CreateModel(AplicatieWeb.Data.AplicatieWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hairstylist Hairstylist { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hairstylist.Add(Hairstylist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
