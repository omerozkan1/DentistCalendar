using DentistCalendar.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DentistCalendar.Models
{
    public class DentistModel
    {
        public AppUser User { get; set; }
        public IEnumerable<AppUser> Dentists { get; set; }
        public List<SelectListItem> DentistsSelectList { get; set; }
    }
}
