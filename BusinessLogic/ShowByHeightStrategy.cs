using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BusinessLogic
{
    public class ShowByHeightStrategy:IStrategy
    {
        public List<PersonComponent> DoAlgorithm(List<PersonComponent> list)
        {
            List<PersonComponent> result = list.OrderBy(e=>(int)(e.Position)).ToList();
            result.Reverse();
            return result;
        }
        
    }
}
