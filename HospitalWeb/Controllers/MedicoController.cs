using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalWeb.DAL;

namespace HospitalWeb.Controllers
{
    public class MedicoController : Controller
    {
        

        public IActionResult Index()
        {
           return View();
        }

        public IActionResult Fila()
        {
            return View();
        }




    }
}
