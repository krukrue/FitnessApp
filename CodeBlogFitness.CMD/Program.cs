using CodeBlogFitness.BL;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fitness Aplication v.0.01");
            Console.WriteLine("Set user name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var EC = new EatingController(userController.CurrentUser);
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
            Console.WriteLine("E - Set eating");
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
                    break;
                }
            }




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
