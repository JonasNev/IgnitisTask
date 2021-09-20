using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitisTask.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public QuestionModel Question { get; set; }
        public ICollection<Junction> Junctions { get; set; }
    }
}
