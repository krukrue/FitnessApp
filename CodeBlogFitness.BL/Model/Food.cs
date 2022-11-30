using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string? Name { get;  }
        public double Proteins { get; }
        public double Fats { get;  }
        public double Carbrohydrates { get; }
        public double Calorie { get; }


        public Food(string NAME) : this (NAME, 0 , 0 , 0, 0)
        {
            Name = NAME;
        }

        public Food(string? name,  double calorie, double proteins, double fats, double carbrohydrates)
        {
            Name = name;
            Proteins=proteins / 100;
            Fats=fats / 100;
            Carbrohydrates=carbrohydrates/ 100;
            Calorie=calorie / 100;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
