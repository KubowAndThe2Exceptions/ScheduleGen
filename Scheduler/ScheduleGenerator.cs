using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    //Handles the majority of sorting and conflicts with Action creation and Action setting
    public class ScheduleGenerator
    {
        private List<Action> Actions { get; set; } = new List<Action>();
        private List<Action> Conflicts { get; set; } = new List<Action>();

        private Action HeldAction { get; set; } = new Action(DateTime.MinValue, DateTime.MinValue);
        
        public ScheduleGenerator()
        {

        }

        //Checks list of DateTime input against list of Actions and HeldAction for conflicts
        public bool ValidateSpan(DateTime dateToCheck) 
        {
            Conflicts.Clear();
            bool isValid = true;
            List<DateTime> conflicts = new List<DateTime>(); // < List never used, remove.

            foreach (var action in Actions)
            {
                int comparedWhen = action.When.CompareTo(HeldAction.When); 
                int comparedWtoE = action.When.CompareTo(dateToCheck);
                if (comparedWhen >= 0 && comparedWtoE <= 0)
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

        //Functionally the same as ValidateSpan, but sets first half of HeldAction
        public bool ValidateDateTime(DateTime dateToCheck)
        {
            Conflicts.Clear();
            bool isValid = true;
            List<DateTime> conflicts = new List<DateTime>();

            foreach (var action in Actions)
            {
                int comparedWtoW = action.When.CompareTo(dateToCheck);
                int comparedEtoE = action.End.CompareTo(dateToCheck);
                if (comparedWtoW <= 0 && comparedEtoE >= 0)
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
                HeldAction.SetWhen(dateToCheck);
                return isValid;
            }
        }

        //Registers an action and sorts all actions based on when they start
        public void RegisterAction(Action action)
        {
            Actions.Add(action);
            Actions.Sort((x, y) => DateTime.Compare(y.When, x.When));
            
            HeldAction.SetEnd(DateTime.MinValue);
            HeldAction.SetWhen(DateTime.MinValue);
        }

        //Displays Actions, as well as the HeldAction left to be completed by user
        public void DisplaySchedule()
        {
            foreach (var action in Actions)
            {
                action.DisplayTime();
            }
            Console.WriteLine();
            HeldAction.DisplayTime();
        }
        
        //Displays Actions and highlights conflicts.
        public void DisplayScheduleConflict(string lastInput)
        {
            bool isConflict;
            for (var actionNum = Actions.Count - 1; actionNum > -1; actionNum--)
            {
                isConflict = false;

                foreach (var conflict in Conflicts)
                {
                    if (Actions[actionNum] == conflict)
                    {
                        isConflict = true;
                        break;
                    }
                }
                
                if (isConflict == true)
                {
                    Actions[actionNum].HighlightTime();
                }
                else
                {
                    Actions[actionNum].DisplayTime();
                }
            }
            Console.WriteLine();
            HeldAction.DisplayTime();

            if (Conflicts.Count > 1)
            {
                Console.WriteLine("Your time \"{0}\" conflicts with other times.", lastInput);
            }
            
            else
            {
                Console.WriteLine("Your time \"{0}\" conflicts with another time.", lastInput);
            }
        }
    }
}
