﻿using System;
using System.Collections.Generic;
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



        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Cannot be empty.");
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                food.EatingID = Eating.ID;
                Save(product);
                Save(food);

            }
            else
            {
                Eating.Add(product, weight);
                Save(product);

            }
        }

        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }





    }
}
