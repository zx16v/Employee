using employment;
using System.Collections.Generic;
using System.Web.Mvc;
using Dal;
using Employees.Models;

namespace Employees.Controllers
{
    public class HomeController : Controller
    {

       // GET: Employees
       public ActionResult Employees()
       {
            var employees = new List<object>();
            using (EmployeesLogic logic = new EmployeesLogic())
            {
                IEnumerable<GETEmployeeList_Result> AllEmployees = logic.GetAllEmployees();
                foreach (GETEmployeeList_Result item in AllEmployees)
                    employees.Add(new { Id = item.Id, name = item.name });
            }
                return Json(employees, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            using (EmployeesLogic logic  = new EmployeesLogic())
            {
                List<Dal.GETEmployeeList_Result> AllEmployees = logic.GetAllEmployees();
                return  Json(AllEmployees, JsonRequestBehavior.AllowGet);
            }
        }
     // GET: EmployeeRoles
       public ActionResult EmployeeRoles(int EmployeeId)
        {
            var employeeRoles = new List<object>();
            using (EmployeesLogic logic = new EmployeesLogic())
            {
                IEnumerable<GetEmployeeRoles_Result> EmployeeRoles = logic.GetEmployeeRoles(EmployeeId);
                foreach (GetEmployeeRoles_Result item in EmployeeRoles)
                    employeeRoles.Add(new { roleId = item.RolesId, description = item.RolesName });
                return Json(employeeRoles, JsonRequestBehavior.AllowGet);
            }
        }

        /// POST : Add Attendance
        [HttpPost]
        public ActionResult ClockIn (EmployeeViewModel  attand)
        {
            if (ModelState.IsValid)
            {
                Attenance attendance = new Attenance();
                attendance.EmployeeId = attand.employeeId;
                attendance.RoleId = attand.roleId;
                attendance.actionTime = System.DateTime.Now;
                using (EmployeesLogic logic = new EmployeesLogic())
                    logic.AddAttenance(attendance);
                string message = string.Format("Successfully Added  {0} Attandance(s).",  attand.employeeId.ToString());
                return Json(new { Success = true, Message = message });
            }
            else
            {
                string message = string.Format("Errore, could not add employee   {0} Attandance(s).", attand.employeeId.ToString());
                return Json(new { Success = false, Message = message });
            }

           
        }


        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}