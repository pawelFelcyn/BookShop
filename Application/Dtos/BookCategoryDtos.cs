namespace Application.Dtos
{
    public record CreateBookCategoryDto(string Name);
    public record UpdateBookCategoryDto(string Name);
    public record BookCategoryDto
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}
