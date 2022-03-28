using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private ITodoHome todoHome;

    public TodosController(ITodoHome todoHome)
    {
        this.todoHome = todoHome;
    }
    
    //get all todo
    [HttpGet]
    public async Task<ActionResult<ICollection<Todo>>> GetAll(
        [FromQuery] int? OwnerId,
        [FromQuery] bool? IsCompleted
        )
    {
        try
        {
            ICollection<Todo> todos = await todoHome.GetAsync();
            if (IsCompleted != null)
            {
                 return Ok(todos.Where(todo => todo.IsCompleted == IsCompleted));
            }

            if (OwnerId != null)
            {
                return Ok(todos.Where(todo => todo.OwnerId == OwnerId));
            }
            else return Ok(todos);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    //get all todo
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<ICollection<Todo>>> GetByID([FromRoute] int id)
    {
        try
        {
            Todo todo = await todoHome.GetById(id);
            return Ok(todo);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    //get all todo
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<ICollection<Todo>>> DeleteByID([FromRoute] int id)
    {
        try
        {
            await todoHome.DeleteAsync(id);
            return Ok("Element deleted: " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    //update
    [HttpPatch]
    public async Task<ActionResult> Update([FromBody] Todo todo)
    {
        try
        {
            await todoHome.UpdateAsync(todo);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }  
    }
    
    //create a TODO
    [HttpPost]
    public async Task<ActionResult<Todo>> AddTodo([FromBody] Todo todo)
    {
        try
        {
            Todo added = await todoHome.AddAsync(todo);
            return Created($"/todos/{added.Id}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
}
