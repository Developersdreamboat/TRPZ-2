using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class ShowStructureService:IShowStructureService
    {   
        public Context ChoosenStrategy { get; set; }
        public ShowStructureService( Context choosenStrategy) 
        {
            ChoosenStrategy = choosenStrategy;
        }
        public List<PersonComponent> chooseAlgorithm(int option, PersonComponent choosenNode) 
        {
            if (option == 1)
            {
                ChoosenStrategy = new Context(new ShowByHeightStrategy(choosenNode));
            }
            if (option == 2)
            {
                ChoosenStrategy = new Context(new DirectSubordinationStrategy(choosenNode));
            }
            List<PersonComponent> list = ChoosenStrategy.ExecuteAlgorithm(choosenNode);
            return list;
        }
    }
}
