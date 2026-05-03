namespace Skoob.UseCases.CreateBook;

public record CreateBookPayload
{
    public string Title { get; init; }
    public int NumberOfPages { get; init; }
    public string Author { get; init; }
    public string? About { get; init; }
    public int Year { get; init; }
    public string? ImageUrl { get; init; }
}