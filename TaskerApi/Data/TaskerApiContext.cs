using Microsoft.EntityFrameworkCore;
using TaskerApi.Models;

namespace TaskerApi.Data
{
    public class TaskerApiContext : DbContext
    {
        public TaskerApiContext (DbContextOptions<TaskerApiContext> options)
            : base(options)
        {
        }

        public DbSet<UserTask> Tasks { get; set; } = default!;
    }
}
