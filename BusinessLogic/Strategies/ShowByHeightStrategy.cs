using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic
{
    public class ShowByHeightStrategy:IStrategy
    {
        private PersonComponent element;
        private List<PersonComponent> sortedList = new List<PersonComponent>();
        public ShowByHeightStrategy(EmployeeModel element) 
        {
            this.element = element;
        }
        public List<PersonComponent> DoAlgorithm(EmployeeModel element) 
        {
            Queue<PersonComponent> queue = new Queue<PersonComponent>();
            queue.Enqueue(element);
            while (queue.Count > 0)
            {
                PersonComponent current = queue.Dequeue();
                sortedList.Add(current);

                foreach (PersonComponent child in current.Subordinates)
                    queue.Enqueue(child);
            }
            return sortedList;
        }
        
    }
}
