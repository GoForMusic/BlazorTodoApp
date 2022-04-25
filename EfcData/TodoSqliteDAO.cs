using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcData;

public class TodoSqliteDAO :ITodoHome
{
    private readonly TodoContext context;

    public TodoSqliteDAO(TodoContext todoContext)
    {
        this.context = todoContext;
    }
    
    public async Task<ICollection<Todo>> GetAsync()
    {
        ICollection<Todo> todos = await context.Todos.ToListAsync();
        return todos;
    }

    public async Task<Todo> GetById(int id)
    {
        return await context.Todos.FindAsync(id);
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        EntityEntry<Todo> added = await context.AddAsync(todo);
        await context.SaveChangesAsync();
        return added.Entity;
    }

    public async Task DeleteAsync(int id)
    {
        Todo? existing = await context.Todos.FindAsync(id);
        if (existing is null)
        {
            throw new Exception($"Could not find Todo with id {id}. Nothing was deleted");
        }

        context.Todos.Remove(existing);
        await context.SaveChangesAsync();
    }

    public Task UpdateAsync(Todo todo)
    {
        context.Todos.Update(todo);
        return context.SaveChangesAsync();
    }
}