﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DentistCalendar.Data.Entity
{
    public class AppUser : IdentityUser
    {
        public bool IsDentist { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Color { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
