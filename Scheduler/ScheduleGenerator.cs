using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    //Needs revamping for handling Action class specifically
    public class ScheduleGenerator
    {
        private List<Action> Actions { get; set; } = new List<Action>();
        
        public ScheduleGenerator()
        {

        }

        //public bool ValidateActionWhen(DateTime When)
        //{
        //    //compare to action list, return true/false
        //}

        //public bool ValidateActionEnd(DateTime End)
        //{
        //    //compare to action list, return true/false
        //}

        public void RegisterAction(Action action)
        {
            Actions.Add(action);
        }

        private void SortActionList()
        {
            //Add implementation
        }
    }
}
