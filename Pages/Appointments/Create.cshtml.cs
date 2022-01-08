using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AplicatieWeb.Data;
using AplicatieWeb.Models;

namespace AplicatieWeb.Pages.Appointments
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
            ViewData["HairstylistID"] = new SelectList(_context.Set<Hairstylist>(), "ID", "NumeHairstylist", "PrenumeHairstylist", "Experienta");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
