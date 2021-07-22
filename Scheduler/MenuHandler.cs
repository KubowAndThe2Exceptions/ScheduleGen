using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Scheduler
{
    class MenuHandler

    {
        //RESOLVED: Make a question list instead with question class.  Refer to line 32 for info.
        public List<QuestionCouple> Questions;
        public ScheduleGenerator Scheduler;

        public MenuHandler()
        {
            var questionKeeper = new QuestionKeeper();
            Questions = questionKeeper.QuestionCouples;
        }

        public void GreetingPrompt()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the schedule-maker!\nPlease follow the prompts below.");
        }

        public void Questionairre()
        {
            //Needs to ultimately convert to action object
            //var userTimes = new List<DateTime>();
            //var userHowLongs = new List<TimeSpan>();
            //foreach (var couple in Questions)
            //{

            //    for (var index = 0; index <= 1;)
            //    {
            //        couple.Ask(index);
            //        if (couple.TimeSpanCheck(index))
            //        {
            //            try
            //            {
            //                should have placeholder variable to be added to action object
            //                couple.ConvertTimeSpan(index);
            //                Console.Clear();
            //                index++;
            //            }
            //            catch (Exception)
            //            {
            //                Console.WriteLine("incorrect format, try again.");
            //            }
            //        }

            //        else
            //        {
            //            try
            //            {
            //                should have placeholder variable to be added to action object
            //                couple.ConvertDateTime(index);
            //                Console.Clear();
            //                index++;
            //            }
            //            catch (Exception)
            //            {
            //                Console.WriteLine("Incorrect Format, try again.");
            //            }
            //        }
            //    }
            //}
            //Scheduler.SetLists(userTimes, userHowLongs);
        }
    }
}
