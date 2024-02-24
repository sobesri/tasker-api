using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<TaskerApi.Models.UserTask> Task { get; set; } = default!;
    }
}
