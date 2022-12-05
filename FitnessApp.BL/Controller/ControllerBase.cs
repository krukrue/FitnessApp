using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSave db = new DatabaseSaver();

        protected void Save<T>(T item) where T : class
        {
            db.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return db.Load<T>();
        }

    }
}
