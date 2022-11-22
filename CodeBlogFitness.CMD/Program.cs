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
        }
    }
}
