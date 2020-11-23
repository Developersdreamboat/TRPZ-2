using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class DirectSubordinationStrategy:IStrategy
    {
        public List<PersonComponent> DoAlgorithm(List<PersonComponent> list)
        {
            return list;
        }
    }
}
