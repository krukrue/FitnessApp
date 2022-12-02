using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        public IDataSave saver = new SarializeData();

        public void Save(string fileName, object item)
        {
            saver.save(fileName, item);
        }

        public T Load<T>(string fileName)
        {
            return saver.Load<T>(fileName);
        }
    }
}
