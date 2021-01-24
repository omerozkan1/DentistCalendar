using DentistCalendar.Data;
using DentistCalendar.Data.Entity;
using DentistCalendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DentistCalendar.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _applicationDbContext;
        public AppointmentController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public JsonResult GetAppointments()
        {
            var model = _applicationDbContext.Appointments.Include(x => x.AppUser).Select(x => new AppointmentModel()
            {
                Dentist = x.AppUser.Name + " " + x.AppUser.SurName,
                Patient = x.PatientName + " " + x.PatientSurname,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Description = x.Description,
                AppUserId = x.AppUser.Id
            });
            return Json(model);
        }

        public JsonResult GetAppointments(string userId = "")
        {
            var model = _applicationDbContext.Appointments.Include(x => x.UserId == userId).Select(x => new AppointmentModel()
            {
                Dentist = x.AppUser.Name + " " + x.AppUser.SurName,
                Patient = x.PatientName + " " + x.PatientSurname,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Description = x.Description,
                AppUserId = x.AppUser.Id
            });
            return Json(model);
        }

        [HttpPost]
        public JsonResult AddOrUpdateAppointment(AddOrUpdateAppointmentModel model)
        {
            if (model.Id == 0)
            {
                Appointment entity = new Appointment()
                { 
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PatientName = model.PatientName,
                    PatientSurname = model.PatientSurname,
                    Description = model.Description,
                    UserId = model.UserId
                };

                _applicationDbContext.Add(entity);
                _applicationDbContext.SaveChanges();
            }
            else
            {
                var entity = _applicationDbContext.Appointments.SingleOrDefault(x => x.Id == model.Id);
                if (entity == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                }
                entity.UpdatedDate = DateTime.Now;
                entity.PatientName = model.PatientName;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.PatientName = model.PatientName;
                entity.PatientSurname = model.PatientSurname;
                entity.Description = model.Description;
                entity.UserId = model.UserId;

                _applicationDbContext.Update(entity);
                _applicationDbContext.SaveChanges();
            }
            return Json("200");
        }

        public JsonResult DeleteAppointment(int id = 0)
        {
            var entity = _applicationDbContext.Appointments.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return Json("Kayıt bulunamadı");
            }

            _applicationDbContext.Remove(entity);
            _applicationDbContext.SaveChanges();
            return Json("200");
        }
    }
}
