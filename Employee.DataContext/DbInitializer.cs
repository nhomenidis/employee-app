using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.DataContext
{
    public class DbInitializer
    {
        public static void Initialize(EmployeeDataContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
