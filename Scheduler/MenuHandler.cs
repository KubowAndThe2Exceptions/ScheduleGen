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
        public string LastInput = string.Empty;

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
                    couple.Ask(index);
                    Scheduler.DisplaySchedule();
                    Console.WriteLine("\r");

                    while (!isAnswered)
                    {
                        //Will check if entry is a timespan or else datetime before sending input to ScheduleGen for validation.
                        //Sends new Action to ScheduleGen each loop through.
                        if (couple.TimeSpanCheck(index) == true)
                        {
                            LastInput = Console.ReadLine();
                            actionSpan = couple.ConvertTimeSpan(index, LastInput);
                            if (actionSpan == TimeSpan.Zero)
                            {
                                continue;
                            }

                            if (actionWhen != emptyDate)
                            {
                                var endDate = actionWhen + actionSpan;
                                var validated = Scheduler.ValidateSpan(endDate);
                                if (!validated)
                                {
                                    Console.Clear();
                                    couple.Ask(index);
                                    Scheduler.DisplayScheduleConflict(LastInput);
                                    Console.WriteLine("\r");
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
                                LastInput = Console.ReadLine();
                                actionWhen = couple.ConvertDateTime(index, LastInput);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Incorrect format, please try again.");
                                continue;
                            }
                            
                            var validated = Scheduler.ValidateDateTime(actionWhen);
                            
                            if (!validated)
                            {
                                Console.Clear();
                                couple.Ask(index);
                                Scheduler.DisplayScheduleConflict(LastInput);
                                Console.WriteLine("\r");
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
