using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public abstract class Employee
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public long PeselNumber { get;  private set; }
        public string Login { get;  private set; }
        private string Password { get; set; }
        public string Specialization { get; private set; }
        public Schedule Schedule { get; private set; }

        protected Employee(string firstName, string lastName, long peselNumber, string login, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            if (IsPeselCorrect(peselNumber))
                this.PeselNumber = peselNumber;
            this.Login = login;
            this.Password = password;
            this.Specialization = this.GetType().Name;
            this.Schedule = new Schedule();
        }

        protected Employee(Employee e)
        {
            this.FirstName = e.FirstName;
            this.LastName = e.LastName;
            this.PeselNumber = e.PeselNumber;
            this.Login = e.Login;
            this.Password = e.Password;
            this.Specialization = e.GetType().Name;
            this.Schedule = new Schedule();
        }

        virtual public bool CheckLoginAndPassword(string login, string password)
        {
            if (this.Login.ToLower() == login.ToLower() && this.Password == password)
                return true;
            else return false;
        }

        public void EditDetails( string firstName, string lastName, long peselNumber, string login, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            if(IsPeselCorrect(peselNumber))
                this.PeselNumber = peselNumber;
            this.Login = login;
            this.Password = password;
        }

        virtual public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (this.Password == oldPassword)
            {
                this.Password = newPassword;
                return true;
            }
            else
                throw new WrongPasswordException("Your old password is incorrect. Try again");
        }

        private bool IsPeselCorrect(long peselNumber)
        {
            if (peselNumber.ToString().Length != 11 || peselNumber <= 0)
            {
                throw new WrongPeselException();
            }
            return true;
        }

        public static bool operator== (Employee a, Employee b)
        {
            
            /*if (a.FirstName == b.FirstName && a.LastName == b.LastName && a.PeselNumber == b.PeselNumber
                && a.Login == b.Login && a.Password == b.Password)*/
            if (ReferenceEquals(a,b))
                return true;
            else
                return false;
        }

        public static bool operator !=(Employee a, Employee b)
        {
            return !(a == b);
        }
    }
}
