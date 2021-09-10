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

        public void Questionairre() // --BUG-- conflicting datetime spits out "incorrect format" when it shouldnt.  Fix error somehow
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
                    couple.Ask(index);
                    
                    //Will check if entry is a timespan or else datetime before sending input to ScheduleGen for validation.
                    //Sends new Action to ScheduleGen each loop through.
                    if (couple.TimeSpanCheck(index) == true)
                    {
                        try
                        {
                            actionSpan = couple.ConvertTimeSpan(index);
                            
                            if (actionWhen != emptyDate)
                            {
                                var endDate = actionWhen + actionSpan;
                                var validated = Scheduler.ValidateDateTime(endDate);
                                if (!validated)
                                {
                                    throw new Exception("This end time is already taken.");
                                }
                                else
                                {
                                    Console.Clear();
                                    index++;
                                }
                            }
                            
                            else
                            {
                                throw new Exception("Must know when an action happens prior to how long it will take.");
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("incorrect format, try again.");
                        }
                    }

                    else
                    {
                        try
                        {
                            actionWhen = couple.ConvertDateTime(index);
                            var validated = Scheduler.ValidateDateTime(actionWhen);
                            if (!validated)
                            {
                                throw new Exception("This end time is already taken, please try again.  Enter anything to continue.");
                            }
                            else
                            {
                                Console.Clear();
                                index++;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Incorrect Format, try again.");
                        }
                    }
                }
                Scheduler.RegisterAction(new Action(actionWhen, actionSpan));
            }
            Scheduler.DisplaySchedule();
        }
    }
}
