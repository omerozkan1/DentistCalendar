﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DentistCalendar.Data.Entity;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            {
                return View("Error");
            }

            if (_userManager.IsInRoleAsync(user, "Secretary").Result)
            {
                var dentists = _userManager.Users.Where(x => x.IsDentist);
                SecretaryModel model = new SecretaryModel()
                {
                    User = user,
                    Dentists = dentists,
                    DentistsSelectList = dentists.Select(n => new SelectListItem { 
                        Value = n.Id,
                        Text = $"Dt. {n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("Secretary", model);
            }
            else
            {

                return View("Dentist");
            }

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