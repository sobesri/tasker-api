using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskerApi.Models;

namespace TaskerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "New", "To-Do", "In-progress", "Completed", "Removed"
        };

        // Temporary placeholder
        [HttpGet(Name = "GetTasks")]
        public IEnumerable<UserTask> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new UserTask
            {
                Description = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
