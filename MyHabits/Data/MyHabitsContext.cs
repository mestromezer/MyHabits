using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyHabits.Models;

namespace MyHabits.Data
{
    public class MyHabitsContext : DbContext
    {
        public MyHabitsContext(DbContextOptions<MyHabitsContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<MyHabits.Models.Habit> Habit { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
