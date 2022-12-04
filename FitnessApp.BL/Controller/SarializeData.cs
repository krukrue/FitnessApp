using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller
{
    public class SarializeData : IDataSave
    {


        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();
            var FileName = typeof(T)+".dat";

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(T item) where T : class
        {
            var formatter = new BinaryFormatter();
            var FileName = typeof(T)+".dat";


            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
