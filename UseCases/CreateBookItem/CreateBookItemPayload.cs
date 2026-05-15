using Skoob.Enums;
using Skoob.Models;

namespace Skoob.UseCases.CreateBookItem;

public record CreateBookItemPayload(
    Guid ProfileId,
    Guid BookId,
    Label BookLabel
);