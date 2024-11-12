﻿using Bulky.DataAcess.Data;
using Bulky.Models;
using Bulky.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objUserList = _db.ApplicationUsers.Include(u => u.company).ToList();

            foreach (var user in objUserList)
            {
                if (user.company == null)
                {
                    user.company = new Company() { name = "" };
                }
            }
            return Json(new { data = objUserList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            return Json(new { success = true, message = "Company deleted successfully" });
        }
    }
}