using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{//--FEATURE IDEA-- Find way to have user create schedule times, then ask questions in relation? Would be much more efficient and is entirely possible.
    
    //Class designed to hold pairs of questions (QuestionCouple) and shuttle information between MenuHandler and individual QuestionCouple objects
    class QuestionKeeper
    {
        public List<QuestionCouple> QuestionCouples { get; private set; }

        public QuestionKeeper()
        {
            QuestionCouples = new List<QuestionCouple>
            {
                new QuestionCouple
                (new Question(false, "Please enter when you go to bed (ex: hh:mm AM/PM, Military also accepted.)"),
                new Question(true, "Please enter how long you sleep (ex: 3h 30m = 3 hours and 30 mins)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat breakfast (ex: hh:mm AM/PM, Military also accepted..)"),
                new Question(true, "Please enter how long you eat breakfast (ex: 3h 30m = 3 hours and 30 mins)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat lunch (ex: hh:mm AM/PM, Military also accepted.)"),
                new Question(true, "Please enter how long you eat lunch (ex: 3h 30m = 3 hours and 30 mins)")),

                new QuestionCouple
                (new Question(false, "Please enter the time of day you eat dinner (ex: hh:mm AM/PM, Military also accepted.)"),
                new Question(true, "Please enter how long you eat dinner (ex: 3h 30m = 3 hours and 30 mins)"))
            };
        }
        
        //Passes the ask request down to the QuestionCouple layer
        public void Ask(int index, int question)
        {
            QuestionCouples[index].Ask(question);
        }
        //Passes the TimeSpanCheck request down to the QuestionCouple layer
        public bool TimeSpanCheck(int index, int question)
        {
            return QuestionCouples[index].TimeSpanCheck(question);
        }
    }
}
