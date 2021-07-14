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
            _coupleOfQuestions[index].Ask();
        }
    }
}
