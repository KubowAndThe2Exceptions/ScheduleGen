using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class ScheduleGenerator
    {
        private List<Action> Actions { get; set; } = new List<Action>();
        private List<Action> Conflicts { get; set; } = new List<Action>();
        
        public ScheduleGenerator()
        {

        }

        public bool ValidateDateTime(DateTime dateToCheck)
        {
            Conflicts.Clear();
            bool isValid = true;
            List<DateTime> conflicts = new List<DateTime>();

            foreach (var action in Actions)
            {
                int comparedWhen = action.When.CompareTo(dateToCheck);
                int comparedEnd = action.End.CompareTo(dateToCheck);
                if (comparedWhen <= 0 && comparedEnd >= 0)
                {
                    Conflicts.Add(action);
                    continue;
                }
            }

            if (Conflicts.Count > 0)
            {
                isValid = false;
                return isValid;
            }
            else
            {
                return isValid;
            }
        }

        public void RegisterAction(Action action)
        {
            Actions.Add(action);
            Actions.Sort((x, y) => DateTime.Compare(y.When, x.When));
        }

        public void DisplaySchedule() //--FEATURE NEEDED-- Should display all times AND what happens at them.
        {
            foreach (var action in Actions)
            {
                action.DisplayTime();
            }
        }
        
        public void DisplayScheduleConflict() //--STILL IMPLEMENTING-- Has to somehow check list, find conflict, and then highlight.
        //--CONT.-- If conflicts with two or more times, highlight all times, change console message appropriately for plural.
        {
            foreach (var action in Actions)
            {
                foreach (var conflict in Conflicts)
                {
                    if (action == conflict)
                    {
                        action.HighlightTime();
                        continue;
                    }
                    else
                    {
                        action.DisplayTime();
                    }
                }
            }

            if (Conflicts.Count > 1)
            {
                Console.WriteLine("Your time conflicts with other times.");
            }
            
            else
            {
                Console.WriteLine("Your time conflicts with another time.");
            }
        }
    }
}
