using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SchoolProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.DataAccess
{
    public class SchoolProjectDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<ClassNumb> ClassNumbs { get; set; }

        public SchoolProjectDBContext(DbContextOptions<SchoolProjectDBContext> options) : base(options)
        {

        }
        public class AppDBContentFactory : IDesignTimeDbContextFactory<SchoolProjectDBContext>
        {
            public SchoolProjectDBContext CreateDbContext(string[] args)
            {
                var optionBuilder = new DbContextOptionsBuilder<SchoolProjectDBContext>();
                optionBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SchoolDB;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("SchoolProject.DataAccess"));
                return new SchoolProjectDBContext(optionBuilder.Options);
            }
        }
    }

}
