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
        //should rename Questions to QuestionCouples
        public List<QuestionCouple> Questions;
        public ScheduleGenerator Scheduler = new ScheduleGenerator();

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

        public void Questionairre() //--FEATURE NEEDED-- Working exceptions at all stages and their sub-stages
        {
            var actionSpan = new TimeSpan();
            var actionWhen = new DateTime();
            var emptyDate = DateTime.MinValue;

            //Cycles through couples
            foreach (var couple in Questions)
            {
                actionWhen = emptyDate;
                
                //cycles questions within couples and askes them to User
                for (var index = 0; index <= 1;)
                {
                    var isAnswered = false;
                    while (!isAnswered)
                    {
                        couple.Ask(index); //--BUG-- Format is not explained correctly, redesign individual questions.

                        //Will check if entry is a timespan or else datetime before sending input to ScheduleGen for validation.
                        //Sends new Action to ScheduleGen each loop through.
                        if (couple.TimeSpanCheck(index) == true)
                        {
                            actionSpan = couple.ConvertTimeSpan(index); //--BUG-- allows for massive numbers of time, inadvertently breaking everything else. Design restrictions
                            if (actionSpan == TimeSpan.Zero)
                            {
                                Console.WriteLine("Incorrect format, please try again.");
                                continue;
                            }

                            if (actionWhen != emptyDate)
                            {
                                var endDate = actionWhen + actionSpan;
                                var validated = Scheduler.ValidateDateTime(endDate);
                                if (!validated)
                                {
                                    Console.WriteLine("This timespan conflicts with another timespan."); //--FEATURE-- display a list, highlight conflicting timespan?
                                    continue;
                                }
                                else
                                {
                                    Console.Clear();
                                    isAnswered = true;
                                    index++;
                                }
                            }
                        }

                        else
                        {
                            try
                            {
                                actionWhen = couple.ConvertDateTime(index);
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Incorrect format, please try again.");
                                continue;
                            }
                            
                            var validated = Scheduler.ValidateDateTime(actionWhen);
                            
                            if (!validated)
                            {
                                Console.WriteLine("This start time is already taken, please try again.  Enter anything to continue.");
                                continue;
                            }
                            else
                            {
                                Console.Clear();
                                isAnswered = true;
                                index++;
                            }
                        }
                    }
                }
                Scheduler.RegisterAction(new Action(actionWhen, actionSpan));
            }
            Scheduler.DisplaySchedule();
        }
    }
}
