using IgnitisTask.Data;
using IgnitisTask.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgnitisTask.Controllers
{
    public class QuestionController : Controller
    {
        private readonly DataContext _context;

        public QuestionController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<QuestionModel> questions = _context.Questions.ToList();
            return View(questions);
        }

        public IActionResult Create()
        {
            QuestionModel model = new();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(QuestionModel questionModel)
        {
            _context.Questions.Add(questionModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
