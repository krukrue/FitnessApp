using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.BL.Model;

namespace FitnessApp.BL.Controller 
{
    [Serializable]
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; } 

        public List <Eating> Eatings { get; } = new List<Eating>();



        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Cannot be empty.");
            Foods = GetAllFoods();
            Eatings = GetAllEating();
            Eating = Eatings.FirstOrDefault(x => x.UserID == user.ID) ?? new Eating(user.ID);
            Eating.UserID = user.ID;

        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Console.WriteLine(Eating.ID);
                food.EatingID = Eating.ID;
                Save(food);
                Save(Eating);

            }
            else
            {
                Eating.Add(product, weight);
                Save(Eating);

            }
        }

        private List <Eating> GetAllEating()
        {
            return Load<Eating>();
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        public void showAllEatings()
        {
            int count = 0;
            double coloriesCount = 0;
            foreach (var a in Foods)
            {
                if (Eating.ID == a.EatingID && Eating.UserID == user.ID)
                {
                    count++;
                    coloriesCount += a.Calorie;
                    Console.WriteLine($"Food: {a.Name} - Time of eating: {Eating.Moment.ToShortDateString()}") ;
                }
            }
            Console.WriteLine($"{Math.Round(coloriesCount)} - calories");

            if (count == 0)
            {
                Console.WriteLine("You haven't any eatings");
            }
        }



    }
}
