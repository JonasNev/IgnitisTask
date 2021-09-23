using IgnitisTask.Data;
using IgnitisTask.Dtos;
using IgnitisTask.Services;
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
        private readonly FormService _formService;

        public FormController(DataContext context, FormService formService)
        {
            _context = context;
            _formService = formService;
        }

        public IActionResult Index()
        {
            List<int> formIds = _context.Junctions.Select(v => v.FormId).Distinct().ToList();
            return View(formIds);
        }

        public IActionResult StartForm(int id)
        {
            UnitOfWork model = _formService.GetEssentials(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveForm(UnitOfWork unitOfWork)
        {
            _formService.SaveForm(unitOfWork);
            return RedirectToAction("Index");
        }
    }
}
