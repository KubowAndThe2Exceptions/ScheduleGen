using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{//--FEATURE IDEA-- Find way to have user create schedule times, then ask questions in relation? Would be much more efficient and is entirely possible.
    class QuestionKeeper
    {
        public List<QuestionCouple> QuestionCouples { get; private set; }

        public QuestionKeeper()
        {
            QuestionCouples = new List<QuestionCouple>
            {
                new QuestionCouple
                (new Question(false, "Please enter when you go to bed (ex: hh/mm AM/PM, Military also accepted.)"),
                new Question(true, "Please enter how long you sleep (ex: 3h 30m = 3 hours and 30 mins)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat breakfast (ex: hh/mm AM/PM, Military also accepted.)"),
                new Question(true, "Please enter how long you eat breakfast (ex: 3h 30m = 3 hours and 30 mins)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat lunch (ex: hh/mm AM/PM, Military also accepted.)"),
                new Question(true, "Please enter how long you eat lunch (ex: 3h 30m = 3 hours and 30 mins)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat dinner (ex: hh/mm AM/PM, Military also accepted.)"),
                new Question(true, "Please enter how long you eat dinner (ex: 3h 30m = 3 hours and 30 mins)"))
            };
        }
        public void Ask(int index, int question)
        {
            QuestionCouples[index].Ask(question);
        }
        public bool TimeSpanCheck(int index, int question)
        {
            return QuestionCouples[index].TimeSpanCheck(question);
        }
    }
}
