using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IgnitisTask.Models
{
    public class Junction
    {
        public int FormId { get; set; }
        public int QuestionId { get; set; }
        public QuestionModel Question { get; set; }
        public int AnswerId { get; set; }
        public AnswerModel Answer { get; set; }
    }
}
