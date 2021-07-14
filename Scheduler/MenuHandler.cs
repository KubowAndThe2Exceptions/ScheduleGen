﻿using System;
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
            var userTimes = new List<DateTime>();
            var userHowLongs = new List<TimeSpan>();
            var i = 0;
            while (i < Questions.Count)
            {
                GreetingPrompt();
                Console.WriteLine(Questions[i].QuestionContent);
                if (Questions[i].IsInt)
                {
                    try
                    {
                        var inputHour = Convert.ToInt32(Console.ReadLine());
                        userHowLongs.Add(new TimeSpan(inputHour, 0, 0));
                        i++;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect Format, try again. Please enter any input to continue.");
                        Console.ReadLine();
                    }
                }
                
                else
                {
                    try
                    {
                        System.DateTime inputTime = DateTime.Parse(Console.ReadLine());
                        userTimes.Add(inputTime);
                        i++;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect Format, try again. Please enter any input to continue.");
                        Console.ReadLine();
                    }
                }

            }
            Scheduler.SetLists(userTimes, userHowLongs);

        }
    }
}
