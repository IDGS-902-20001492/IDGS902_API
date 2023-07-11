using IDGS902_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace IDGS902_API.Context
{
    public class AppDBContext: DbContext
    {
        public  AppDBContext(DbContextOptions<AppDBContext> options): base(options) { }

        public DbSet<alumnos> alumnos { get; set; }
    }
}
