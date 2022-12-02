using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]

    public class Eating
    {
        public int ID { get; set; }

        public DateTime Moment { get; }
        public Dictionary <Food, double>? Foods { get; set; }

        public User? User { get; set; }
        public Eating(User user) { 
            User = user ?? throw new ArgumentNullException("User can't be empty");
            Moment = DateTime.Now;
            Foods = new Dictionary <Food, double>();
        }

        public void Add(Food food, double weight) {

            var product = Foods.Keys.FirstOrDefault(x => x.Name.Equals(food.Name));
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
