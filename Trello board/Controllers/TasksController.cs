using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Trello_board.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly BoardContext _boardContext;

        public TasksController(BoardContext boardContext)
        {
            _boardContext = boardContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trello_board.Models.Task>>> GetTasks()
        {
            if (_boardContext.Tasks == null)
            {
                return NotFound();
            }
            return await _boardContext.Tasks.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Trello_board.Models.Task>> GetTask(int Id)
        {
            var task = await _boardContext.Tasks.FindAsync(Id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult<Trello_board.Models.Task>> PostTask(Trello_board.Models.Task task)
        {
            _boardContext.Tasks.Add(task);
            await _boardContext.SaveChangesAsync();

            return CreatedAtAction("GetTask", new { Id = task.Id }, task);
        }

        private bool TaskExists(long Id)
        {
            return (_boardContext.Tasks.Any(e => e.Id == Id));
        }

        [HttpPut]

        public async Task<IActionResult> PutTask(int Id, Trello_board.Models.Task task)
        {

            if (Id != task.Id)
            {
                return BadRequest();
            }

            _boardContext.Entry(task).State = EntityState.Modified;

            try
            {
                await _boardContext.SaveChangesAsync();
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
            var task = await _boardContext.Tasks.FindAsync(Id);
            if (task == null)
            {
                return NotFound();
            }

            _boardContext.Tasks.Remove(task);
            await _boardContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
