using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy _strategy)
        {
            ContextStrategy = _strategy;
        }
        public List<PersonComponent> ExecuteAlgorithm(EmployeeModel element)
        {
            List<PersonComponent> result = ContextStrategy.DoAlgorithm(element); ;
            return result;
        }

    }
}
