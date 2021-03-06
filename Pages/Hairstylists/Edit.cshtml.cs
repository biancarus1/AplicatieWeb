using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicatieWeb.Data;
using AplicatieWeb.Models;

namespace AplicatieWeb.Pages.Hairstylists
{
    public class EditModel : PageModel
    {
        private readonly AplicatieWeb.Data.AplicatieWebContext _context;

        public EditModel(AplicatieWeb.Data.AplicatieWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hairstylist Hairstylist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hairstylist = await _context.Hairstylist.FirstOrDefaultAsync(m => m.ID == id);

            if (Hairstylist == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hairstylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairstylistExists(Hairstylist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HairstylistExists(int id)
        {
            return _context.Hairstylist.Any(e => e.ID == id);
        }
    }
}
