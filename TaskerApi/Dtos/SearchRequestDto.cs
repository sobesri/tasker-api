namespace TaskerApi.Dtos
{
    public class SearchRequestDto
    {
        public int? Limit { get; set; }
        public string? SearchTerm { get; set; }
        public int? Offset { get; set; }
    }
}
