using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neosoft.FAMS.Application.Features.AdminDashboard.Queries.GetAll
{
    public class GetAdminStatisticQuery : IRequest<List<long>>
    {
    }
}
