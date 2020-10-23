using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Task4_True.Pages.Models;

namespace Task4_True.Control
{
    public class LoginControl : Controller
    {
        UserControl control = new UserControl();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Name = model.Name, email = model.Email, Password = model.Password };
                bool work = await control.Create(user);
                if (work)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                  ModelState.AddModelError("", "Error");
                    
                }
            }
            return View(model);
        }
    }
}
