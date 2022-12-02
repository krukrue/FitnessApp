using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public class SarializeData : IDataSave
    {


        public T Load<T>(string FileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public void save(string FileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
