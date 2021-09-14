using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Action
    {
        public DateTime When { get; private set; } = new DateTime();
        private TimeSpan _howLong { get; set; } = new TimeSpan();
        public DateTime End { get; private set; } = new DateTime();

        public Action(DateTime when, TimeSpan howLong)
        {
            When = when;
            _howLong = howLong;
            End = when + howLong;
        }
        public Action(DateTime when, DateTime end)
        {
            When = when;
            End = end;
        }

        public void DisplayTime()
        {
            Console.WriteLine(this.When.ToShortTimeString() + " - " + this.End.ToShortTimeString());
        }
        
        public void HighlightTime()
        {
            var prevBackColor = Console.BackgroundColor;
            var prevForeColor = Console.ForegroundColor;
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            this.DisplayTime();
            
            Console.BackgroundColor = prevBackColor;
            Console.ForegroundColor = prevForeColor;
        }
    }
}
