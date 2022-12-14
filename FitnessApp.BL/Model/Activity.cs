using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double CaloriesPerMin { get; set; }
        public Activity(string name, double caloriespermin)
        {
            Name = name;
            CaloriesPerMin = caloriespermin;
        }

        public Activity() { }
        public override string ToString()
        {
            return Name;
        }
    }
}
