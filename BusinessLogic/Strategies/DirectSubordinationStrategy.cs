using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic
{
    public class DirectSubordinationStrategy:IStrategy
    {
        private PersonComponent element;
        private List<PersonComponent> sortedList = new List<PersonComponent>();

        public DirectSubordinationStrategy(PersonComponent element)
        {
            this.element = element;
        }
        public List<PersonComponent> DoAlgorithm(PersonComponent element)
        {
            Stack<PersonComponent> stack = new Stack<PersonComponent>();
            stack.Push(element);
            while (stack.Count > 0)
            {
                PersonComponent current = stack.Pop();
                sortedList.Add(current);

                foreach (PersonComponent child in current.Subordinates)
                    stack.Push(child);
            }
            return sortedList;
        }
    }
}
