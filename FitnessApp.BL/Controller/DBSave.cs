using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller
{
    public class DatabaseSaver : IDataSave
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessDataGateWay())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(T item) where T : class
        {
            using (var db = new FitnessDataGateWay())
            {
                if (item is User || item is Eating)
                {
                    db.Set<T>().AddOrUpdate(item);
                } else
                {
                    db.Set<T>().Add(item);
                }
                db.SaveChanges();
            }
        }
    }
}
