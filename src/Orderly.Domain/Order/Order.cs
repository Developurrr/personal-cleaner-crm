using Orderly.Domain.Common.ValueObjects;
using Orderly.Domain.Customer.ValueObjects;
using Orderly.Domain.Order.Entities;
using Orderly.Domain.Order.Enums;
using Orderly.Domain.Order.ValueObjects;
using Orderly.Domain.SalesConsultant.ValueObjects;
using Orderly.Domain.SeedWork;
using Orderly.Domain.Shipping.ValueObjects;

namespace Orderly.Domain.Order;

public sealed class Order : Entity<OrderId>, IAggregateRoot
{
    private readonly List<LineItem> _lineItems;
    private TransactionNature _transactionNature;
    private Status _status;
    public CustomerId CustomerId { get; }
    public SalesConsultantId SalesConsultantId { get; }
    public ShippingId? ShippingId { get; private set; }
    public Price OrderTotal { get; private set; }

    private Order(
        OrderId orderId,
        TransactionNature transactionNature,
        CustomerId customerId,
        SalesConsultantId salesConsultantId,
        Price price
    )
        : base(orderId)
    {
        _lineItems = new List<LineItem>();
        _transactionNature = transactionNature;
        _status = Status.Draft;
        CustomerId = customerId;
        SalesConsultantId = salesConsultantId;
        ShippingId = null;
        OrderTotal = price;
    }

    public static Order Open(CustomerId customerId, SalesConsultantId salesConsultantId)
    {
        var orderId = OrderId.Generate();
        var price = Price.Create(default);

        return new Order(orderId, TransactionNature.Venda, customerId, salesConsultantId, price);
    }
}
