using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public abstract class Doctor : Employee
    {
        public string PWZNumber { get; private set; }


        public Doctor(string firstName, string lastName, long peselNumber, string login, string password)
            : base(firstName, lastName, peselNumber, login, password)
        {
            this.PWZNumber = GeneratePWZNumber();
            //Schedule = new Schedule();
        }

        public Doctor(Employee e) : base(e) { }

        private string GeneratePWZNumber()
        {
            Random r = new Random();
            string s = "";
            for(int i=1; i<9; i++)
            {
                s += (r.Next(0, 9)).ToString();
            }

            return s;
        }

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
