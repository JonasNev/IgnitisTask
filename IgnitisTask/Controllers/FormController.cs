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
            List<int> formIds = _context.Junctions.Select(v => v.FormId).Distinct().ToList();
            return View(formIds);
        }

        public IActionResult StartForm(int id)
        {
            UnitOfWork model = new()
            {
                Questions = _context.Questions.Include(x => x.Answers).ToList(),
                Answers = _context.Answers.ToList(),
                FormId = id
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
