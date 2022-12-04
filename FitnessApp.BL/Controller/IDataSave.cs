using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Controller
{
    public interface IDataSave
    {
        void Save<T>(T item) where T : class;
        List<T> Load<T>() where T : class;
    }
}
