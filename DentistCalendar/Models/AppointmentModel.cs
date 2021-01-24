using System;

namespace DentistCalendar.Models
{
    public class AppointmentModel
    {
        public string Dentist { get; set; }
        public string Patient { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string AppUserId { get; set; }

    }
}
