using CodeBlogFitness.BL;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System.Data;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            UserTableDataGateway ut = new();
            var result = ut.Load();
            var customers = new List<User>();
            Console.WriteLine("Here");
            foreach (DataRow row in result.Rows)
            {
                customers.Add(new User(row["Name"].ToString() ?? "", new Gender(row["Gender"].ToString()), DateTime.Parse(row["BirthDay"].ToString()),
                    Convert.ToDouble(row["Weight"]), Convert.ToInt32(row["Height"])));
                Console.WriteLine(customers[0].Name);
            }
            Console.WriteLine("Fitness Aplication v.0.01");
            Console.WriteLine("Set user name");
            var name = Console.ReadLine();




            var userController = new UserController(name);
            var EC = new EatingController(userController.CurrentUser);
            var EXC = new ExerciseController(userController.CurrentUser); 
            if (userController.IsNewUser)
            {
                Console.WriteLine("Set your gender (M or W)");
                var g =  Console.ReadLine();
                Console.WriteLine("Set your birthday (dd.mm.yyyy)");
                var b = Console.ReadLine();
                DateTime.TryParse(b, out DateTime birth);
                Console.WriteLine("Set your weight");
                var W = Console.ReadLine();
                double Weigth = double.Parse(W);
                Console.WriteLine("Set your height");
                var h = Console.ReadLine();
                int height = int.Parse(h);
                userController.setNewUserData(g,birth, Weigth, height);

            }
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E - Add eating");
            Console.WriteLine("R - Add Exercise");
            Console.WriteLine("Esc - Exit");

            while (true)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.E)
                {
                    var food = EnterEating();
                    EC.Add(food.Food, food.Weight);
                    foreach(var item in EC.Eating.Foods)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                    break;
                } else if (key.Key == ConsoleKey.Escape) {
                    Environment.Exit(0);
                } else if (key.Key == ConsoleKey.R)
                {
                    var activity = EnterExercise();
                    EXC.Add(activity.activity, activity.begin, activity.end);
                    foreach (var item in EXC.exerciseList)
                    {
                        Console.WriteLine($"{item.Activity} - {item.Start.ToShortTimeString()} until {item.End.ToShortTimeString()}");
                    }
                }
            }




        }

        private static (DateTime begin, DateTime end, Activity activity)  EnterExercise()
        {
            Console.WriteLine("Set exercise name");
            var name = Console.ReadLine();
            var energy = ParseDouble("energy per minute");

            Console.WriteLine("Set start time");
            DateTime.TryParse(Console.ReadLine(), out DateTime begin);
            Console.WriteLine("Set end time");
            DateTime.TryParse(Console.ReadLine(), out DateTime end);
            Activity activity = new Activity(name, energy);
            return (begin, end, activity);

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Set product name: ");
            var food = Console.ReadLine();

            var weight = ParseDouble("weight of food");

            var calories = ParseDouble("the calories content");
            var prot = ParseDouble("proteins content");
            var fats = ParseDouble("fat content");
            var carbs = ParseDouble("carbrohydrates content");
            var product = new Food(food, calories, prot,fats,carbs);

            return (Food: product, Weight: weight);
        }

        private static double ParseDouble(string Name)
        {
            while (true)
            {
                Console.Write($"Set {Name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                } else
                {
                    Console.WriteLine("Incorrect formate");
                }
            }

        }
    }
}
