using System.Text.Json;
using Domain.Contracts;
using Domain.Models;

namespace HttpServices;

public class TodoHttpService : ITodoHome
{
    public async Task<ICollection<Todo>> GetAsync()
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Get,"/todos");
        
            ICollection<Todo> todos = JsonSerializer.Deserialize<ICollection<Todo>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return todos;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Todo> GetById(int id)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Get,$"/todos/{id}");
        
            Todo todo = JsonSerializer.Deserialize<Todo>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return todo;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Todo> AddAsync(Todo todo)
    {
        try
        {
            string content = await ServerAPI.getContent(Methods.Post,"/todos", todo);
        
            Todo returned = JsonSerializer.Deserialize<Todo>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
            return returned;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            string content =  await ServerAPI.getContent(Methods.Delete,$"/todos/{id}");
            
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task UpdateAsync(Todo todo)
    {
        try
        {
            string content =  await ServerAPI.getContent(Methods.Patch,"/todos", todo);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}