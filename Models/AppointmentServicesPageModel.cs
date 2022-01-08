using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AplicatieWeb.Data;



namespace AplicatieWeb.Models
{
    public class AppintmentServicesPageModel : PageModel
    {
        public List<AssignedServiceData> AssignedServiceDataList;
        public void PopulateAssignedServiceData(AplicatieWebContext context,
        Appointment appointment)
        {
            var allServices = context.Service;
            var appointmentServices = new HashSet<int>(
            appointment.AppointmentServices.Select(c => c.ServiceID)); //
            AssignedServiceDataList = new List<AssignedServiceData>();
            foreach (var cat in allServices)
            {
                AssignedServiceDataList.Add(new AssignedServiceData
                {
                    ServiceID = cat.ID,
                    Name = cat.ServiceName,
                    Assigned = appointmentServices.Contains(cat.ID)
                });
            }
        }
        public void UpdateAppointmentServices(AplicatieWebContext context,
        string[] selectedServices, Appointment appointmentToUpdate)
        {
            if (selectedServices == null)
            {
                appointmentToUpdate.AppointmentServices = new List<AppointmentService>();
                return;
            }
            var selectedServicesHS = new HashSet<string>(selectedServices);
            var appointmentServices = new HashSet<int>
            (appointmentToUpdate.AppointmentServices.Select(c => c.Service.ID));
            foreach (var cat in context.Service)
            {
                if (selectedServicesHS.Contains(cat.ID.ToString()))
                {
                    if (!appointmentServices.Contains(cat.ID))
                    {
                        appointmentToUpdate.AppointmentServices.Add(
                        new AppointmentService
                        {
                            AppointmentID = appointmentToUpdate.ID,
                            ServiceID = cat.ID
                        });
                    }
                }
                else
                {
                    if (appointmentServices.Contains(cat.ID))
                    {
                        AppointmentService courseToRemove
                        = appointmentToUpdate
                        .AppointmentServices
                       .SingleOrDefault(i => i.ServiceID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
