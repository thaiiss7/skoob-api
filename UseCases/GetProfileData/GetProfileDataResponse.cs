using Skoob.Models;

namespace Skoob.UseCases.GetProfileData;

public record ReadingLogData(
    string Username,
    DateOnly Date,
    int PagesRead,
    string BookTitle
);

public record GetProfileDataResponse(
    string Username,
    string? Bio,
    TBR? YearTBR,
    IEnumerable<ReadingLogData> ReadingLogs
);