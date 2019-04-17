using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public class Hospital
    {
        public List<Employee> ListOfEmployees { get; set; }

        public Hospital() { ListOfEmployees = new List<Employee>(); }
    }
}
