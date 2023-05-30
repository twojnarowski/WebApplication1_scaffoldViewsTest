using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1_scaffoldViewsTest.Models;

namespace WebApplication1_scaffoldViewsTest.Data
{
    public class WebApplication1_scaffoldViewsTestContext : DbContext
    {
        public WebApplication1_scaffoldViewsTestContext (DbContextOptions<WebApplication1_scaffoldViewsTestContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1_scaffoldViewsTest.Models.TestClass> TestClass { get; set; } = default!;
    }
}
