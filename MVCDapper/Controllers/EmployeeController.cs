using Dapper;
using Microsoft.AspNetCore.Mvc;
using MVCDapper.Models;
using System.Linq;
using System.Web;


namespace MVCDapper.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
           return View(MVCDapper.Models.Dapper.ReturnList<EmployeeModel>("EmployeeViewAll"));

        }

        [HttpGet]
      
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@EmployeeID", id);
                return View(MVCDapper.Models.Dapper.ReturnList<EmployeeModel>("EmployeeViewByID", param).FirstOrDefault<EmployeeModel>());

            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModel employeeModel)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", employeeModel.EmployeeId);
            param.Add("@Name", employeeModel.Name);
            
            param.Add("@Age", employeeModel.Age);
            param.Add("@Salary", employeeModel.Salary);
            MVCDapper.Models.Dapper.ExecuteWithoutReturn("EmployeeAddOrEdit", param);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeID", id);
            MVCDapper.Models.Dapper.ExecuteWithoutReturn("EmployeeDeleteByID", param);
            return RedirectToAction("Index");
        }
    }
}
