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
                    couple.Ask(index);

                    //Will check if entry is a timespan or else datetime before sending input to ScheduleGen for validation.
                    //Sends new Action to ScheduleGen each loop through.
                    if (couple.TimeSpanCheck(index) == true)
                    {
                        try
                        {
                            actionSpan = couple.ConvertTimeSpan(index); //--BUG-- accepts an input of "2 d" which it absolutely should NOT. Figure out WHY
                        }
                        
                        catch (Exception)
                        {
                            Console.WriteLine("incorrect format, try again.");
                        }
                       
                        if (actionWhen != emptyDate)
                        {
                            var endDate = actionWhen + actionSpan;
                            var validated = Scheduler.ValidateDateTime(endDate);
                            if (!validated)
                            {
                                Console.WriteLine("This end time is already taken.");
                            }
                            else
                            {
                                Console.Clear();
                                index++;
                            }
                        }

                        else
                        {
                            Console.WriteLine("Must know when an action happens prior to how long it will take.");
                        }
                    }

                    else
                    {
                        actionWhen = couple.ConvertDateTime(index); //--BUG-- does not catch exceptions.  It should. Is the possible without a try-catch here?
                        // is it possible with a try-catch in ConvertDateTime? test this.
                        var validated = Scheduler.ValidateDateTime(actionWhen);
                        if (!validated)
                        {
                            Console.WriteLine("This end time is already taken, please try again.  Enter anything to continue.");
                        }
                        else
                        {
                            Console.Clear();
                            index++;
                        }
                    }
                }
                Scheduler.RegisterAction(new Action(actionWhen, actionSpan));
            }
            Scheduler.DisplaySchedule();
        }
    }
}
