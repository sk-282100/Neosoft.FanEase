using MediatR;
using Neosoft.FAMS.Application.Responses;
using System;
using System.Collections.Generic;

namespace Neosoft.FAMS.Application.Features.Orders.Queries.GetOrdersForMonth
{
    public class GetOrdersForMonthQuery : IRequest<PagedResponse<IEnumerable<OrdersForMonthDto>>>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
