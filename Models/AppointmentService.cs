using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicatieWeb.Models
{
    public class AppointmentService
    {
        public int ID { get; set; }
        public int AppointemntID { get; set; }
        public Appointment Appointment { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }
        public int AppointmentID { get; internal set; }
    }
}
