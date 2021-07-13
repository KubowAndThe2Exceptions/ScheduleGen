using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Question
    {
        public bool isInt { get; set; }
        public string questionContent { get; set; }

        public Question(bool isAnInt, string qCon)
        {
            isInt = isAnInt;
            questionContent = qCon;
        }
    }
}
