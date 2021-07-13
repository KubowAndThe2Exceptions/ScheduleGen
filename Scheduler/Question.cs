using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class Question
    {
        public bool IsTimeSpan { get; set; }
        public string QuestionContent { get; set; }

        public Question(bool isTimeSpan, string questionContent)
        {
            IsTimeSpan = isTimeSpan;
            QuestionContent = questionContent;
        }
    }
}
