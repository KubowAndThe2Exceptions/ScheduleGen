using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class ScheduleGenerator
    {
        private List<DateTime> whenList { get; set; }
        private List<TimeSpan> howLongList { get; set; }
        public ScheduleGenerator()
        {

        }

        public void SetLists(List<DateTime> whens, List<TimeSpan> howLongs)
        {
            whenList = whens;
            howLongList = howLongs;
        }
    }
}
