using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Data
{
    public class MvcEmployeeContext : DbContext
    {
        public MvcEmployeeContext(DbContextOptions<MvcEmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
