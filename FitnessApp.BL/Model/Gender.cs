using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Gender
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public Gender (string NAME)
        {

            if (NAME.ToUpper() != "M" && NAME.ToUpper() != "W"){
                throw new ArgumentNullException("Gender can be M or F");
            }
            Name = NAME;

        }
        public Gender() { }
        public override string ToString()
        {
            return Name;
        }
    }
}
