using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public class Nurse : Employee
    {

        public Nurse(string firstName, string lastName, long peselNumber, string login, string password)
            : base(firstName, lastName, peselNumber, login, password)
        {
            //Schedule = new Schedule();
        }

        public Nurse(Employee e) : base(e) { }

        public override bool CheckLoginAndPassword(string login, string password)
        {
            return base.CheckLoginAndPassword(login, password);
        }

        public override bool ChangePassword(string oldPassword, string newPassword)
        {
            return base.ChangePassword(oldPassword, newPassword);
        }
    }
}
