using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicatieWeb.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string ServiceName { get; set; }
        public ICollection<AppointmentService> AppointmentServices { get; set; }
    }
}
