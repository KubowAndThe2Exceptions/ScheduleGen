using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Scheduler
{
    class Question
    {
        public bool IsTimeSpan { get; set; }
        public string QuestionContent { get; set; }

        public Question(bool isTimeSpan, string questionContent)
        {
            IsTimeSpan = isTimeSpan;
            QuestionContent = questionContent;
        }

        public void QAsk()
        {
            Console.WriteLine(QuestionContent);
        }
        public bool QTimeSpanCheck()
        {
            return IsTimeSpan;
        }
        public TimeSpan QConvertTimeSpan()
        {
            int minute = 0;
            int hour = 0;
            var timeString = Console.ReadLine().ToLower();
            var regMatch = false;
            var formats = new List<Regex>
            {
                new Regex(@"\A\d+[h]\s\d+[m]$"),
                new Regex(@"\A\d+[h]$"),
                new Regex(@"\A\d+[m]$")
            };
            
            while (!regMatch)
            {
                foreach (var rx in formats)
                {
                    if (rx.IsMatch(timeString))
                    {
                        regMatch = true;
                        break;
                    }
                }
                
                if (!regMatch)
                {
                    Console.WriteLine("Incorrect format, please try again.");
                    return new TimeSpan(0, 0, 0);
                }
            }
         
            //splits into exactly two substrings, then checks if ends with m or h before removing them and converting to int
            var timeStringSplits = timeString.Split(new string[] { " " }, 2, StringSplitOptions.None);
            foreach (var split in timeStringSplits)
            {
                if (split.EndsWith("m"))
                {
                    var mRemoved = split.Remove(split.Length - 1);
                    var whiteRemoved = mRemoved.Replace(" ", "");
                    minute = Convert.ToInt32(whiteRemoved);

                }
                else if (split.EndsWith("h"))
                {
                    var hRemoved = split.Remove(split.Length - 1);
                    var whiteRemoved = hRemoved.Replace(" ", "");
                    hour = Convert.ToInt32(whiteRemoved);
                }
            }
            
            if (hour >= 23 || minute >= 1380) 
            {
                Console.WriteLine("Span of time cannot exceed 23 hours.");
                return new TimeSpan(0, 0, 0);
            }
            else
            {
                return new TimeSpan(hour, minute, 0);
            }
        }
        
        public DateTime QConvertDateTime()
        {
                System.DateTime inputTime = DateTime.Parse(Console.ReadLine());
                return inputTime;
        }
    }
}
