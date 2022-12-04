using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Food
    {
        public int ID { get; set; }

        public string? Name { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbrohydrates { get; set; }
        public double Calorie { get; set; }

        public int EatingID { get; set; }
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
        public Food() { }
        public override string ToString()
        {
            return Name;
        }
    }
}
