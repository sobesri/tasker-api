namespace TaskerApi.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Deleted { get; set; }
        public DateTime DueDate { get; set; }
    }
}
