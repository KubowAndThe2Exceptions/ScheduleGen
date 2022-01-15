using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    //Class used to represent a span of time with a start and end TimeSpan.  Is stored within a list in ScheduleGen.
    public class Action
    {
        public DateTime When { get; private set; } = new DateTime();
        private TimeSpan _howLong { get; set; } = new TimeSpan();
        public DateTime End { get; private set; } = new DateTime();

        //Constructors
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
        public Action(DateTime when)
        {
            When = when;
            End = DateTime.MinValue;
        }

        //Attribute Access Methods
        public void SetWhen(DateTime when)
        {
            When = when;
        }

        public void SetEnd(DateTime end)
        {
            End = end;
        }

        //Checks if this has a start time set yet
        public bool HasWhen()
        {
            if (this.When != DateTime.MinValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Checks if this has an end time set yet
        public bool HasEnd()
        {
            if (this.End != DateTime.MinValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Displays start and end time of this Action object
        public void DisplayTime()
        {
            if (this.HasWhen() && this.HasEnd())
            {
                Console.WriteLine(this.When.ToShortTimeString() + " - " + this.End.ToShortTimeString());
            }
            else if (this.HasWhen() && !this.HasEnd())
            {
                Console.WriteLine(this.When.ToShortTimeString() + " - 00:00");
            }
            else
            {
                Console.WriteLine("00:00 - 00:00");
            }
        }
        
        //NOTE: May be better to store in attributes somehow? Maybe with Enums?
        //Highlight format for highlighting.
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
