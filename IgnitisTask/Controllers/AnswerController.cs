using IgnitisTask.Data;
using IgnitisTask.Dtos;
using IgnitisTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgnitisTask.Controllers
{
    public class AnswerController : Controller
    {
        private readonly DataContext _context;

        public AnswerController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<AnswerModel> answers = _context.Answers.Include(x => x.Question).ToList();
            return View(answers);
        }

        public IActionResult Create()
        {
            UnitOfWork model = new()
            {
                Questions = _context.Questions.ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(UnitOfWork unitOfWork)
        {
            _context.Answers.Add(unitOfWork.Answer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
