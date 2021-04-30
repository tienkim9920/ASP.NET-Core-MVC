using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly Connection connection;

        public HomeController(Connection _connection)
        {
            connection = _connection;
        }

        public IActionResult Index()
        {

            List<USER> users = connection.USER.ToList();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(USER user)
        {
            if (user.fullname == null)
            {
                TempData["errorFullname"] = "* Vui Lòng Kiểm Lại Full Name!";
                return View();
            }
            else
            {
                if (user.email == null)
                {
                    TempData["errorEmail"] = "* Vui Lòng Kiểm Lại Email!";
                    return View();
                }
                else
                {
                    if (user.password == null)
                    {
                        TempData["errorPassword"] = "* Vui Lòng Kiểm Lại Password!";
                        return View();
                    }
                    else
                    {
                        Random random = new Random();

                        USER newUser = new USER();
                        newUser.id = "U" + random.Next(1000, 10000);
                        newUser.fullname = user.fullname;
                        newUser.email = user.email;
                        newUser.password = user.password;

                        connection.USER.Add(newUser);
                        connection.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
        }

        public IActionResult Delete(string id)
        {
            var user = connection.USER.Find(id);
            connection.USER.Remove(user);
            connection.SaveChanges();
            return RedirectToAction("Index", new { message = "Delete Success!" });
        }

        //HTTP - GET
        public IActionResult Update(string id)
        {
            var user = connection.USER.Find(id);

            return View(user);
        }

        //HTTP - POST
        [HttpPost]
        public IActionResult Update(string id, USER user)
        {
            USER newUser = new USER();
            newUser.id = id;
            newUser.fullname = user.fullname;
            newUser.email = user.email;
            newUser.password = user.password;

            connection.USER.Update(newUser);
            connection.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
