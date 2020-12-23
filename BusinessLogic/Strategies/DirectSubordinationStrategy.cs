﻿using System.Collections.Generic;

namespace BusinessLogic
{
    public class DirectSubordinationStrategy : IStrategy
    {
        private PersonComponent element;
        private List<PersonComponent> sortedList = new List<PersonComponent>();

        public DirectSubordinationStrategy(EmployeeModel element)
        {
            this.element = element;
        }

        public List<PersonComponent> DisplayEmployees(EmployeeModel element)
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