using System;
using System.Data.Entity;

namespace TaskerApi.Models
{
    public class TaskerDbContext : DbContext
    {
        public DbSet<UserTask> Tasks { get; set; }
    }
}
