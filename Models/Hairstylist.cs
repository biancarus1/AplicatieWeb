using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicatieWeb.Models
{
    public class Hairstylist
    {
        public int ID { get; set; }
        public string NumeHairstylist { get; set; }
        public string PrenumeHairstylist { get; set; }
        public string Experienta { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
