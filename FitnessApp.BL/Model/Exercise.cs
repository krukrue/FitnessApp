using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Activity Activity { get; set; }
        public virtual User User { get; set; }

        public Exercise() { }
        public Exercise(DateTime start, DateTime end, Activity activity, User user)
        {
            Start = start;
            End = end;
            Activity = activity;
            User = user;

        }
    }
}
