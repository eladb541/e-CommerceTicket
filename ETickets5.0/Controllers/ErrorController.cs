using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETickets5._0.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error404()
        {
            return View("NotFound");
        }
    }
}
