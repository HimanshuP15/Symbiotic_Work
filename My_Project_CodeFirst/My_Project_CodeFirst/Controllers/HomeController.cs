using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Project_CodeFirst.Models;
using System.Data.Entity;

namespace My_Project_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TableRegister tableRegister)
        {
            using (My_Project_CodeFirst_DBEntities entities = new My_Project_CodeFirst_DBEntities())
            {
                if(ModelState.IsValid)
                {
                    entities.TableRegisters.Add(tableRegister);
                    entities.SaveChanges();
                    if (tableRegister.Id > 0)
                    {
                        ViewBag.Success = "Data Inserted Successfully";
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Success = "Error: Data Insertion Failed";
                    }
                    
                }
            }
            return View(tableRegister);
        }
    }
}