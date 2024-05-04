using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Trello_board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _taskContext;

        public TasksController(TaskContext taskContext)
        {
            _taskContext = taskContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trello_board.Models.Task>>> GetTasks()
        {
            if (_taskContext.Tasks == null)
            {
                return NotFound();
            }
            return await _taskContext.Tasks.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Trello_board.Models.Task>> GetTask(int Id)
        {
            var task = await _taskContext.Tasks.FindAsync(Id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult<Trello_board.Models.Task>> PostTask(Trello_board.Models.Task task)
        {
            _taskContext.Tasks.Add(task);
            await _taskContext.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { Id = task.Id }, task);
        }

        private bool TaskExists(long Id)
        {
            return (_taskContext.Tasks.Any(e => e.Id == Id));
        }

        [HttpPut]

        public async Task<IActionResult> PutTask(int Id, Trello_board.Models.Task task)
        {
            
            if (Id != task.Id)
            {
                return BadRequest();
            }

            _taskContext.Entry(task).State = EntityState.Modified;

            try
            {
                await _taskContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTask(int Id)
        {
            var task = await _taskContext.Tasks.FindAsync(Id);
            if (task == null)
            {
                return NotFound();
            }

            _taskContext.Tasks.Remove(task);
            await _taskContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
