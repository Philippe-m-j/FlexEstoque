using FlexEstoque.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlexEstoque.Controllers
{
    public class FAQController : Controller
    {
        private readonly ILogger<FAQController> _context;

        public FAQController(ILogger<FAQController> context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}