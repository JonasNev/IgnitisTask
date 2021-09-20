using IgnitisTask.Data;
using IgnitisTask.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgnitisTask.Controllers
{
    public class FormController : Controller
    {
        private readonly DataContext _context;

        public FormController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StartForm()
        {
            UnitOfWork model = new()
            {
                Questions = _context.Questions.Include(x => x.Answers).ToList(),
                Answers = _context.Answers.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveForm(UnitOfWork unitOfWork)
        {
            _context.Answers.Add(unitOfWork.Answer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
