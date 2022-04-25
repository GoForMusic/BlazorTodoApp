using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcData;

public class TodoContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = D:\Unity\TODO\EfcData\Todo.db");
    }
    
    public void Seed()
    {
        if (Todos.Any()) return;

        Todo[] ts =
        {
            new Todo(1, "Dishes"),
            new Todo(1, "Walk the dog"),
            new Todo(2, "Do DNP homework"),
            new Todo(3, "Eat breakfast"),
            new Todo(4, "Mow lawn"),
        };
        Todos.AddRange(ts);
        SaveChanges();
    }
    
}