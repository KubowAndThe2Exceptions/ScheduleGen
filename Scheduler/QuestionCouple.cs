using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    //Class designed to contain two related questions and pass information to/from Question objects
    class QuestionCouple
    {
        public List<Question> _coupleOfQuestions { get; private set; }

        public QuestionCouple(Question whenQ, Question howLongQ)
        {
            _coupleOfQuestions = new List<Question>();
            _coupleOfQuestions.Add(whenQ);
            _coupleOfQuestions.Add(howLongQ);
        }
        
        //Passes the ask request down to the Question layer
        public void Ask(int index)
        {
            _coupleOfQuestions[index].QAsk();
        }
        
        //Passes the TimeSpanCheck down to the Question layer
        public bool TimeSpanCheck(int index)
        {
            return _coupleOfQuestions[index].QTimeSpanCheck();
        }
        
        //Passes the ConvertTimeSpan request down to the Question layer
        public TimeSpan ConvertTimeSpan(int index, string input)
        {
            return _coupleOfQuestions[index].QConvertTimeSpan(input);
        }
        
        //Passes the ConvertDateTime down to the Question layer 
        public DateTime ConvertDateTime(int index, string input)
        {
            return _coupleOfQuestions[index].QConvertDateTime(input);
        }
    }
}
