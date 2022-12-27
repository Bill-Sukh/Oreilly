using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly_ChapterTwo
{
    public class FieldsAndProperties
    {
        private int _id;
        private string? _name;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value == 0 ? 1 : value;
            }
        }

        public string? Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value == null ? "John Doe" : value;
            }
        }

        // This syntax creates private field automatically. It looks different, but it is exactly same as two fields above. 
        // Only difference here is that private field declaration is implicit. And you interact with the field through Property name. 
        public string? Address { get; set; }
        public string? City { get; private set; }

        public FieldsAndProperties()
        {
            City = "Mandala";
        }

        public void GetCurrentCity()
        {
            City = "Las Vegas";
        }
    }
}
