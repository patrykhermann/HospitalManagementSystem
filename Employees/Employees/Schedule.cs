using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public class Schedule
    {
        public List<DateTime> ListOfDays { get; private set; }

        public Schedule() { ListOfDays = new List<DateTime>(); }

        public bool AddDate(DateTime dt)
        {
            if(!CanAdd(dt))
            { return false; }
            else
            {
                ListOfDays.Add(dt);
                ListOfDays.Sort();
                return true;
            }
        }

        public bool CanAdd(DateTime dt)
        {
            DateTime dayBefore = dt.AddDays(-1);
            DateTime dayAfter = dt.AddDays(1);
            if (ListOfDays.Contains(dt) || ListOfDays.Contains(dayBefore) || ListOfDays.Contains(dayAfter) || CheckSurgeriesInThisMonth(dt) || CheckSurgeriesInNextMonth(dt) || dt <= DateTime.Now)
                return false;
            else return true;
        }
        

        private bool CheckSurgeriesInThisMonth(DateTime dt)
        {
            int i = 1;

            foreach(DateTime m in ListOfDays)
            {
                if (m.Month == dt.Month) i++;
            }

            if (i <= 10) return false;
            else return true;
        }

        private bool CheckSurgeriesInNextMonth(DateTime dt)
        {
            int i = 1;

            foreach (DateTime m in ListOfDays)
            {
                if (m.Month == dt.AddMonths(1).Month) i++;
            }

            if (i <= 10) return false;
            else throw new TooMuchDutiedInTheMonthException("You can't have more than 10 duties in the month.");
        }
    }
}
