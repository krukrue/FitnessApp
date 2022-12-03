using FitnessApp.BL.Model;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace FitnessApp.BL.Controller
{
    public class FitnessDataGateWay : DbContext
    {
        public FitnessDataGateWay( ) : base("DbConnection")
        { 
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eating { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
