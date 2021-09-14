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
        
        public ScheduleGenerator()
        {

        }

        public bool ValidateDateTime(DateTime dateToCheck)
        {
            bool isValid = true;
            foreach (var action in Actions)
            {
                int comparedWhen = action.When.CompareTo(dateToCheck);
                int comparedEnd = action.End.CompareTo(dateToCheck);
                if (comparedWhen <= 0 && comparedEnd >= 0)
                {
                    isValid = false;
                    return isValid;
                }
                else
                {
                    isValid = true;
                }
            }

            return isValid;
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
        
        public void DisplayScheduleConflict(DateTime conflictingAction) //--STILL IMPLEMENTING-- Has to somehow check list, find conflict, and then highlight.
        //--CONT.-- If conflicts with two or more times, highlight all times, change console message appropriately for plural.
        {
            foreach (var action in Actions)
            {
                action.DisplayTime();
            }
        }
    }
}
