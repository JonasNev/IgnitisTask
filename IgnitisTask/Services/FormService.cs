using IgnitisTask.Data;
using IgnitisTask.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitisTask.Services
{
    public class FormService
    {
        private readonly DataContext _context;

        public FormService(DataContext context)
        {
            _context = context;
        }

        public UnitOfWork GetEssentials(int id)
        {
            UnitOfWork model = new()
            {
                Questions = _context.Questions.Include(x => x.Answers).ToList(),
                Answers = _context.Answers.ToList(),
                FormId = id,
                SavedJunctions = _context.Junctions.Where(x => x.FormId == id).Include(x => x.Question).ThenInclude(x => x.Answers).ToList()
            };

            return model;
        }
        public void SaveForm(UnitOfWork unitOfWork)
        {
            for (int i = 0; i < unitOfWork.Junctions.Count; i++)
            {
                if (unitOfWork.Junctions[i].AnswerId != 0)
                {
                    unitOfWork.Junctions[i].QuestionId = unitOfWork.Questions[i].Id;
                    unitOfWork.Junctions[i].FormId = unitOfWork.FormId;
                    _context.Junctions.Add(unitOfWork.Junctions[i]);
                }
            }
            _context.SaveChanges();
        }
    }
}
