using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oreilly.Models;

namespace Oreilly
{
    public class Data
    {
        public List<Person> People { get; set; }

        public Data(int numberOfPeople)
        {
            People = PopulatePeople(numberOfPeople);
        }

        // Populates list with random types of person. 
        public List<Person> PopulatePeople(int numberOfPeople)
        {
            var people = new List<Person>();
            for (int x = 0; x < numberOfPeople; x++)
            {
                people.Add(CreateRandomPerson(x) ?? new Person(0, "null", "null"));
            }

            return people;
        }

        /// <summary>
        /// Gets one random person of types: Employee or CEO
        /// </summary>
        /// <returns>Person</returns>
        public static Person CreateRandomPerson(int id)
        {
            Random random = new();

            switch (random.Next(0, 2))
            {
                case 0:
                    return new Employee(id, "Jack", "Employee");
                case 1:
                    return new CEO(id, "Bobb", "CEO");
            }

            return null;
        }

        public (int, string?) GetPersonById(int id)
        {
            return (People.ElementAt(id).Id, People.ElementAt(id).Name);
        }
        
        public (int, string) SwitchExpressions()
        {
            Person person = new(200, "", "");
            (int, string?, string?) Billy = (person.Id, person.Name, person.Position);

            return Billy switch
            {
                (int Id, string Name, string Position) when Id == 200 => (200, "Billy the Hillbilly"),
                (int Id, string Name, string Position) when Id == 201 => (201, "John Maguire"),
                (int Id, string Name, string Position) when Id == 202 => (202,"Seredwyn the Serene"),
                _ => (0, "Unknown") // This case is here to cover all possible cases. If none of the others above are matching, then consider it unknown. This will match anything.
            };
        }
    }
}
