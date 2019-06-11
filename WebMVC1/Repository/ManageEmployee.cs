using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC1.Models;

namespace WebMVC1.Repository
{
    public class ManageEmployee : IManagerEmployee
    {
        private readonly EmployeeContext _context;

        public ManageEmployee(EmployeeContext context)
        {
            _context = context;
        }
        public List<EmployeeViewModel> GetEmployeeList()
        {
            var empList = (from e in _context.Employees select new EmployeeViewModel() {Id=e.Id, Name = e.Name, Address = e.Address, Phone = e.Phone }).ToList<EmployeeViewModel>();
            return empList;
        }

        public async Task SaveEmployee(EmployeeViewModel Emp)
        {
            var employee = new Employee()
            {
                Name = Emp.Name,
                Address = Emp.Address,
                Phone = Emp.Phone
            };
            _context.Add(employee);
           await _context.SaveChangesAsync();
         
        }
    }
}
