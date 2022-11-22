using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Gender
    {
        public string Name { get; set; }
        public Gender (string NAME)
        {

            if (NAME.ToUpper() != "M" && NAME.ToUpper() != "F"){
                throw new ArgumentNullException("Gender can be M or F");
            }
            Name = NAME;

        }

        public override string ToString()
        {
            return Name;
        }
    }
}
