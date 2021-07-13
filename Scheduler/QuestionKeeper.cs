using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class QuestionKeeper
    {
        public List<QuestionCouple> QuestionCouples { get; private set; }

        public QuestionKeeper()
        {
            QuestionCouples = new List<QuestionCouple>
            {
                new QuestionCouple
                (new Question(false, "Please enter when you go to bed (hh/mm, military)"),
                new Question(true, "Please enter how long you sleep (hh/mm, military)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat breakfast (hh/mm, military)"),
                new Question(true, "Please enter how long you eat breakfast (hh/mm, military)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat lunch (hh/mm, military)"),
                new Question(true, "Please enter how long you eat lunch (hh/mm, military)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat dinner (hh/mm, military)"),
                new Question(true, "Please enter how long you eat dinner (hh/mm, military)"))
            };
        }
    }
}
