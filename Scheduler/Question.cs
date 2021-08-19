using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int minute = new int();
            int hour = new int();
            var mCount = new int();
            var hCount = new int();
            bool containsOnce = false;
            var timeString = Console.ReadLine().ToLower();
            var hasInts = timeString.Any(char.IsDigit);
            
            //checks if m or h appears in timeString
            foreach (var letter in timeString)
            {
                if (letter == 'm')
                {
                    mCount++;
                }
                else if (letter == 'h')
                {
                    hCount++;
                }
            }
            //checks if contains only once or less in timeString before moving forward, this argument needs expanding for all possible scenarios I think
            if (mCount <= 1 && hCount <= 1)
            {
                containsOnce = true;
            }
            else
            {
                throw new Exception("Must enter in aformentioned format.");
            }

            if (containsOnce && hasInts)
            {
                try
                {
                    //splits into exactly two substrings, then checks if ends with m or h before removing them and converting to int
                    var timeStringSplits = timeString.Split(new string[] { ", " }, 2, StringSplitOptions.None);
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
                        else
                        {
                            throw new Exception("Must enter in aformentioned format");
                        }
                    }
                }
                catch (Exception)
                {

                    throw new Exception("Must enter in aformentioned format");
                }

                return new TimeSpan(hour, minute, 0);
            }
            else
            {
                throw new Exception("Must enter in aformentioned format");
            }
        }
        public DateTime QConvertDateTime()
        {
                System.DateTime inputTime = DateTime.Parse(Console.ReadLine());
                return inputTime;
        }
    }
}
