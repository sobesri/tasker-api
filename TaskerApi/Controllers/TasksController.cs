using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;
using TaskerApi.Data;
using TaskerApi.Dtos;
using TaskerApi.Models;

namespace TaskerApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "New", "To-Do", "In-progress", "Completed", "Removed"
        };

        private readonly TaskerApiContext _context;

        public TasksController(TaskerApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<UserTask> Get([FromQuery] SearchRequestDto request)
        {
            var searchTerm = request.SearchTerm?.Trim().ToLower() ?? "";
            var tasksList = _context.Tasks
                .Where(t => t.Deleted == 0)
                .Where(t => (
                    string.IsNullOrEmpty(request.SearchTerm) || 
                        t.Title.ToLower().Contains(searchTerm) || t.Description.ToLower().Contains(searchTerm)
                ))
                .Skip(request.Offset ?? 0)
                .Take(request.Limit ?? 10)
                .ToList();
            return tasksList;
        }

        [HttpGet("{id}")]
        public UserTask GetById([FromRoute] int id)
        {
            var userTask = _context.Tasks
                .Where(t => t.Id == id)
                .FirstOrDefault();

            return userTask;
        }

        [HttpPut("{id}")]
        public int UpdateTask([FromRoute] int id, [FromBody] UserTask userTask)
        {
            if (string.IsNullOrEmpty(userTask.Title))
            {
                throw new Exception("Task title cannot be empty");
            }

            if (string.IsNullOrEmpty(userTask.Description))
            {
                throw new Exception("Task description cannot be empty");
            }

            userTask.Id = id;
            var updatedTask = _context.Tasks.Update(userTask);
            _context.SaveChanges();
            return updatedTask?.Entity?.Id ?? 0;
        }

        [HttpPost]
        public int Create([FromBody] UserTask userTask)
        {
            if (string.IsNullOrEmpty(userTask.Title))
            {
                throw new Exception("Task title cannot be empty");
            }

            if (string.IsNullOrEmpty(userTask.Description))
            {
                throw new Exception("Task description cannot be empty");
            }

            var createdTask = _context.Tasks.Add(userTask);
            _context.SaveChanges();
            return createdTask?.Entity?.Id ?? 0;
        }

        [HttpDelete("{id}")]
        public int Delete([FromRoute] int id)
        {
            var userTask = _context.Tasks
                .Where(t => t.Id == id)
                .First();

            var updatedTask = _context.Tasks.Remove(userTask);
            _context.SaveChanges();

            return id;
        }
    }
}
