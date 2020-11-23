using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IStrategy
    {
        public List<PersonComponent> DoAlgorithm(List<PersonComponent> list);
    }
}
