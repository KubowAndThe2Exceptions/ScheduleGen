using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class QuestionKeeper
    {
        public List<Question> questionsList { get; private set; }

        public QuestionKeeper()
        {
            questionsList = new List<Question>
            {
                new Question(false, "1. Please enter when you go to bed (hh/mm, military)"),
                new Question(true, "2. Please enter how many hours you sleep (hh/mm, military"),
                new Question(false, "3. Please enter the time of day you eat breakfast (hh/mm, military)"),
                new Question(false, "4. Please enter the time of day you eat lunch (hh/mm, military)"),
                new Question(false, "5. Please enter the time of day you eat dinner (hh/mm, military")
            };
        }
    }
}
