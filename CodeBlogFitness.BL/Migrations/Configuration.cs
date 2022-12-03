namespace FitnessApp.BL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FitnessApp.BL.Controller.FitnessDataGateWay>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "using FitnessApp.BL.Controller.FitnessDataGateWay";

        }

        protected override void Seed(FitnessApp.BL.Controller.FitnessDataGateWay context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
