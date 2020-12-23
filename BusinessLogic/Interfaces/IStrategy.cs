using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IStrategy
    {
        List<PersonComponent> DisplayEmployees(EmployeeModel element);
    }
}