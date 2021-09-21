using IgnitisTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitisTask.Dtos
{
    public class UnitOfWork
    {
        public List<QuestionModel> Questions { get; set; }
        public List<AnswerModel> Answers { get; set; } = new List<AnswerModel>();
        public List<Junction> Junctions { get; set; }
        public QuestionModel Question { get; set; }
        public AnswerModel Answer { get; set; }
        public int FormId { get; set; }
    }
}
