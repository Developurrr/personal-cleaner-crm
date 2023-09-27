using Orderly.Domain.SeedWork;

namespace Orderly.Domain.Order.ValueObjects;

public sealed class LineItemId : Identifier<Guid>
{
    private LineItemId(Guid value)
        : base(value) { }

    public static LineItemId Generate()
    {
        return new LineItemId(Guid.NewGuid());
    }
}