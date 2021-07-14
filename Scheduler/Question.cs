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
                var inputHour = Convert.ToInt32(Console.ReadLine());
                return new TimeSpan(inputHour, 0, 0);
        }
        public DateTime QConvertDateTime()
        {
                System.DateTime inputTime = DateTime.Parse(Console.ReadLine());
                return inputTime;
        }
    }
}
