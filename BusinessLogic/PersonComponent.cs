using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public abstract class PersonComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public PersonComponent() { }
        public PersonComponent(string surname, string name, int salary, string position)
        {
            Surname = surname;
            Name = name;
            Salary = salary;
            Position = position;
        }
        public List<PersonComponent> Subordinates { get; set; } = new List<PersonComponent>();
        public abstract void Accept(IVisitor visitor);
        public abstract void Add(PersonComponent subordinate);
        public abstract void Remove(PersonComponent subordinate);
        public override string ToString()
        {
            return string.Concat("ID:", Id, ", Surname:", Surname, ", Name: ", Name, ", Salary: ", Salary, ", Position: ", Position);
        }
    }
}
