using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public interface IShowStructureService
    {
        public Context ChoosenStrategy { get; set; }
        public List<PersonComponent> chooseAlgorithm(int option, PersonComponent choosenNode);
    }
}
