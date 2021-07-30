using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pseudo concept:
            //Enter sleep/eating times.
            //Enter activities
            //Enter Mainstay habits/times
            var Menu = new MenuHandler();
            Menu.Questionairre();
            
        }
    }
}
