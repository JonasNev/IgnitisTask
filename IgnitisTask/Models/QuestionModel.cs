using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitisTask.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerModel> Answers { get; set; }
        public ICollection<Junction> Junctions { get; set; }
    }
}
