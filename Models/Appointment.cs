using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicatieWeb.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Nume Client")]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume', Required, StringLength(50, MinimumLength = 3")]
        [Display(Name = "Prenume Client")]
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set;  }
        public int HairstylistID { get; set; }
        public Hairstylist Hairstylist { get; set; }
        public ICollection<AppointmentService> AppointmentServices { get; set; }
    }
}
