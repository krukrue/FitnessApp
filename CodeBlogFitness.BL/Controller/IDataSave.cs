using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller
{
    public interface IDataSave
    {
        void save(string FileName, object item);
        T Load<T>(string FileName);
    }
}
