using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; } 

        public Person(int id, string name, string position)
        {
            this.Id = id;
            this.Name = name;
            this.Position = position;
        }

    }
}
