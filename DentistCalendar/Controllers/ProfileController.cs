using DentistCalendar.Data.Entity;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistCalendar.Controllers
{
    public class ProfileController : Controller
    {
        private UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            if (user == null)
                return View("Error");

            if (_userManager.IsInRoleAsync(user, "Secretary").Result)
            {
                SecretaryModel model = new SecretaryModel()
                {
                    AppUser = user,
                    Dentists = _userManager.Users.Where(x => x.IsDentist).ToList()
                };
                return View("Secretary",model);
            }
                
            else
                return View("Dentist");

        }


        public IActionResult Secretary()
        {
            return View();
        }

        public IActionResult Dentist()
        {
            return View();
        }

    }
}
