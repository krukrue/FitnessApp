using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class User
    {
        public string Name { get; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }

        public int Height { get; set; }
        public bool IsNewUser { get; } = false;

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }
        public User(string NAME, Gender GENDER, DateTime BIRTHDATE, double WEIGHT, int HEIGHT)
        {
            if (string.IsNullOrEmpty(NAME))
            {
                throw new ArgumentNullException("Name is incorrect");

            }
            if (GENDER == null)
            {
                throw new ArgumentNullException("Gender is incorrect");
            }

            if (BIRTHDATE < DateTime.Parse("01.01.1910") || BIRTHDATE > DateTime.Parse("15.11.2020"))
            {
                throw new ArgumentException("BirthDate is incorrect");
            }

            if (WEIGHT < 0)
            {
                throw new ArgumentException("Weight less than 0");

            }

            if (HEIGHT < 20)
            {
                throw new ArgumentException("Height less than 0");

            }

            Name = NAME;
            Gender = GENDER;
            Height = HEIGHT;
            BirthDate = BIRTHDATE;
            Weight = WEIGHT;
        }

        public User(string NAME)
        {
            if (string.IsNullOrEmpty(NAME))
            {
                throw new ArgumentNullException("Name is incorrect");
            }
            this.Name = NAME;
        }

        public override string ToString()
        {
            return $"{Name} - {Age}";
        }

    }
}
