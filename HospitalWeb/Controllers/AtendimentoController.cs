using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Controllers
{
    public class AtendimentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
