using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public abstract class PersonComponent
    {
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
        public override bool Equals(Object obj)
        {
            if (obj is PersonComponent)
            {
                var that = obj as PersonComponent;
                return this.Surname == that.Surname && this.Name == that.Name && this.Salary == that.Salary && this.Position == that.Position;
            }

            return false;
        }
        public override string ToString()
        {
            return string.Concat("Surname:", Surname, ", Name: ", Name, ", Salary: ", Salary, ", Position: ", Position);
        }
    }
}
