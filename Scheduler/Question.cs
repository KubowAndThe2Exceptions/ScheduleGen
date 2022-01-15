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

        //Displays the Question to the user
        public void QAsk()
        {
            Console.WriteLine(QuestionContent);
        }
        
        //Question identifies whether or not it requires a TimeSpan
        public bool QTimeSpanCheck()
        {
            return IsTimeSpan;
        }
        
        //Converts string input into a Timespan
        public TimeSpan QConvertTimeSpan(string input)
        {
            int minute = 0;
            int hour = 0;
            var timeString = input.ToLower();
            var regMatch = false;
            var formats = new List<Regex>
            {
                new Regex(@"\A\d+[h]\s\d+[m]$"),
                new Regex(@"\A\d+[h]$"),
                new Regex(@"\A\d+[m]$")
            };
            
            //Checks for regex match.  NOTE: Consider whether or not "while" loop is necessary.  "if" logic is probably all I need.
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
         
            //splits into exactly two substrings, then checks if ends with m (for minutes) or h (for hours) before removing them and converting remaining numbers to int
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
        
        //Converts string to DateTime and returns it
        public DateTime QConvertDateTime(string input)
        {
                System.DateTime inputTime = DateTime.Parse(input);
                return inputTime;
        }
    }
}
