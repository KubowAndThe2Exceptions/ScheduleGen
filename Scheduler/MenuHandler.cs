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
        public void TasksCollector() //--FEATURE(S)-- Create prompt for collecting tasks.  Should have string list of tasks which gets passed to QK.
            //QK should process string list into list of questions, then automatedly turn questions into questioncouples and place into its list.
            //--FEATURE-- Should be able to enter "fin" for finishing adding prompts.
        {
            Console.WriteLine("Please name tasks you would like to schedule.  Type \"fin\" when you are finished.");
        }

        public void Questionairre() //--FEATURE-- Optionally print schedule to .txt file when finished? Possibly create data base with string values for tasks? 
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
