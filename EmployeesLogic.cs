using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace employment
{
   public  class EmployeesLogic:BaseLogic
    {
        public List<GETEmployeeList_Result> GetAllEmployees()
        {

            return DB.GETEmployeeList().ToList();
        }

        public List<GetEmployeeRoles_Result> GetEmployeeRoles(int EmployeeId)
        {
            return DB.GetEmployeeRoles(EmployeeId).ToList();
        }

        public void AddAttenance(Attenance attenance)
        {
            DB.Attenances.Add(attenance);
            DB.SaveChanges();
        }

    }
}
