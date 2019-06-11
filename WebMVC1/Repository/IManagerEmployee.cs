using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC1.Models;

namespace WebMVC1.Repository
{
    public interface IManagerEmployee
    {
         Task SaveEmployee(EmployeeViewModel Emp);
         List<EmployeeViewModel> GetEmployeeList();
    }
}
