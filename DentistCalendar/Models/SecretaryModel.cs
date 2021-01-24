using DentistCalendar.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCalendar.Models
{
    public class SecretaryModel
    {
        public AppUser AppUser { get; set; }
        public List<AppUser> Dentists { get; set; }
    }
}
