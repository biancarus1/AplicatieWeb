using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AplicatieWeb.Data;
using AplicatieWeb.Models;

namespace AplicatieWeb.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly AplicatieWeb.Data.AplicatieWebContext _context;

        public IndexModel(AplicatieWeb.Data.AplicatieWebContext context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; }

        public async Task OnGetAsync()
        {
            Appointment = await _context.Appointment
                .Include(b => b.Hairstylist)
                .ToListAsync();
        }
    }
}
