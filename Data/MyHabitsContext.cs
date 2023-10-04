using Microsoft.EntityFrameworkCore;

namespace MyHabits.Data;

public class MyHabitsContext : DbContext
{
    public MyHabitsContext(DbContextOptions<MyHabitsContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<MyHabits.Models.Habit> Habit { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
