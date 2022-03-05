using Domain.Contracts;
using Domain.Models;

namespace FileData.DataAccess;

public class TodoFileDAO : ITodoHome
{

    private FileContext _fileContext;

    public TodoFileDAO(FileContext fileContext)
    {
        _fileContext = fileContext;
    }
    
    public async Task<ICollection<Todo>> GetAsync()
    {
        ICollection<Todo> todos = _fileContext.Todos;
        return todos;
    }

    public async Task<Todo> GetById(int id)
    {
        return _fileContext.Todos.First(t => t.Id == id);
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        int largestId = _fileContext.Todos.Max(t => t.Id);
        int nextId = largestId + 1;
        todo.Id = nextId;
        _fileContext.Todos.Add(todo);
        _fileContext.SaveChanges();
        return todo;
    }

    public async Task DeleteAsync(int id)
    {
        Todo toDelete = _fileContext.Todos.First(t => t.Id == id);
        _fileContext.Todos.Remove(toDelete);
        _fileContext.SaveChanges();
    }

    public async Task UpdateAsync(Todo todo)
    {
        Todo toUpdate = _fileContext.Todos.First(t => t.Id == todo.Id);
        toUpdate.IsCompleted = todo.IsCompleted;
        toUpdate.OwnerId = todo.OwnerId;
        toUpdate.Title = todo.Title;
        _fileContext.SaveChanges();
        
    }
}