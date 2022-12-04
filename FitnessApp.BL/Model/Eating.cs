using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]

    public class Eating
    {
        public int ID { get; set; }

        public DateTime Moment { get; set; }
        public Dictionary <Food, double>? Foods { get; set; } = new Dictionary<Food, double>();
        
        public int UserID { get; set; }
        public virtual User? User { get; set; }
        public double Weight { get; set; } = 0;
        public Eating(User user) { 
            User = user ?? throw new ArgumentNullException("User can't be empty");
            Moment = DateTime.Now;
            Foods = new Dictionary <Food, double>();
        }
        public Eating()
        {

        }
        public void Add(Food food, double weight) {
            Weight += weight;


            Console.WriteLine(food.Name);
            var product = Foods?.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));
            if (product == null)
            {
                Foods.Add(food, weight);
            }else
            {
                Foods[product] += weight;
            }
            
            
        }
    }
}
