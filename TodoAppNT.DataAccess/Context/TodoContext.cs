using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNT.DataAccess.Configurations;
using TodoAppNT.Entities.Concrete;

namespace TodoAppNT.DataAccess.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information);
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
           
        }
        public DbSet<Work> Works { get; set; }
    }
}
