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
                int compareToWhen = action.When.CompareTo(dateToCheck);
                int compareToEnd = action.End.CompareTo(dateToCheck);
                if (compareToWhen >= 0 && compareToEnd <= 0)
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

        public void DisplaySchedule()
        {
            foreach (var action in Actions)
            {
                action.DisplayTime();
            }
            Console.ReadLine();
        }
    }
}
