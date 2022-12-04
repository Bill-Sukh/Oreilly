using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oreilly.Models
{
    public class CEO : Person
    {
        public new int Id { get; set; }
        public new string? Name { get; set; }
        public new string? Position { get; set; }

        public CEO(int id, string name, string position) : base(id, name, position)
        {
            this.Id = id;
            this.Name = name;
            this.Position = position;
        }
    }
}
