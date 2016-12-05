using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employment
{
    public abstract class BaseLogic : IDisposable
    {
        protected readonly EmployeeEntities DB = new EmployeeEntities();
     
        public void Dispose()
        {
            DB.Dispose();
        }


    }
}
