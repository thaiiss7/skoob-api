namespace Skoob.UseCases.GetBookData;

public record GetBookDataResponse(
    string Title,
    string Author,
    int NumberOfPages,
    string? About,
    float? Rating,
    int Year,
    string? ImageUrl,
    int? NumberOfFavorites,
    int? NumberOfRead,
    int? NumberOfReading,
    int? NumberOfRereading,
    int? NumberOfAbandoned,
    int? NumberOfWantToRead
);