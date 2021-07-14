using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class QuestionCouple
    {
        public List<Question> _coupleOfQuestions { get; private set; }

        public QuestionCouple(Question whenQ, Question howLongQ)
        {
            _coupleOfQuestions = new List<Question>();
            _coupleOfQuestions.Add(whenQ);
            _coupleOfQuestions.Add(howLongQ);
        }
        public void Ask(int index)
        {
            _coupleOfQuestions[index].QAsk();
        }
        public bool TimeSpanCheck(int index)
        {
            return _coupleOfQuestions[index].QTimeSpanCheck();
        }
        public TimeSpan ConvertTimeSpan(int index)
        {
            return _coupleOfQuestions[index].QConvertTimeSpan();
        }
        public DateTime ConvertDateTime(int index)
        {
            return _coupleOfQuestions[index].QConvertDateTime();
        }
    }
}
