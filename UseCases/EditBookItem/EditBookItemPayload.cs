using Skoob.Enums;

namespace Skoob.UseCases.EditBookItem;

public record EditBookItemPayload
(
    Guid BookItemId,
    float? Rating,
    Label? BookLabel,
    bool? Favorite
);